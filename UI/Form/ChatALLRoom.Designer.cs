namespace UI
{
    partial class ChatALLRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatALLRoom));
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel3 = new Panel();
            btnSend = new Panel();
            Typing = new TypingBox();
            panelChat = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(79, 70, 229);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1289, 72);
            panel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(111, 40);
            label2.Name = "label2";
            label2.Size = new Size(102, 17);
            label2.TabIndex = 4;
            label2.Text = "Đang hoạt động";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(111, 12);
            label1.Name = "label1";
            label1.Size = new Size(186, 20);
            label1.TabIndex = 3;
            label1.Text = "Hệ Thống Chat Admin";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(label3);
            panel2.Location = new Point(57, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(48, 48);
            panel2.TabIndex = 2;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.ForeColor = Color.FromArgb(79, 70, 229);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(48, 48);
            label3.TabIndex = 0;
            label3.Text = "U";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(57, 78);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(288, 205);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.Controls.Add(btnSend);
            panel3.Controls.Add(Typing);
            panel3.Location = new Point(0, 459);
            panel3.Name = "panel3";
            panel3.Size = new Size(1289, 92);
            panel3.TabIndex = 5;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.Transparent;
            btnSend.BackgroundImage = (Image)resources.GetObject("btnSend.BackgroundImage");
            btnSend.Location = new Point(1163, 20);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(48, 48);
            btnSend.TabIndex = 9;
            // 
            // Typing
            // 
            Typing.BackColor = Color.WhiteSmoke;
            Typing.Location = new Point(71, 20);
            Typing.Name = "Typing";
            Typing.Size = new Size(1049, 47);
            Typing.TabIndex = 0;
            Typing.Value = "";
            // 
            // panelChat
            // 
            panelChat.AutoScroll = true;
            panelChat.Location = new Point(71, 78);
            panelChat.Name = "panelChat";
            panelChat.Size = new Size(1140, 375);
            panelChat.TabIndex = 4;
            // 
            // ChatALLRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1288, 551);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panelChat);
            Name = "ChatALLRoom";
            Text = "ChatALLRoom";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel3;
        private TypingBox Typing;
        private FlowLayoutPanel panelChat;
        private Panel btnSend;
    }
}