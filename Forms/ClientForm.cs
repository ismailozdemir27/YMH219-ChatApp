using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ChatApp.Enums;
using ChatApp.Models;
using ChatApp.Network;
using ChatApp.Services;

namespace ChatApp.Forms
{
    public partial class ClientForm : Form
    {
        private readonly ChatClient _client;
        private readonly ChatHistoryService _historyService;
        private readonly List<ChatMessage> _messageHistory = new List<ChatMessage>();

        public ClientForm(string defaultUsername = "Kullanici_2")
        {
            InitializeComponent();

            _client = new ChatClient();
            _historyService = new ChatHistoryService();

            txtClientUser.Text = defaultUsername;
            Text = $"Sohbet İstemcisi - {defaultUsername}";

            BindClientEvents();
        }

        private void BindClientEvents()
        {
            _client.OnMessageReceived += Client_OnMessageReceived;
            _client.OnUserListUpdated += Client_OnUserListUpdated;
            _client.OnStatusChanged += Client_OnStatusChanged;
            _client.OnError += Client_OnError;

            btnClientConnect.Click += async (s, e) =>
            {
                string username = txtClientUser.Text.Trim();
                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Lütfen bir kullanıcı adı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClientUser.Focus();
                    return;
                }

                if (!int.TryParse(txtClientPort.Text.Trim(), out int port))
                {
                    MessageBox.Show("Geçerli bir port numarası giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                btnClientConnect.Enabled = false;
                await _client.ConnectAsync(txtClientIp.Text.Trim(), port, username);
            };

            txtClientUser.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && btnClientConnect.Enabled)
                {
                    e.SuppressKeyPress = true;
                    btnClientConnect.PerformClick();
                }
            };

