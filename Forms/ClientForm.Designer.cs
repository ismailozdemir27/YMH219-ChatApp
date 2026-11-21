namespace ChatApp.Forms
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;

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

            this.pnlClientConnect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitClient)).BeginInit();
            this.splitClient.Panel1.SuspendLayout();
            this.splitClient.Panel2.SuspendLayout();
            this.splitClient.SuspendLayout();
            this.pnlUserList.SuspendLayout();
            this.pnlClientSend.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlClientConnect
            // 
            this.pnlClientConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
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
            this.pnlClientConnect.Size = new System.Drawing.Size(860, 54);
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
            this.txtClientUser.Text = "Arkadas_1";

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
            this.splitClient.Size = new System.Drawing.Size(860, 476);
            this.splitClient.SplitterDistance = 620;
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
            this.rtbChatMessages.Size = new System.Drawing.Size(602, 458);
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
            this.pnlUserList.Size = new System.Drawing.Size(218, 458);
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
            this.lblUsersHeader.Size = new System.Drawing.Size(216, 30);
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
            this.lstOnlineUsers.Size = new System.Drawing.Size(216, 426);
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
            this.pnlClientSend.Location = new System.Drawing.Point(0, 530);
            this.pnlClientSend.Name = "pnlClientSend";
            this.pnlClientSend.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlClientSend.Size = new System.Drawing.Size(860, 50);
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
            this.txtMessageInput.PlaceholderText = "Mesajınızı yazınız (Enter ile gönder)...";
            this.txtMessageInput.Size = new System.Drawing.Size(425, 24);
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
            this.btnSendMessage.Location = new System.Drawing.Point(608, 10);
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
            this.btnSaveHistory.Location = new System.Drawing.Point(716, 10);
            this.btnSaveHistory.Name = "btnSaveHistory";
            this.btnSaveHistory.Size = new System.Drawing.Size(130, 30);
            this.btnSaveHistory.TabIndex = 3;
            this.btnSaveHistory.Text = "💾 Kaydet";
            this.btnSaveHistory.UseVisualStyleBackColor = false;

            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 580);
            this.Controls.Add(this.splitClient);
            this.Controls.Add(this.pnlClientSend);
            this.Controls.Add(this.pnlClientConnect);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(760, 480);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sohbet İstemcisi - ChatApp";
            this.pnlClientConnect.ResumeLayout(false);
            this.pnlClientConnect.PerformLayout();
            this.splitClient.Panel1.ResumeLayout(false);
            this.splitClient.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitClient)).EndInit();
            this.splitClient.ResumeLayout(false);
            this.pnlUserList.ResumeLayout(false);
            this.pnlClientSend.ResumeLayout(false);
            this.pnlClientSend.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
