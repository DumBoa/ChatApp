namespace UI
{
    partial class HubChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HubChat));
            panel1 = new Panel();
            panel8 = new Panel();
            label5 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panelPrivateUserChat = new FlowLayoutPanel();
            label2 = new Label();
            panelBoxChat = new FlowLayoutPanel();
            label1 = new Label();
            panel4 = new Panel();
            panel16 = new Panel();
            panel15 = new Panel();
            panel12 = new Panel();
            panel10 = new Panel();
            ConvertChatAll = new Panel();
            label4 = new Label();
            label3 = new Label();
            panel5 = new Panel();
            panel7 = new Panel();
            textBox1 = new TextBox();
            panel6 = new Panel();
            lblCountUser = new Label();
            panelHideUser = new FlowLayoutPanel();
            panelChat = new FlowLayoutPanel();
            Typing = new TypingBox();
            panel9 = new Panel();
            panel18 = new Panel();
            panel17 = new Panel();
            Send = new Panel();
            timeReload = new System.Windows.Forms.Timer(components);
            panel13 = new Panel();
            panel14 = new Panel();
            panel11 = new Panel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel12.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel9.SuspendLayout();
            panel13.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1604, 40);
            panel1.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.BackgroundImage = (Image)resources.GetObject("panel8.BackgroundImage");
            panel8.Location = new Point(1804, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(32, 32);
            panel8.TabIndex = 4;
            panel8.Click += Quit_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label5.Location = new Point(14, 9);
            label5.Name = "label5";
            label5.Size = new Size(199, 23);
            label5.TabIndex = 3;
            label5.Text = "Ứng Dụng Trò Chuyện";
            // 
            // panel2
            // 
            panel2.Location = new Point(0, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(246, 125);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.Controls.Add(panelPrivateUserChat);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(panelBoxChat);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(11, 65);
            panel3.Name = "panel3";
            panel3.Size = new Size(320, 820);
            panel3.TabIndex = 2;
            // 
            // panelPrivateUserChat
            // 
            panelPrivateUserChat.AutoScroll = true;
            panelPrivateUserChat.Location = new Point(3, 281);
            panelPrivateUserChat.Name = "panelPrivateUserChat";
            panelPrivateUserChat.Size = new Size(361, 566);
            panelPrivateUserChat.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.Location = new Point(3, 246);
            label2.Name = "label2";
            label2.Size = new Size(205, 32);
            label2.TabIndex = 2;
            label2.Text = "Tin Nhắn Riêng";
            // 
            // panelBoxChat
            // 
            panelBoxChat.AutoScroll = true;
            panelBoxChat.Location = new Point(3, 37);
            panelBoxChat.Name = "panelBoxChat";
            panelBoxChat.Size = new Size(361, 196);
            panelBoxChat.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(158, 32);
            label1.TabIndex = 0;
            label1.Text = "Phòng Chat";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonHighlight;
            panel4.Controls.Add(panel16);
            panel4.Controls.Add(panel15);
            panel4.Controls.Add(panel12);
            panel4.Controls.Add(ConvertChatAll);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(858, 71);
            panel4.TabIndex = 3;
            // 
            // panel16
            // 
            panel16.BackgroundImage = (Image)resources.GetObject("panel16.BackgroundImage");
            panel16.Cursor = Cursors.Hand;
            panel16.Location = new Point(749, 9);
            panel16.Name = "panel16";
            panel16.Size = new Size(32, 32);
            panel16.TabIndex = 4;
            // 
            // panel15
            // 
            panel15.BackgroundImage = (Image)resources.GetObject("panel15.BackgroundImage");
            panel15.Cursor = Cursors.Hand;
            panel15.Location = new Point(679, 9);
            panel15.Name = "panel15";
            panel15.Size = new Size(32, 32);
            panel15.TabIndex = 3;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(59, 130, 246);
            panel12.Controls.Add(panel10);
            panel12.Location = new Point(10, 8);
            panel12.Name = "panel12";
            panel12.Size = new Size(48, 48);
            panel12.TabIndex = 2;
            // 
            // panel10
            // 
            panel10.BackgroundImage = (Image)resources.GetObject("panel10.BackgroundImage");
            panel10.Location = new Point(8, 8);
            panel10.Name = "panel10";
            panel10.Size = new Size(32, 32);
            panel10.TabIndex = 3;
            // 
            // ConvertChatAll
            // 
            ConvertChatAll.BackgroundImage = (Image)resources.GetObject("ConvertChatAll.BackgroundImage");
            ConvertChatAll.Cursor = Cursors.Hand;
            ConvertChatAll.Location = new Point(815, 8);
            ConvertChatAll.Name = "ConvertChatAll";
            ConvertChatAll.Size = new Size(32, 32);
            ConvertChatAll.TabIndex = 1;
            ConvertChatAll.Click += OpenAdminChat;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 39);
            label4.Name = "label4";
            label4.Size = new Size(90, 17);
            label4.TabIndex = 0;
            label4.Text = "-- Thành Viên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.Location = new Point(64, 8);
            label3.Name = "label3";
            label3.Size = new Size(181, 32);
            label3.TabIndex = 0;
            label3.Text = "Phòng Chung";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ButtonHighlight;
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(panelHideUser);
            panel5.Location = new Point(1243, 65);
            panel5.Name = "panel5";
            panel5.Size = new Size(336, 820);
            panel5.TabIndex = 3;
            // 
            // panel7
            // 
            panel7.BackColor = Color.WhiteSmoke;
            panel7.Controls.Add(textBox1);
            panel7.Location = new Point(8, 60);
            panel7.Name = "panel7";
            panel7.Size = new Size(325, 39);
            panel7.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.WhiteSmoke;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(16, 11);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Tìm Kiếm Thành Viên";
            textBox1.Size = new Size(300, 18);
            textBox1.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblCountUser);
            panel6.Location = new Point(5, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(328, 51);
            panel6.TabIndex = 3;
            // 
            // lblCountUser
            // 
            lblCountUser.AutoSize = true;
            lblCountUser.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblCountUser.Location = new Point(3, 9);
            lblCountUser.Name = "lblCountUser";
            lblCountUser.Size = new Size(155, 32);
            lblCountUser.TabIndex = 6;
            lblCountUser.Text = "Thành Viên";
            // 
            // panelHideUser
            // 
            panelHideUser.AutoScroll = true;
            panelHideUser.Location = new Point(3, 105);
            panelHideUser.Name = "panelHideUser";
            panelHideUser.Size = new Size(358, 742);
            panelHideUser.TabIndex = 2;
            // 
            // panelChat
            // 
            panelChat.AutoScroll = true;
            panelChat.Location = new Point(3, 78);
            panelChat.Name = "panelChat";
            panelChat.Size = new Size(858, 667);
            panelChat.TabIndex = 4;
            // 
            // Typing
            // 
            Typing.Location = new Point(108, 10);
            Typing.Name = "Typing";
            Typing.Size = new Size(668, 46);
            Typing.TabIndex = 5;
            Typing.Value = "";
            // 
            // panel9
            // 
            panel9.BackColor = SystemColors.ButtonHighlight;
            panel9.Controls.Add(panel18);
            panel9.Controls.Add(panel17);
            panel9.Controls.Add(Send);
            panel9.Controls.Add(Typing);
            panel9.Location = new Point(2, 751);
            panel9.Name = "panel9";
            panel9.Size = new Size(858, 67);
            panel9.TabIndex = 6;
            // 
            // panel18
            // 
            panel18.BackgroundImage = (Image)resources.GetObject("panel18.BackgroundImage");
            panel18.Cursor = Cursors.Hand;
            panel18.Location = new Point(70, 15);
            panel18.Name = "panel18";
            panel18.Size = new Size(32, 32);
            panel18.TabIndex = 4;
            panel18.Click += btnSendFile_Click;
            // 
            // panel17
            // 
            panel17.BackgroundImage = (Image)resources.GetObject("panel17.BackgroundImage");
            panel17.Cursor = Cursors.Hand;
            panel17.Location = new Point(18, 15);
            panel17.Name = "panel17";
            panel17.Size = new Size(32, 32);
            panel17.TabIndex = 8;
            // 
            // Send
            // 
            Send.BackColor = Color.Transparent;
            Send.BackgroundImage = (Image)resources.GetObject("Send.BackgroundImage");
            Send.Location = new Point(800, 8);
            Send.Name = "Send";
            Send.Size = new Size(48, 48);
            Send.TabIndex = 7;
            Send.Click += btnSend_Click;
            // 
            // panel13
            // 
            panel13.BackColor = SystemColors.ButtonHighlight;
            panel13.Controls.Add(panel14);
            panel13.Controls.Add(panel11);
            panel13.Controls.Add(panel4);
            panel13.Controls.Add(panelChat);
            panel13.Controls.Add(panel9);
            panel13.Location = new Point(353, 65);
            panel13.Name = "panel13";
            panel13.Size = new Size(863, 820);
            panel13.TabIndex = 7;
            // 
            // panel14
            // 
            panel14.BackColor = SystemColors.ControlLight;
            panel14.Location = new Point(2, 747);
            panel14.Name = "panel14";
            panel14.Size = new Size(1135, 2);
            panel14.TabIndex = 1;
            // 
            // panel11
            // 
            panel11.BackColor = SystemColors.ControlLight;
            panel11.Location = new Point(3, 75);
            panel11.Name = "panel11";
            panel11.Size = new Size(1135, 2);
            panel11.TabIndex = 0;
            // 
            // HubChat
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(232, 239, 252);
            ClientSize = new Size(1596, 896);
            Controls.Add(panel13);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "HubChat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ứng Dụng Trò Chuyện";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel12.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel9.ResumeLayout(false);
            panel13.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label2;
        private FlowLayoutPanel panelBoxChat;
        private Label label1;
        private FlowLayoutPanel panelPrivateUserChat;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private FlowLayoutPanel panelHideUser;
        private Panel panel8;
        private Label label5;
        private Label lblCountUser;
        private FlowLayoutPanel panelChat;
        private Label label4;
        private Label label3;
        private TypingBox Typing;
        private Panel panel9;
        private Panel Send;
        private System.Windows.Forms.Timer timeReload;
        private Panel ConvertChatAll;
        private Panel panel12;
        private Panel panel13;
        private Panel panel7;
        private TextBox textBox1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel14;
        private Panel panel16;
        private Panel panel15;
        private Panel panel18;
        private Panel panel17;
    }
}