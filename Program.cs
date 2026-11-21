using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ChatApp.Enums;
using ChatApp.Forms;
using ChatApp.Models;

namespace ChatApp
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--generate-screenshots")
            {
                GenerateScreenshots();
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        private static void GenerateScreenshots()
        {
            string screenshotsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "screenshots");
            Directory.CreateDirectory(screenshotsDir);

            ApplicationConfiguration.Initialize();

            // 1. Ekran Görüntüsü: İstemci Sohbet Odası (Genel Sohbet & Özel Fısıltı & Çevrimiçi Kullanıcılar)
            using (MainForm form1 = new MainForm())
            {
                form1.Show();
                form1.Size = new Size(1040, 640);

                // Tab 0: Client tabı aktif
                var tabMain = form1.Controls.Find("tabMain", true)[0] as TabControl;
                if (tabMain != null) tabMain.SelectedIndex = 0;

                // İstemci arayüzünü simüle edilmiş verilerle doldur
                var rtbChat = form1.Controls.Find("rtbChatMessages", true)[0] as RichTextBox;
                var lstUsers = form1.Controls.Find("lstOnlineUsers", true)[0] as ListBox;
                var lblUsersHeader = form1.Controls.Find("lblUsersHeader", true)[0] as Label;
                var lblStatus = form1.Controls.Find("lblClientStatus", true)[0] as Label;
                var cmbRecip = form1.Controls.Find("cmbRecipient", true)[0] as ComboBox;

                if (lblStatus != null)
                {
                    lblStatus.Text = "● Bağlandı";
                    lblStatus.BackColor = Color.FromArgb(22, 163, 74);
                }

                if (lstUsers != null)
                {
                    lstUsers.Items.Add("İsmail (Sen)");
                    lstUsers.Items.Add("Ahmet");
                    lstUsers.Items.Add("Mehmet");
                    lstUsers.Items.Add("Ayşe");
                }

                if (lblUsersHeader != null) lblUsersHeader.Text = "👥 Çevrimiçi Kullanıcılar (4)";

                if (cmbRecip != null)
                {
                    cmbRecip.Items.Clear();
                    cmbRecip.Items.Add("📢 Herkes (Genel Oda)");
                    cmbRecip.Items.Add("Ahmet");
                    cmbRecip.Items.Add("Mehmet");
                    cmbRecip.Items.Add("Ayşe");
                    cmbRecip.SelectedIndex = 0;
                }

                if (rtbChat != null)
                {
                    AppendSimulatedMessage(rtbChat, new ChatMessage(MessageType.SystemNotification, "SİSTEM", "Sohbet sunucusuna bağlanıldı. Hoş geldiniz!"));
                    AppendSimulatedMessage(rtbChat, new ChatMessage(MessageType.UserJoined, "SİSTEM", "Ahmet odaya katıldı."));
                    AppendSimulatedMessage(rtbChat, new ChatMessage(MessageType.PublicMessage, "Ahmet", "Selamlar herkese, NTP projesini bitiren var mı?"));
                    AppendSimulatedMessage(rtbChat, new ChatMessage(MessageType.PublicMessage, "İsmail", "Selam Ahmet! Ben FlappyBird ve KeyLogger'ı bitirdim, şimdi Chat uygulamasını test ediyorum."));
                    AppendSimulatedMessage(rtbChat, new ChatMessage(MessageType.UserJoined, "SİSTEM", "Mehmet odaya katıldı."));
                    AppendSimulatedMessage(rtbChat, new ChatMessage(MessageType.PrivateMessage, "Ahmet", "İsmail, özel mesaj özelliği harika çalışıyor bu arada!", "İsmail"));
                    AppendSimulatedMessage(rtbChat, new ChatMessage(MessageType.PublicMessage, "Mehmet", "Harika! TCP asenkron mimari çok hızlı yanıt veriyor."));
                }

                Application.DoEvents();
                Thread.Sleep(200);

                using (Bitmap bmp = new Bitmap(form1.Width, form1.Height))
                {
                    form1.DrawToBitmap(bmp, new Rectangle(0, 0, form1.Width, form1.Height));
                    bmp.Save(Path.Combine(screenshotsDir, "client_chat.png"), ImageFormat.Png);
                }

                form1.Close();
            }

            // 2. Ekran Görüntüsü: Sunucu Yönetim Paneli (Aktif Bağlantılar & Sunucu Konsol Logları)
            using (MainForm form2 = new MainForm())
            {
                form2.Show();
                form2.Size = new Size(1040, 640);

                var tabMain = form2.Controls.Find("tabMain", true)[0] as TabControl;
                if (tabMain != null) tabMain.SelectedIndex = 1; // Tab 1: Server tabı

                var lblServerStatus = form2.Controls.Find("lblServerStatus", true)[0] as Label;
                var dgvClients = form2.Controls.Find("dgvServerClients", true)[0] as DataGridView;
                var rtbLogs = form2.Controls.Find("rtbServerLogs", true)[0] as RichTextBox;
                var grpClients = form2.Controls.Find("grpConnectedClients", true)[0] as GroupBox;

                if (lblServerStatus != null)
                {
                    lblServerStatus.Text = "● Sunucu Aktif (Port: 8888)";
                    lblServerStatus.BackColor = Color.FromArgb(22, 163, 74);
                }

                if (dgvClients != null)
                {
                    dgvClients.Rows.Add("İsmail", "127.0.0.1:54120", DateTime.Now.AddMinutes(-12).ToString("yyyy-MM-dd HH:mm:ss"));
                    dgvClients.Rows.Add("Ahmet", "127.0.0.1:54128", DateTime.Now.AddMinutes(-8).ToString("yyyy-MM-dd HH:mm:ss"));
                    dgvClients.Rows.Add("Mehmet", "127.0.0.1:54135", DateTime.Now.AddMinutes(-3).ToString("yyyy-MM-dd HH:mm:ss"));
                    dgvClients.Rows.Add("Ayşe", "127.0.0.1:54142", DateTime.Now.AddMinutes(-1).ToString("yyyy-MM-dd HH:mm:ss"));
                }

                if (grpClients != null) grpClients.Text = "👥 Bağlı İstemciler (4)";

                if (rtbLogs != null)
                {
                    rtbLogs.AppendText($"[{DateTime.Now.AddMinutes(-15):HH:mm:ss}] [SUNUCU] TCP Dinleyici 8888 portunda başlatıldı. İstemciler bekleniyor...\n");
                    rtbLogs.AppendText($"[{DateTime.Now.AddMinutes(-12):HH:mm:ss}] [BAĞLANDI] 'İsmail' (127.0.0.1:54120) bağlandı.\n");
                    rtbLogs.AppendText($"[{DateTime.Now.AddMinutes(-8):HH:mm:ss}] [BAĞLANDI] 'Ahmet' (127.0.0.1:54128) bağlandı.\n");
                    rtbLogs.AppendText($"[{DateTime.Now.AddMinutes(-7):HH:mm:ss}] [GENEL MESAJ] Ahmet -> Herkes: Selamlar herkese!\n");
                    rtbLogs.AppendText($"[{DateTime.Now.AddMinutes(-5):HH:mm:ss}] [ÖZEL MESAJ] Ahmet -> İsmail: Özel mesaj testi.\n");
                    rtbLogs.AppendText($"[{DateTime.Now.AddMinutes(-3):HH:mm:ss}] [BAĞLANDI] 'Mehmet' (127.0.0.1:54135) bağlandı.\n");
                    rtbLogs.AppendText($"[{DateTime.Now.AddMinutes(-1):HH:mm:ss}] [BAĞLANDI] 'Ayşe' (127.0.0.1:54142) bağlandı.\n");
                }

                Application.DoEvents();
                Thread.Sleep(200);

                using (Bitmap bmp = new Bitmap(form2.Width, form2.Height))
                {
                    form2.DrawToBitmap(bmp, new Rectangle(0, 0, form2.Width, form2.Height));
                    bmp.Save(Path.Combine(screenshotsDir, "server.png"), ImageFormat.Png);
                }

                form2.Close();
            }

            Console.WriteLine("ChatApp ekran görüntüleri başarıyla üretildi: " + screenshotsDir);
        }

        private static void AppendSimulatedMessage(RichTextBox rtb, ChatMessage msg)
        {
            string timeStr = $"[{msg.Timestamp:HH:mm:ss}] ";
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;

            rtb.SelectionColor = Color.FromArgb(100, 116, 139);
            rtb.AppendText(timeStr);

            switch (msg.Type)
            {
                case MessageType.PublicMessage:
                    bool isMe = msg.Sender == "İsmail";
                    rtb.SelectionColor = isMe ? Color.FromArgb(22, 101, 52) : Color.FromArgb(30, 64, 175);
                    rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);
                    rtb.AppendText($"[{msg.Sender}]: ");

                    rtb.SelectionColor = Color.FromArgb(15, 23, 42);
                    rtb.SelectionFont = new Font(rtb.Font, FontStyle.Regular);
                    rtb.AppendText($"{msg.Content}\n");
                    break;

                case MessageType.PrivateMessage:
                    rtb.SelectionColor = Color.FromArgb(192, 38, 211);
                    rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);
                    rtb.AppendText($"🔒 [ÖZEL: {msg.Sender} -> {msg.Recipient}]: ");

                    rtb.SelectionColor = Color.FromArgb(147, 51, 234);
                    rtb.SelectionFont = new Font(rtb.Font, FontStyle.Italic);
                    rtb.AppendText($"{msg.Content}\n");
                    break;

                case MessageType.UserJoined:
                    rtb.SelectionColor = Color.FromArgb(22, 163, 74);
                    rtb.SelectionFont = new Font(rtb.Font, FontStyle.Italic);
                    rtb.AppendText($"🟢 {msg.Content}\n");
                    break;

                case MessageType.SystemNotification:
                    rtb.SelectionColor = Color.FromArgb(217, 119, 6);
                    rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);
                    rtb.AppendText($"📢 [SİSTEM]: {msg.Content}\n");
                    break;
            }
        }
    }
}
