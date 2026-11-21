using System;
using System.Collections.Generic;
using System.Text.Json;
using ChatApp.Enums;

namespace ChatApp.Models
{
    /// <summary>
    /// Ağ üzerinde TCP soketleri üzerinden iletilen mesaj veri modeli.
    /// JSON formatında serileştirilerek UTF-8 akışı ile taşınır.
    /// </summary>
    public class ChatMessage
    {
        public MessageType Type { get; set; }
        public string Sender { get; set; } = string.Empty;
        public string? Recipient { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public List<string>? UserList { get; set; }

        public ChatMessage() { }

        public ChatMessage(MessageType type, string sender, string content, string? recipient = null)
        {
            Type = type;
            Sender = sender;
            Content = content;
            Recipient = recipient;
            Timestamp = DateTime.Now;
        }

        /// <summary>
        /// Mesaj nesnesini JSON dizesine dönüştürür.
        /// </summary>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// JSON dizesini ChatMessage nesnesine dönüştürür.
        /// </summary>
        public static ChatMessage? FromJson(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<ChatMessage>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}
