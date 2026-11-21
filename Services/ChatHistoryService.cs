using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ChatApp.Enums;
using ChatApp.Models;

namespace ChatApp.Services
{
    /// <summary>
    /// Sohbet geçmişinin metin dosyasına (.txt) kaydedilmesini sağlayan I/O servisi.
    /// İsteğe bağlı gereksinimleri karşılar.
    /// </summary>
    public class ChatHistoryService
    {
        public bool SaveHistory(string filePath, IEnumerable<ChatMessage> messages, string currentUsername)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    writer.WriteLine("================================================================================");
                    writer.WriteLine("           YMH219 NESNE TABANLI PROGRAMLAMA - SOHBET GEÇMİŞİ RAPORU            ");
                    writer.WriteLine("================================================================================");
                    writer.WriteLine($"Rapor Tarihi    : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine($"Kullanıcı       : {currentUsername}");
                    writer.WriteLine("================================================================================");
                    writer.WriteLine();

                    foreach (var msg in messages)
                    {
                        string prefix = msg.Type switch
                        {
                            MessageType.PrivateMessage => $"[ÖZEL: {msg.Sender} -> {msg.Recipient}]",
                            MessageType.UserJoined => "[SİSTEM - KATILDI]",
                            MessageType.UserLeft => "[SİSTEM - AYRILDI]",
                            MessageType.SystemNotification => "[SİSTEM DUYURUSU]",
                            _ => $"[{msg.Sender}]"
                        };

                        writer.WriteLine($"{msg.Timestamp:yyyy-MM-dd HH:mm:ss} {prefix}: {msg.Content}");
                    }

                    writer.WriteLine();
                    writer.WriteLine("--- Sohbet Geçmişi Sonu ---");
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
