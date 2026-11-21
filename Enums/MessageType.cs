namespace ChatApp.Enums
{
    /// <summary>
    /// Ağ üzerinden iletilen mesajın türünü belirten numaralandırma.
    /// </summary>
    public enum MessageType
    {
        PublicMessage,      // Herkese açık genel oda mesajı
        PrivateMessage,     // Belirli bir kullanıcıya özel mesaj (Fısıltı)
        UserJoined,         // Yeni kullanıcı bağlandı bildirimi
        UserLeft,           // Kullanıcı ayrıldı bildirimi
        UserList,           // Aktif kullanıcı listesi güncellemesi
        SystemNotification  // Sunucu sistem uyarısı veya duyurusu
    }
}
