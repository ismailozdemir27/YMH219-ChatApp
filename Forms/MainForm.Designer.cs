namespace ChatApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabClient;
        private System.Windows.Forms.TabPage tabServer;

        // --- Client Controls ---
        private System.Windows.Forms.Panel pnlClientConnect;
        private System.Windows.Forms.Label lblClientIp;
        private System.Windows.Forms.TextBox txtClientIp;
        private System.Windows.Forms.Label lblClientPort;
        private System.Windows.Forms.TextBox txtClientPort;
        private System.Windows.Forms.Label lblClientUser;
        private System.Windows.Forms.TextBox txtClientUser;
        private System.Windows.Forms.Button btnClientConnect;
        private System.Windows.Forms.Button btnClientDisconnect;
        private System.Windows.Forms.Label lblClientStatus;
        private System.Windows.Forms.Button btnNewClientWindow;

        private System.Windows.Forms.SplitContainer splitClient;
        private System.Windows.Forms.RichTextBox rtbChatMessages;
        private System.Windows.Forms.Panel pnlUserList;
        private System.Windows.Forms.Label lblUsersHeader;
        private System.Windows.Forms.ListBox lstOnlineUsers;

        private System.Windows.Forms.Panel pnlClientSend;
        private System.Windows.Forms.ComboBox cmbRecipient;
        private System.Windows.Forms.TextBox txtMessageInput;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnSaveHistory;

        // --- Server Controls ---
        private System.Windows.Forms.Panel pnlServerHeader;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Button btnServerStart;
        private System.Windows.Forms.Button btnServerStop;
        private System.Windows.Forms.Label lblServerStatus;

        private System.Windows.Forms.SplitContainer splitServer;
        private System.Windows.Forms.GroupBox grpConnectedClients;
        private System.Windows.Forms.DataGridView dgvServerClients;
        private System.Windows.Forms.GroupBox grpServerLogs;
        private System.Windows.Forms.RichTextBox rtbServerLogs;

        private System.Windows.Forms.Panel pnlServerBroadcast;
        private System.Windows.Forms.TextBox txtServerAnnouncement;
        private System.Windows.Forms.Button btnServerBroadcast;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabClient = new System.Windows.Forms.TabPage();
            this.tabServer = new System.Windows.Forms.TabPage();

            // Client Controls Init
            this.pnlClientConnect = new System.Windows.Forms.Panel();
            this.lblClientIp = new System.Windows.Forms.Label();
            this.txtClientIp = new System.Windows.Forms.TextBox();
            this.lblClientPort = new System.Windows.Forms.Label();
            this.txtClientPort = new System.Windows.Forms.TextBox();
            this.lblClientUser = new System.Windows.Forms.Label();
            this.txtClientUser = new System.Windows.Forms.TextBox();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.btnClientDisconnect = new System.Windows.Forms.Button();
            this.lblClientStatus = new System.Windows.Forms.Label();
            this.btnNewClientWindow = new System.Windows.Forms.Button();

            this.splitClient = new System.Windows.Forms.SplitContainer();
            this.rtbChatMessages = new System.Windows.Forms.RichTextBox();
            this.pnlUserList = new System.Windows.Forms.Panel();
            this.lblUsersHeader = new System.Windows.Forms.Label();
            this.lstOnlineUsers = new System.Windows.Forms.ListBox();

            this.pnlClientSend = new System.Windows.Forms.Panel();
            this.cmbRecipient = new System.Windows.Forms.ComboBox();
            this.txtMessageInput = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnSaveHistory = new System.Windows.Forms.Button();

            // Server Controls Init
            this.pnlServerHeader = new System.Windows.Forms.Panel();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.btnServerStart = new System.Windows.Forms.Button();
            this.btnServerStop = new System.Windows.Forms.Button();
            this.lblServerStatus = new System.Windows.Forms.Label();

            this.splitServer = new System.Windows.Forms.SplitContainer();
            this.grpConnectedClients = new System.Windows.Forms.GroupBox();
            this.dgvServerClients = new System.Windows.Forms.DataGridView();
            this.grpServerLogs = new System.Windows.Forms.GroupBox();
            this.rtbServerLogs = new System.Windows.Forms.RichTextBox();

            this.pnlServerBroadcast = new System.Windows.Forms.Panel();
            this.txtServerAnnouncement = new System.Windows.Forms.TextBox();
            this.btnServerBroadcast = new System.Windows.Forms.Button();

            this.tabMain.SuspendLayout();
            this.tabClient.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.pnlClientConnect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitClient)).BeginInit();
            this.splitClient.Panel1.SuspendLayout();
            this.splitClient.Panel2.SuspendLayout();
            this.splitClient.SuspendLayout();
            this.pnlUserList.SuspendLayout();
            this.pnlClientSend.SuspendLayout();
            this.pnlServerHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitServer)).BeginInit();
            this.splitServer.Panel1.SuspendLayout();
            this.splitServer.Panel2.SuspendLayout();
            this.splitServer.SuspendLayout();
            this.grpConnectedClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServerClients)).BeginInit();
            this.grpServerLogs.SuspendLayout();
            this.pnlServerBroadcast.SuspendLayout();
            this.SuspendLayout();

            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabClient);
            this.tabMain.Controls.Add(this.tabServer);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabMain.ItemSize = new System.Drawing.Size(160, 32);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1040, 640);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 0;

            // 
            // tabClient
            // 
            this.tabClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tabClient.Controls.Add(this.splitClient);
            this.tabClient.Controls.Add(this.pnlClientSend);
            this.tabClient.Controls.Add(this.pnlClientConnect);
            this.tabClient.Location = new System.Drawing.Point(4, 36);
            this.tabClient.Name = "tabClient";
            this.tabClient.Size = new System.Drawing.Size(1032, 600);
            this.tabClient.TabIndex = 0;
            this.tabClient.Text = "💬 Sohbet İstemcisi";

            // 
            // pnlClientConnect
            // 
            this.pnlClientConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlClientConnect.Controls.Add(this.btnNewClientWindow);
            this.pnlClientConnect.Controls.Add(this.lblClientStatus);
            this.pnlClientConnect.Controls.Add(this.btnClientDisconnect);
            this.pnlClientConnect.Controls.Add(this.btnClientConnect);
            this.pnlClientConnect.Controls.Add(this.txtClientUser);
            this.pnlClientConnect.Controls.Add(this.lblClientUser);
            this.pnlClientConnect.Controls.Add(this.txtClientPort);
            this.pnlClientConnect.Controls.Add(this.lblClientPort);
            this.pnlClientConnect.Controls.Add(this.txtClientIp);
            this.pnlClientConnect.Controls.Add(this.lblClientIp);
            this.pnlClientConnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlClientConnect.Location = new System.Drawing.Point(0, 0);
            this.pnlClientConnect.Name = "pnlClientConnect";
            this.pnlClientConnect.Size = new System.Drawing.Size(1032, 54);
            this.pnlClientConnect.TabIndex = 0;

            // 
            // lblClientIp
            // 
            this.lblClientIp.AutoSize = true;
            this.lblClientIp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClientIp.ForeColor = System.Drawing.Color.White;
            this.lblClientIp.Location = new System.Drawing.Point(12, 18);
            this.lblClientIp.Name = "lblClientIp";
            this.lblClientIp.Size = new System.Drawing.Size(21, 15);
            this.lblClientIp.TabIndex = 0;
            this.lblClientIp.Text = "IP:";

            // 
            // txtClientIp
            // 
            this.txtClientIp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClientIp.Location = new System.Drawing.Point(36, 15);
            this.txtClientIp.Name = "txtClientIp";
            this.txtClientIp.Size = new System.Drawing.Size(95, 23);
            this.txtClientIp.TabIndex = 1;
            this.txtClientIp.Text = "127.0.0.1";

            // 
            // lblClientPort
            // 
            this.lblClientPort.AutoSize = true;
            this.lblClientPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClientPort.ForeColor = System.Drawing.Color.White;
            this.lblClientPort.Location = new System.Drawing.Point(137, 18);
            this.lblClientPort.Name = "lblClientPort";
            this.lblClientPort.Size = new System.Drawing.Size(34, 15);
            this.lblClientPort.TabIndex = 2;
            this.lblClientPort.Text = "Port:";

            // 
            // txtClientPort
            // 
            this.txtClientPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClientPort.Location = new System.Drawing.Point(173, 15);
            this.txtClientPort.Name = "txtClientPort";
            this.txtClientPort.Size = new System.Drawing.Size(55, 23);
            this.txtClientPort.TabIndex = 3;
            this.txtClientPort.Text = "8888";

            // 
            // lblClientUser
            // 
            this.lblClientUser.AutoSize = true;
            this.lblClientUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClientUser.ForeColor = System.Drawing.Color.White;
            this.lblClientUser.Location = new System.Drawing.Point(238, 18);
            this.lblClientUser.Name = "lblClientUser";
            this.lblClientUser.Size = new System.Drawing.Size(77, 15);
            this.lblClientUser.TabIndex = 4;
            this.lblClientUser.Text = "Kullanıcı Adı:";

            // 
            // txtClientUser
            // 
            this.txtClientUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClientUser.Location = new System.Drawing.Point(318, 15);
            this.txtClientUser.Name = "txtClientUser";
            this.txtClientUser.Size = new System.Drawing.Size(115, 23);
            this.txtClientUser.TabIndex = 5;
            this.txtClientUser.Text = "İsmail";

            // 
            // btnClientConnect
            // 
            this.btnClientConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnClientConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientConnect.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnClientConnect.ForeColor = System.Drawing.Color.White;
            this.btnClientConnect.Location = new System.Drawing.Point(442, 13);
            this.btnClientConnect.Name = "btnClientConnect";
            this.btnClientConnect.Size = new System.Drawing.Size(95, 28);
            this.btnClientConnect.TabIndex = 6;
            this.btnClientConnect.Text = "🔗 Bağlan";
            this.btnClientConnect.UseVisualStyleBackColor = false;

            // 
            // btnClientDisconnect
            // 
            this.btnClientDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnClientDisconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientDisconnect.Enabled = false;
            this.btnClientDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientDisconnect.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnClientDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnClientDisconnect.Location = new System.Drawing.Point(542, 13);
            this.btnClientDisconnect.Name = "btnClientDisconnect";
            this.btnClientDisconnect.Size = new System.Drawing.Size(110, 28);
            this.btnClientDisconnect.TabIndex = 7;
            this.btnClientDisconnect.Text = "❌ Bağlantıyı Kes";
            this.btnClientDisconnect.UseVisualStyleBackColor = false;

            // 
            // lblClientStatus
            // 
            this.lblClientStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblClientStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblClientStatus.ForeColor = System.Drawing.Color.White;
            this.lblClientStatus.Location = new System.Drawing.Point(660, 13);
            this.lblClientStatus.Name = "lblClientStatus";
            this.lblClientStatus.Size = new System.Drawing.Size(140, 28);
            this.lblClientStatus.TabIndex = 8;
            this.lblClientStatus.Text = "■ Bağlantı Yok";
            this.lblClientStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // btnNewClientWindow
            // 
            this.btnNewClientWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewClientWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnNewClientWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewClientWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewClientWindow.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnNewClientWindow.ForeColor = System.Drawing.Color.White;
            this.btnNewClientWindow.Location = new System.Drawing.Point(825, 12);
            this.btnNewClientWindow.Name = "btnNewClientWindow";
            this.btnNewClientWindow.Size = new System.Drawing.Size(195, 30);
            this.btnNewClientWindow.TabIndex = 9;
            this.btnNewClientWindow.Text = "➕ Yeni İstemci Aç (Çoklu Test)";
            this.btnNewClientWindow.UseVisualStyleBackColor = false;

            // 
            // splitClient
            // 
            this.splitClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitClient.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitClient.Location = new System.Drawing.Point(0, 54);
            this.splitClient.Name = "splitClient";
            // 
            // splitClient.Panel1
            // 
            this.splitClient.Panel1.Controls.Add(this.rtbChatMessages);
            this.splitClient.Panel1.Padding = new System.Windows.Forms.Padding(12, 10, 6, 8);
            // 
            // splitClient.Panel2
            // 
            this.splitClient.Panel2.Controls.Add(this.pnlUserList);
            this.splitClient.Panel2.Padding = new System.Windows.Forms.Padding(6, 10, 12, 8);
            this.splitClient.Size = new System.Drawing.Size(1032, 496);
            this.splitClient.SplitterDistance = 770;
            this.splitClient.TabIndex = 1;

            // 
            // rtbChatMessages
            // 
            this.rtbChatMessages.BackColor = System.Drawing.Color.White;
            this.rtbChatMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbChatMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbChatMessages.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rtbChatMessages.Location = new System.Drawing.Point(12, 10);
            this.rtbChatMessages.Name = "rtbChatMessages";
            this.rtbChatMessages.ReadOnly = true;
            this.rtbChatMessages.Size = new System.Drawing.Size(752, 478);
            this.rtbChatMessages.TabIndex = 0;
            this.rtbChatMessages.Text = "";

            // 
            // pnlUserList
            // 
            this.pnlUserList.BackColor = System.Drawing.Color.White;
            this.pnlUserList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUserList.Controls.Add(this.lstOnlineUsers);
            this.pnlUserList.Controls.Add(this.lblUsersHeader);
            this.pnlUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserList.Location = new System.Drawing.Point(6, 10);
            this.pnlUserList.Name = "pnlUserList";
            this.pnlUserList.Size = new System.Drawing.Size(240, 478);
            this.pnlUserList.TabIndex = 0;

            // 
            // lblUsersHeader
            // 
            this.lblUsersHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.lblUsersHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUsersHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsersHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblUsersHeader.Location = new System.Drawing.Point(0, 0);
            this.lblUsersHeader.Name = "lblUsersHeader";
            this.lblUsersHeader.Size = new System.Drawing.Size(238, 30);
            this.lblUsersHeader.TabIndex = 0;
            this.lblUsersHeader.Text = "👥 Çevrimiçi Kullanıcılar (0)";
            this.lblUsersHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lstOnlineUsers
            // 
            this.lstOnlineUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstOnlineUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOnlineUsers.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstOnlineUsers.FormattingEnabled = true;
            this.lstOnlineUsers.ItemHeight = 17;
            this.lstOnlineUsers.Location = new System.Drawing.Point(0, 30);
            this.lstOnlineUsers.Name = "lstOnlineUsers";
            this.lstOnlineUsers.Size = new System.Drawing.Size(238, 446);
            this.lstOnlineUsers.TabIndex = 1;

            // 
            // pnlClientSend
            // 
            this.pnlClientSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlClientSend.Controls.Add(this.btnSaveHistory);
            this.pnlClientSend.Controls.Add(this.btnSendMessage);
            this.pnlClientSend.Controls.Add(this.txtMessageInput);
            this.pnlClientSend.Controls.Add(this.cmbRecipient);
            this.pnlClientSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlClientSend.Location = new System.Drawing.Point(0, 550);
            this.pnlClientSend.Name = "pnlClientSend";
            this.pnlClientSend.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlClientSend.Size = new System.Drawing.Size(1032, 50);
            this.pnlClientSend.TabIndex = 2;

            // 
            // cmbRecipient
            // 
            this.cmbRecipient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecipient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbRecipient.FormattingEnabled = true;
            this.cmbRecipient.Location = new System.Drawing.Point(12, 13);
            this.cmbRecipient.Name = "cmbRecipient";
            this.cmbRecipient.Size = new System.Drawing.Size(155, 23);
            this.cmbRecipient.TabIndex = 0;

            // 
            // txtMessageInput
            // 
            this.txtMessageInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessageInput.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMessageInput.Location = new System.Drawing.Point(175, 12);
            this.txtMessageInput.Name = "txtMessageInput";
            this.txtMessageInput.PlaceholderText = "Mesajınızı yazınız (Enter tuşu ile gönder)...";
            this.txtMessageInput.Size = new System.Drawing.Size(595, 24);
            this.txtMessageInput.TabIndex = 1;

            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSendMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSendMessage.ForeColor = System.Drawing.Color.White;
            this.btnSendMessage.Location = new System.Drawing.Point(778, 10);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(100, 30);
            this.btnSendMessage.TabIndex = 2;
            this.btnSendMessage.Text = "📤 Gönder";
            this.btnSendMessage.UseVisualStyleBackColor = false;

            // 
            // btnSaveHistory
            // 
            this.btnSaveHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSaveHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveHistory.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSaveHistory.ForeColor = System.Drawing.Color.White;
            this.btnSaveHistory.Location = new System.Drawing.Point(886, 10);
            this.btnSaveHistory.Name = "btnSaveHistory";
            this.btnSaveHistory.Size = new System.Drawing.Size(134, 30);
            this.btnSaveHistory.TabIndex = 3;
            this.btnSaveHistory.Text = "💾 Geçmişi Kaydet";
            this.btnSaveHistory.UseVisualStyleBackColor = false;

            // 
            // tabServer
            // 
            this.tabServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tabServer.Controls.Add(this.splitServer);
            this.tabServer.Controls.Add(this.pnlServerBroadcast);
            this.tabServer.Controls.Add(this.pnlServerHeader);
            this.tabServer.Location = new System.Drawing.Point(4, 36);
            this.tabServer.Name = "tabServer";
            this.tabServer.Size = new System.Drawing.Size(1032, 600);
            this.tabServer.TabIndex = 1;
            this.tabServer.Text = "🖥️ Sunucu Yönetimi";

            // 
            // pnlServerHeader
            // 
            this.pnlServerHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlServerHeader.Controls.Add(this.lblServerStatus);
            this.pnlServerHeader.Controls.Add(this.btnServerStop);
            this.pnlServerHeader.Controls.Add(this.btnServerStart);
            this.pnlServerHeader.Controls.Add(this.txtServerPort);
            this.pnlServerHeader.Controls.Add(this.lblServerPort);
            this.pnlServerHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlServerHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlServerHeader.Name = "pnlServerHeader";
            this.pnlServerHeader.Size = new System.Drawing.Size(1032, 54);
            this.pnlServerHeader.TabIndex = 0;

            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblServerPort.ForeColor = System.Drawing.Color.White;
            this.lblServerPort.Location = new System.Drawing.Point(14, 18);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(81, 15);
            this.lblServerPort.TabIndex = 0;
            this.lblServerPort.Text = "Dinleme Port:";

            // 
            // txtServerPort
            // 
            this.txtServerPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtServerPort.Location = new System.Drawing.Point(101, 15);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(65, 23);
            this.txtServerPort.TabIndex = 1;
            this.txtServerPort.Text = "8888";

            // 
            // btnServerStart
            // 
            this.btnServerStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnServerStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServerStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerStart.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnServerStart.ForeColor = System.Drawing.Color.White;
            this.btnServerStart.Location = new System.Drawing.Point(180, 13);
            this.btnServerStart.Name = "btnServerStart";
            this.btnServerStart.Size = new System.Drawing.Size(130, 28);
            this.btnServerStart.TabIndex = 2;
            this.btnServerStart.Text = "▶ Sunucuyu Başlat";
            this.btnServerStart.UseVisualStyleBackColor = false;

            // 
            // btnServerStop
            // 
            this.btnServerStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnServerStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServerStop.Enabled = false;
            this.btnServerStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerStop.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnServerStop.ForeColor = System.Drawing.Color.White;
            this.btnServerStop.Location = new System.Drawing.Point(318, 13);
            this.btnServerStop.Name = "btnServerStop";
            this.btnServerStop.Size = new System.Drawing.Size(130, 28);
            this.btnServerStop.TabIndex = 3;
            this.btnServerStop.Text = "⏹ Sunucuyu Durdur";
            this.btnServerStop.UseVisualStyleBackColor = false;

            // 
            // lblServerStatus
            // 
            this.lblServerStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblServerStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblServerStatus.ForeColor = System.Drawing.Color.White;
            this.lblServerStatus.Location = new System.Drawing.Point(460, 13);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(250, 28);
            this.lblServerStatus.TabIndex = 4;
            this.lblServerStatus.Text = "■ Sunucu Kapalı";
            this.lblServerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // splitServer
            // 
            this.splitServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitServer.Location = new System.Drawing.Point(0, 54);
            this.splitServer.Name = "splitServer";
            this.splitServer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitServer.Panel1
            // 
            this.splitServer.Panel1.Controls.Add(this.grpConnectedClients);
            this.splitServer.Panel1.Padding = new System.Windows.Forms.Padding(12, 10, 12, 6);
            // 
            // splitServer.Panel2
            // 
            this.splitServer.Panel2.Controls.Add(this.grpServerLogs);
            this.splitServer.Panel2.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.splitServer.Size = new System.Drawing.Size(1032, 496);
            this.splitServer.SplitterDistance = 220;
            this.splitServer.TabIndex = 1;

            // 
            // grpConnectedClients
            // 
            this.grpConnectedClients.Controls.Add(this.dgvServerClients);
            this.grpConnectedClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConnectedClients.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpConnectedClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpConnectedClients.Location = new System.Drawing.Point(12, 10);
            this.grpConnectedClients.Name = "grpConnectedClients";
            this.grpConnectedClients.Padding = new System.Windows.Forms.Padding(8);
            this.grpConnectedClients.Size = new System.Drawing.Size(1008, 204);
            this.grpConnectedClients.TabIndex = 0;
            this.grpConnectedClients.TabStop = false;
            this.grpConnectedClients.Text = "👥 Bağlı İstemciler (Sunucu Listesi)";

            // 
            // dgvServerClients
            // 
            this.dgvServerClients.AllowUserToAddRows = false;
            this.dgvServerClients.AllowUserToDeleteRows = false;
            this.dgvServerClients.BackgroundColor = System.Drawing.Color.White;
            this.dgvServerClients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvServerClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServerClients.Location = new System.Drawing.Point(8, 24);
            this.dgvServerClients.Name = "dgvServerClients";
            this.dgvServerClients.ReadOnly = true;
            this.dgvServerClients.RowHeadersVisible = false;
            this.dgvServerClients.Size = new System.Drawing.Size(992, 172);
            this.dgvServerClients.TabIndex = 0;

            // 
            // grpServerLogs
            // 
            this.grpServerLogs.Controls.Add(this.rtbServerLogs);
            this.grpServerLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpServerLogs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpServerLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpServerLogs.Location = new System.Drawing.Point(12, 6);
            this.grpServerLogs.Name = "grpServerLogs";
            this.grpServerLogs.Padding = new System.Windows.Forms.Padding(8);
            this.grpServerLogs.Size = new System.Drawing.Size(1008, 260);
            this.grpServerLogs.TabIndex = 0;
            this.grpServerLogs.TabStop = false;
            this.grpServerLogs.Text = "📜 Sunucu Olay ve İletişim Günlüğü (Console Log)";

            // 
            // rtbServerLogs
            // 
            this.rtbServerLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.rtbServerLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbServerLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbServerLogs.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbServerLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.rtbServerLogs.Location = new System.Drawing.Point(8, 24);
            this.rtbServerLogs.Name = "rtbServerLogs";
            this.rtbServerLogs.ReadOnly = true;
            this.rtbServerLogs.Size = new System.Drawing.Size(992, 228);
            this.rtbServerLogs.TabIndex = 0;
            this.rtbServerLogs.Text = "";

            // 
            // pnlServerBroadcast
            // 
            this.pnlServerBroadcast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlServerBroadcast.Controls.Add(this.btnServerBroadcast);
            this.pnlServerBroadcast.Controls.Add(this.txtServerAnnouncement);
            this.pnlServerBroadcast.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlServerBroadcast.Location = new System.Drawing.Point(0, 550);
            this.pnlServerBroadcast.Name = "pnlServerBroadcast";
            this.pnlServerBroadcast.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlServerBroadcast.Size = new System.Drawing.Size(1032, 50);
            this.pnlServerBroadcast.TabIndex = 2;

            // 
            // txtServerAnnouncement
            // 
            this.txtServerAnnouncement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerAnnouncement.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtServerAnnouncement.Location = new System.Drawing.Point(12, 12);
            this.txtServerAnnouncement.Name = "txtServerAnnouncement";
            this.txtServerAnnouncement.PlaceholderText = "Tüm istemcilere genel sunucu duyurusu yazınız...";
            this.txtServerAnnouncement.Size = new System.Drawing.Size(840, 24);
            this.txtServerAnnouncement.TabIndex = 0;

            // 
            // btnServerBroadcast
            // 
            this.btnServerBroadcast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServerBroadcast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btnServerBroadcast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServerBroadcast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerBroadcast.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnServerBroadcast.ForeColor = System.Drawing.Color.White;
            this.btnServerBroadcast.Location = new System.Drawing.Point(860, 10);
            this.btnServerBroadcast.Name = "btnServerBroadcast";
            this.btnServerBroadcast.Size = new System.Drawing.Size(160, 30);
            this.btnServerBroadcast.TabIndex = 1;
            this.btnServerBroadcast.Text = "📢 Duyuru Yayınla";
            this.btnServerBroadcast.UseVisualStyleBackColor = false;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(920, 560);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İstemci-Sunucu Chat Uygulaması - YMH219 Nesne Tabanlı Programlama";
            this.tabMain.ResumeLayout(false);
            this.tabClient.ResumeLayout(false);
            this.tabServer.ResumeLayout(false);
            this.pnlClientConnect.ResumeLayout(false);
            this.pnlClientConnect.PerformLayout();
            this.splitClient.Panel1.ResumeLayout(false);
            this.splitClient.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitClient)).EndInit();
            this.splitClient.ResumeLayout(false);
            this.pnlUserList.ResumeLayout(false);
            this.pnlClientSend.ResumeLayout(false);
            this.pnlClientSend.PerformLayout();
            this.pnlServerHeader.ResumeLayout(false);
            this.pnlServerHeader.PerformLayout();
            this.splitServer.Panel1.ResumeLayout(false);
            this.splitServer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitServer)).EndInit();
            this.splitServer.ResumeLayout(false);
            this.grpConnectedClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServerClients)).EndInit();
            this.grpServerLogs.ResumeLayout(false);
            this.pnlServerBroadcast.ResumeLayout(false);
            this.pnlServerBroadcast.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
