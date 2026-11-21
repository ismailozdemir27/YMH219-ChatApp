using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChatApp.Enums;
using ChatApp.Models;

namespace ChatApp.Network
{
    /// <summary>
    /// TCP sunucuya bağlanan, asenkron mesaj gönderen ve dinleyen istemci sınıfı.
    /// Nesne yönelimli mimaride istemci iletişimini soyutlar.
    /// </summary>
    public class ChatClient : IDisposable
    {
        public ConnectionStatus Status { get; private set; } = ConnectionStatus.Disconnected;
        public string Username { get; private set; } = string.Empty;
        public string ServerIp { get; private set; } = "127.0.0.1";
        public int ServerPort { get; private set; } = 8888;

        public bool IsConnected => Status == ConnectionStatus.Connected;

        private TcpClient? _tcpClient;
        private StreamWriter? _writer;
        private StreamReader? _reader;
        private CancellationTokenSource? _cts;

        public event Action<ChatMessage>? OnMessageReceived;
        public event Action<List<string>>? OnUserListUpdated;
        public event Action<ConnectionStatus, string>? OnStatusChanged;
        public event Action<string>? OnError;

        /// <summary>
        /// Belirtilen IP ve Port üzerinden TCP sunucuya asenkron bağlanır.
        /// </summary>
        public async Task<bool> ConnectAsync(string ip, int port, string username)
        {
            if (IsConnected) return true;

            try
            {
                ServerIp = ip.Trim();
                ServerPort = port;
                Username = username.Trim();

                SetStatus(ConnectionStatus.Connecting, "Sunucuya bağlanılıyor...");

                _tcpClient = new TcpClient();
                await _tcpClient.ConnectAsync(ServerIp, ServerPort);

                NetworkStream stream = _tcpClient.GetStream();
                _writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
                _reader = new StreamReader(stream, Encoding.UTF8);
                _cts = new CancellationTokenSource();

                // İlk mesaj olarak kullanıcı adı bildirimini ilet
                var initMsg = new ChatMessage(MessageType.UserJoined, Username, "Bağlantı isteği");
                await _writer.WriteLineAsync(initMsg.ToJson());

                SetStatus(ConnectionStatus.Connected, "Sunucuya başarıyla bağlanıldı.");

                // Dinleme döngüsünü arka planda başlat
                _ = ReceiveLoopAsync(_cts.Token);
                return true;
            }
            catch (Exception ex)
            {
                SetStatus(ConnectionStatus.Disconnected, $"Bağlantı kurulamadı: {ex.Message}");
                OnError?.Invoke($"Sunucuya bağlanırken hata: {ex.Message}");
                Cleanup();
                return false;
            }
        }

        private async Task ReceiveLoopAsync(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested && _reader != null)
                {
                    string? line = await _reader.ReadLineAsync(token);
                    if (line == null) break; // Sunucu bağlantıyı kesti

                    ChatMessage? msg = ChatMessage.FromJson(line);
                    if (msg == null) continue;

                    if (msg.Type == MessageType.UserList && msg.UserList != null)
                    {
                        OnUserListUpdated?.Invoke(msg.UserList);
                    }
                    else
                    {
                        OnMessageReceived?.Invoke(msg);
                    }
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (IsConnected)
                {
                    OnError?.Invoke($"Sunucu iletişimi kesildi: {ex.Message}");
                }
            }
            finally
            {
                SetStatus(ConnectionStatus.Disconnected, "Sunucu ile bağlantı kesildi.");
                Cleanup();
            }
        }

        /// <summary>
        /// Herkese açık genel oda mesajı gönderir.
        /// </summary>
        public async Task<bool> SendPublicMessageAsync(string content)
        {
            if (!IsConnected || _writer == null) return false;

            try
            {
                var msg = new ChatMessage(MessageType.PublicMessage, Username, content);
                await _writer.WriteLineAsync(msg.ToJson());
                return true;
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Mesaj gönderilemedi: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Belirli bir kullanıcıya özel mesaj (Fısıltı / Whisper) gönderir.
        /// </summary>
        public async Task<bool> SendPrivateMessageAsync(string recipient, string content)
        {
            if (!IsConnected || _writer == null) return false;

            try
            {
                var msg = new ChatMessage(MessageType.PrivateMessage, Username, content, recipient);
                await _writer.WriteLineAsync(msg.ToJson());
                return true;
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Özel mesaj gönderilemedi: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Sunucu bağlantısını güvenli şekilde sonlandırır.
        /// </summary>
        public async Task DisconnectAsync()
        {
            if (!IsConnected) return;

            try
            {
                _cts?.Cancel();
                if (_writer != null)
                {
                    var leaveMsg = new ChatMessage(MessageType.UserLeft, Username, "Ayrılıyor");
                    await _writer.WriteLineAsync(leaveMsg.ToJson());
                }
            }
            catch { }
            finally
            {
                SetStatus(ConnectionStatus.Disconnected, "Bağlantı kullanıcı tarafından kesildi.");
                Cleanup();
            }
        }

        private void SetStatus(ConnectionStatus status, string message)
        {
            Status = status;
            OnStatusChanged?.Invoke(status, message);
        }

        private void Cleanup()
        {
            try { _writer?.Dispose(); } catch { }
            try { _reader?.Dispose(); } catch { }
            try { _tcpClient?.Close(); } catch { }
            _writer = null;
            _reader = null;
            _tcpClient = null;
        }

        public void Dispose()
        {
            _ = DisconnectAsync();
            _cts?.Dispose();
        }
    }
}