            txtClientPort.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && btnClientConnect.Enabled)
                {
                    e.SuppressKeyPress = true;
                    btnClientConnect.PerformClick();
                }
            };

            btnClientDisconnect.Click += async (s, e) =>
            {
                await _client.DisconnectAsync();
            };

            btnSendMessage.Click += async (s, e) => await SendMessageAsync();
            txtMessageInput.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    await SendMessageAsync();
                }
            };

            lstOnlineUsers.DoubleClick += (s, e) =>
            {
                if (lstOnlineUsers.SelectedItem is string selectedUser && selectedUser != _client.Username)
                {
                    cmbRecipient.SelectedItem = selectedUser;
                    txtMessageInput.Focus();
                }
            };

            btnSaveHistory.Click += BtnSaveHistory_Click;
            FormClosing += async (s, e) => await _client.DisconnectAsync();
        }

        private async System.Threading.Tasks.Task SendMessageAsync()
        {
            string content = txtMessageInput.Text.Trim();
            if (string.IsNullOrEmpty(content) || !_client.IsConnected) return;

            txtMessageInput.Clear();

            string selected = cmbRecipient.SelectedItem?.ToString() ?? "📢 Herkes (Genel Oda)";
            if (selected.StartsWith("📢"))
            {
                await _client.SendPublicMessageAsync(content);
            }
            else
            {
                await _client.SendPrivateMessageAsync(selected, content);
            }
        }

        private void Client_OnMessageReceived(ChatMessage msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Client_OnMessageReceived(msg)));
                return;
            }

            _messageHistory.Add(msg);
            AppendMessage(msg);
        }

        private void AppendMessage(ChatMessage msg)
        {
            string timeStr = $"[{msg.Timestamp:HH:mm:ss}] ";

            rtbChatMessages.SelectionStart = rtbChatMessages.TextLength;
            rtbChatMessages.SelectionLength = 0;

            // Zaman damgası
            rtbChatMessages.SelectionColor = Color.FromArgb(100, 116, 139);
            rtbChatMessages.AppendText(timeStr);

            switch (msg.Type)
            {
                case MessageType.PublicMessage:
                    bool isMe = msg.Sender.Equals(_client.Username, StringComparison.OrdinalIgnoreCase);
                    rtbChatMessages.SelectionColor = isMe ? Color.FromArgb(22, 101, 52) : Color.FromArgb(30, 64, 175);
                    rtbChatMessages.SelectionFont = new Font(rtbChatMessages.Font, FontStyle.Bold);
                    rtbChatMessages.AppendText($"[{msg.Sender}]: ");

                    rtbChatMessages.SelectionColor = Color.FromArgb(15, 23, 42);
                    rtbChatMessages.SelectionFont = new Font(rtbChatMessages.Font, FontStyle.Regular);
                    rtbChatMessages.AppendText($"{msg.Content}\n");
                    break;

                case MessageType.PrivateMessage:
                    rtbChatMessages.SelectionColor = Color.FromArgb(192, 38, 211); // Magenta
                    rtbChatMessages.SelectionFont = new Font(rtbChatMessages.Font, FontStyle.Bold);
                    rtbChatMessages.AppendText($"🔒 [ÖZEL: {msg.Sender} -> {msg.Recipient}]: ");

                    rtbChatMessages.SelectionColor = Color.FromArgb(147, 51, 234);
                    rtbChatMessages.SelectionFont = new Font(rtbChatMessages.Font, FontStyle.Italic);
                    rtbChatMessages.AppendText($"{msg.Content}\n");
                    break;

                case MessageType.UserJoined:
                    rtbChatMessages.SelectionColor = Color.FromArgb(22, 163, 74);
                    rtbChatMessages.SelectionFont = new Font(rtbChatMessages.Font, FontStyle.Italic);
                    rtbChatMessages.AppendText($"🟢 {msg.Content}\n");
                    break;

                case MessageType.UserLeft:
                    rtbChatMessages.SelectionColor = Color.FromArgb(220, 38, 38);
                    rtbChatMessages.SelectionFont = new Font(rtbChatMessages.Font, FontStyle.Italic);
                    rtbChatMessages.AppendText($"🔴 {msg.Content}\n");
                    break;

                case MessageType.SystemNotification:
                    rtbChatMessages.SelectionColor = Color.FromArgb(217, 119, 6);
                    rtbChatMessages.SelectionFont = new Font(rtbChatMessages.Font, FontStyle.Bold);
                    rtbChatMessages.AppendText($"📢 [SİSTEM]: {msg.Content}\n");
                    break;
            }

            rtbChatMessages.ScrollToCaret();
        }

        private void Client_OnUserListUpdated(List<string> users)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Client_OnUserListUpdated(users)));
                return;
            }

            string currentSelected = cmbRecipient.SelectedItem?.ToString() ?? "📢 Herkes (Genel Oda)";

            lstOnlineUsers.Items.Clear();
            cmbRecipient.Items.Clear();
            cmbRecipient.Items.Add("📢 Herkes (Genel Oda)");

            foreach (var user in users)
            {
                string display = user == _client.Username ? $"{user} (Sen)" : user;
                lstOnlineUsers.Items.Add(display);

                if (user != _client.Username)
                {
                    cmbRecipient.Items.Add(user);
                }
            }

            lblUsersHeader.Text = $"👥 Çevrimiçi Kullanıcılar ({users.Count})";

            if (cmbRecipient.Items.Contains(currentSelected))
            {
                cmbRecipient.SelectedItem = currentSelected;
            }
            else
            {
                cmbRecipient.SelectedIndex = 0;
            }
        }

        private void Client_OnStatusChanged(ConnectionStatus status, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Client_OnStatusChanged(status, message)));
                return;
            }

            if (status == ConnectionStatus.Connected)
            {
                lblClientStatus.Text = "● Bağlandı";
                lblClientStatus.BackColor = Color.FromArgb(22, 163, 74);
                btnClientConnect.Enabled = false;
                btnClientDisconnect.Enabled = true;
                txtClientIp.Enabled = false;
                txtClientPort.Enabled = false;
                txtClientUser.Enabled = false;
                Text = $"Sohbet İstemcisi - {_client.Username} (Bağlı)";
                txtMessageInput.Focus();
            }
            else if (status == ConnectionStatus.Connecting)
            {
                lblClientStatus.Text = "⏳ Bağlanılıyor...";
                lblClientStatus.BackColor = Color.FromArgb(217, 119, 6);
                btnClientConnect.Enabled = false;
                btnClientDisconnect.Enabled = true;
            }
            else
            {
                lblClientStatus.Text = "■ Bağlantı Yok";
                lblClientStatus.BackColor = Color.FromArgb(100, 116, 139);
                btnClientConnect.Enabled = true;
                btnClientDisconnect.Enabled = false;
                txtClientIp.Enabled = true;
                txtClientPort.Enabled = true;
                txtClientUser.Enabled = true;
                Text = $"Sohbet İstemcisi - {_client.Username} (Bağlantı Kesildi)";

                lstOnlineUsers.Items.Clear();
                cmbRecipient.Items.Clear();
                cmbRecipient.Items.Add("📢 Herkes (Genel Oda)");
                cmbRecipient.SelectedIndex = 0;
                lblUsersHeader.Text = "👥 Çevrimiçi Kullanıcılar (0)";
            }
        }

        private void Client_OnError(string error)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Client_OnError(error)));
                return;
            }

            btnClientConnect.Enabled = true;

            string friendlyMessage = error;
            if (error.Contains("Hedef makine", StringComparison.OrdinalIgnoreCase) ||
                error.Contains("reddet", StringComparison.OrdinalIgnoreCase) ||
                error.Contains("refused", StringComparison.OrdinalIgnoreCase))
            {
                friendlyMessage = "Sunucuya bağlanılamadı!\n\n" +
                    "Ana penceredeki 'Sunucu Yönetimi' sekmesinden sunucunun açık olduğundan emin olunuz.";
            }

            MessageBox.Show(friendlyMessage, "Bağlantı Bildirimi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSaveHistory_Click(object? sender, EventArgs e)
        {
            if (_messageHistory.Count == 0)
            {
                MessageBox.Show("Kaydedilecek sohbet geçmişi bulunmuyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Metin Belgesi (*.txt)|*.txt",
                FileName = $"SohbetGecmisi_{DateTime.Now:yyyyMMdd_HHmmss}.txt",
                Title = "Sohbet Geçmişini TXT Olarak Kaydet"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (_historyService.SaveHistory(sfd.FileName, _messageHistory, _client.Username))
                {
                    MessageBox.Show($"Sohbet geçmişi başarıyla kaydedildi:\n{sfd.FileName}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Dosya kaydedilirken hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

