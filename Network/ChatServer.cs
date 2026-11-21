using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using ChatApp.Enums;
using ChatApp.Models;

namespace ChatApp.Network
{
    /// <summary>
    /// Çoklu istemci bağlantılarını, mesaj yönlendirmesini (broadcast ve özel mesaj)
    /// asenkron olarak yöneten merkezi TCP sunucu sınıfı.
    /// </summary>
    public class ChatServer : IDisposable
    {
        public int Port { get; private set; }
        public bool IsRunning { get; private set; } = false;

        private TcpListener? _listener;
        private CancellationTokenSource? _cts;
        private readonly ConcurrentDictionary<string, ConnectedClient> _clients = new ConcurrentDictionary<string, ConnectedClient>();

        public event Action<string>? OnLog;
        public event Action<ConnectedClient>? OnClientConnected;
        public event Action<ConnectedClient>? OnClientDisconnected;
        public event Action<ChatMessage>? OnMessageRouted;

        public IReadOnlyList<ConnectedClient> ConnectedClients => _clients.Values.ToList();

        /// <summary>
        /// Sunucuyu belirtilen portta dinlemeye başlatır.
        /// </summary>
        public async Task<bool> StartAsync(int port)
        {
            if (IsRunning) return true;

            try
            {
                Port = port;
                _listener = new TcpListener(IPAddress.Any, Port);
                _listener.Start();

                _cts = new CancellationTokenSource();
                IsRunning = true;

                Log($"[SUNUCU] TCP Dinleyici {Port} portunda başlatıldı. İstemciler bekleniyor...");

                // Arka planda gelen bağlantıları kabul et
                _ = AcceptClientsAsync(_cts.Token);
                return true;
            }
            catch (Exception ex)
            {
                Log($"[HATA] Sunucu başlatılamadı: {ex.Message}");
                IsRunning = false;
                return false;
            }
        }

