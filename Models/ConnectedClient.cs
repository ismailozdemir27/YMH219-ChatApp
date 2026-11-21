using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ChatApp.Models
{
    /// <summary>
    /// Sunucu tarafında bağlı olan her bir istemciyi temsil eden model sınıfı.
    /// İstemcinin soket, kullanıcı adı ve I/O akışlarını yönetir.
    /// </summary>
    public class ConnectedClient : IDisposable
    {
        public TcpClient Client { get; }
        public string Username { get; set; }
        public string EndPoint { get; }
        public DateTime ConnectedAt { get; }

        public StreamWriter Writer { get; }
        public StreamReader Reader { get; }

        public ConnectedClient(TcpClient client, string username)
        {
            Client = client;
            Username = username;
            EndPoint = client.Client.RemoteEndPoint?.ToString() ?? "Bilinmiyor";
            ConnectedAt = DateTime.Now;

            NetworkStream stream = client.GetStream();
            Writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
            Reader = new StreamReader(stream, Encoding.UTF8);
        }

        public void Dispose()
        {
            try { Writer?.Dispose(); } catch { }
            try { Reader?.Dispose(); } catch { }
            try { Client?.Close(); } catch { }
        }
    }
}