        private async Task AcceptClientsAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested && _listener != null)
            {
                try
                {
                    TcpClient tcpClient = await _listener.AcceptTcpClientAsync(token);
                    _ = HandleClientAsync(tcpClient, token);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    if (!token.IsCancellationRequested)
                    {
                        Log($"[HATA] İstemci kabul edilirken hata: {ex.Message}");
                    }
                }
            }
        }

        private async Task HandleClientAsync(TcpClient tcpClient, CancellationToken token)
        {
            ConnectedClient? client = null;
            try
            {
                // İlk mesaj olarak istemciden kullanıcı adı içeren bağlantı mesajı beklenir
                NetworkStream stream = tcpClient.GetStream();
                using var tempReader = new System.IO.StreamReader(stream, System.Text.Encoding.UTF8, leaveOpen: true);
                using var tempWriter = new System.IO.StreamWriter(stream, System.Text.Encoding.UTF8, leaveOpen: true) { AutoFlush = true };

                string? firstLine = await tempReader.ReadLineAsync(token);
                if (string.IsNullOrWhiteSpace(firstLine))
                {
                    tcpClient.Close();
                    return;
                }

                ChatMessage? initMsg = ChatMessage.FromJson(firstLine);
                if (initMsg == null || string.IsNullOrWhiteSpace(initMsg.Sender))
                {
                    tcpClient.Close();
                    return;
                }

                string username = initMsg.Sender.Trim();

                // Kullanıcı adı benzersizlik kontrolü
                if (_clients.ContainsKey(username))
                {
                    var errorMsg = new ChatMessage(MessageType.SystemNotification, "SUNUCU", $"'{username}' kullanıcı adı şu anda kullanımda. Lütfen başka bir ad seçiniz.");
                    await tempWriter.WriteLineAsync(errorMsg.ToJson());
                    tcpClient.Close();
                    Log($"[REDDEDİLDİ] '{username}' adı zaten bağlı olduğu için bağlantı reddedildi.");
                    return;
                }

                client = new ConnectedClient(tcpClient, username);
                if (!_clients.TryAdd(username, client))
                {
                    client.Dispose();
                    return;
                }

                Log($"[BAĞLANDI] '{username}' ({client.EndPoint}) bağlandı.");
                OnClientConnected?.Invoke(client);

                // Odaya yeni katılan kullanıcıyı herkese duyur
                var joinMsg = new ChatMessage(MessageType.UserJoined, "SUNUCU", $"{username} sohbete katıldı.");
                await BroadcastMessageAsync(joinMsg);

                // Güncel kullanıcı listesini herkese gönder
                await BroadcastUserListAsync();

                // İstemciden gelen mesajları dinleme döngüsü
                while (!token.IsCancellationRequested && tcpClient.Connected)
                {
                    string? line = await client.Reader.ReadLineAsync(token);
                    if (line == null) break; // İstemci bağlantıyı kapattı

                    ChatMessage? msg = ChatMessage.FromJson(line);
                    if (msg == null) continue;

                    // Mesaj türüne göre yönlendir
                    if (msg.Type == MessageType.PrivateMessage)
                    {
                        await RoutePrivateMessageAsync(client, msg);
                    }
                    else if (msg.Type == MessageType.PublicMessage)
                    {
                        await BroadcastMessageAsync(msg);
                    }

                    OnMessageRouted?.Invoke(msg);
                }
            }
            catch (Exception ex)
            {
                if (client != null)
                {
                    Log($"[BİLGİ] '{client.Username}' bağlantısı sonlandı: {ex.Message}");
                }
            }
            finally
            {
                if (client != null)
                {
                    _clients.TryRemove(client.Username, out _);
                    client.Dispose();

                    Log($"[AYRILDI] '{client.Username}' sohbetten ayrıldı.");
                    OnClientDisconnected?.Invoke(client);

                    // Ayrılma bildirimini ve güncel listeyi duyur
                    var leaveMsg = new ChatMessage(MessageType.UserLeft, "SUNUCU", $"{client.Username} sohbetten ayrıldı.");
                    _ = BroadcastMessageAsync(leaveMsg);
                    _ = BroadcastUserListAsync();
                }
            }
        }

        /// <summary>
        /// Mesajı tüm bağlı istemcilere genel olarak yayınlar.
        /// </summary>
        public async Task BroadcastMessageAsync(ChatMessage message)
        {
            string json = message.ToJson();
            var tasks = _clients.Values.Select(async c =>
            {
                try
                {
                    await c.Writer.WriteLineAsync(json);
                }
                catch
                {
                    // Hatalı istemci sonraki döngüde temizlenecektir
                }
            });

            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Özel mesajı sadece alıcıya ve gönderene yönlendirir (Whisper).
        /// </summary>
        private async Task RoutePrivateMessageAsync(ConnectedClient sender, ChatMessage msg)
        {
            if (string.IsNullOrWhiteSpace(msg.Recipient)) return;

            string json = msg.ToJson();

            // Alıcıyı bul ve gönder
            if (_clients.TryGetValue(msg.Recipient, out var recipientClient))
            {
                await recipientClient.Writer.WriteLineAsync(json);
                // Gönderenin de kendi ekranında özel mesajı görmesi için kopyasını ilet
                await sender.Writer.WriteLineAsync(json);
                Log($"[ÖZEL MESAJ] {sender.Username} -> {msg.Recipient}: {msg.Content}");
            }
            else
            {
                // Alıcı bulunamadıysa gönderene sistem mesajı ilet
                var notFound = new ChatMessage(MessageType.SystemNotification, "SUNUCU", $"'{msg.Recipient}' adlı kullanıcı şu an çevrimiçi değil.", sender.Username);
                await sender.Writer.WriteLineAsync(notFound.ToJson());
            }
        }

        /// <summary>
        /// Güncel aktif kullanıcı listesini tüm istemcilere bildirir.
        /// </summary>
        private async Task BroadcastUserListAsync()
        {
            var users = _clients.Keys.OrderBy(u => u).ToList();
            var listMsg = new ChatMessage
            {
                Type = MessageType.UserList,
                Sender = "SUNUCU",
                UserList = users
            };

            await BroadcastMessageAsync(listMsg);
        }

        /// <summary>
        /// Sunucu arayüzünden doğrudan genel duyuru yapma imkanı sağlar.
        /// </summary>
        public async Task BroadcastAnnouncementAsync(string announcement)
        {
            if (!IsRunning) return;
            var sysMsg = new ChatMessage(MessageType.SystemNotification, "SUNUCU DUYURUSU", announcement);
            await BroadcastMessageAsync(sysMsg);
            Log($"[DUYURU] {announcement}");
        }

        /// <summary>
        /// Sunucuyu ve tüm bağlantıları güvenli biçimde durdurur.
        /// </summary>
        public void Stop()
        {
            if (!IsRunning) return;

            IsRunning = false;
            _cts?.Cancel();

            // Tüm bağlı istemcileri bilgilendir ve kapat
            var shutdownMsg = new ChatMessage(MessageType.SystemNotification, "SUNUCU", "Sunucu kapatıldı.").ToJson();
            foreach (var client in _clients.Values)
            {
                try
                {
                    client.Writer.WriteLine(shutdownMsg);
                    client.Dispose();
                }
                catch { }
            }

            _clients.Clear();

            try { _listener?.Stop(); } catch { }
            _listener = null;

            Log("[SUNUCU] Sunucu tamamen durduruldu.");
        }

        private void Log(string message)
        {
            OnLog?.Invoke($"[{DateTime.Now:HH:mm:ss}] {message}");
        }

        public void Dispose()
        {
            Stop();
            _cts?.Dispose();
        }
    }
}
