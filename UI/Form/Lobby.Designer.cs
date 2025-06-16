namespace UI
{
    partial class Lobby
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lobby));
            label1 = new Label();
            panel3 = new Panel();
            label3 = new Label();
            panelStatus = new FlowLayoutPanel();
            panelTaoPhong = new Panel();
            label15 = new Label();
            label6 = new Label();
            panelThamGia = new Panel();
            label14 = new Label();
            label5 = new Label();
            timeReload = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            label7 = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            label4 = new Label();
            label8 = new Label();
            label9 = new Label();
            panel1 = new Panel();
            panel9 = new Panel();
            panel8 = new Panel();
            label13 = new Label();
            panel7 = new Panel();
            label12 = new Label();
            panel6 = new Panel();
            label11 = new Label();
            panel5 = new Panel();
            label10 = new Label();
            panel10 = new Panel();
            panel11 = new Panel();
            panel3.SuspendLayout();
            panelTaoPhong.SuspendLayout();
            panelThamGia.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(180, 33);
            label1.TabIndex = 0;
            label1.Text = "Chat Rooms";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(3, 4);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(332, 63);
            panel3.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.ForeColor = Color.FromArgb(124, 192, 237);
            label3.Location = new Point(15, 42);
            label3.Name = "label3";
            label3.Size = new Size(155, 18);
            label3.TabIndex = 1;
            label3.Text = "Connect with friends";
            // 
            // panelStatus
            // 
            panelStatus.AutoScroll = true;
            panelStatus.BackColor = Color.Transparent;
            panelStatus.Location = new Point(3, 192);
            panelStatus.Margin = new Padding(3, 4, 3, 4);
            panelStatus.Name = "panelStatus";
            panelStatus.Size = new Size(362, 534);
            panelStatus.TabIndex = 3;
            // 
            // panelTaoPhong
            // 
            panelTaoPhong.BackColor = Color.FromArgb(17, 185, 126);
            panelTaoPhong.Controls.Add(label15);
            panelTaoPhong.Controls.Add(label6);
            panelTaoPhong.Cursor = Cursors.Hand;
            panelTaoPhong.Location = new Point(844, 450);
            panelTaoPhong.Margin = new Padding(3, 4, 3, 4);
            panelTaoPhong.Name = "panelTaoPhong";
            panelTaoPhong.Size = new Size(220, 85);
            panelTaoPhong.TabIndex = 2;
            panelTaoPhong.Click += CreateZoom;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Arial", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label15.ForeColor = SystemColors.ButtonHighlight;
            label15.Location = new Point(21, 23);
            label15.Name = "label15";
            label15.Size = new Size(37, 40);
            label15.TabIndex = 6;
            label15.Text = "+";
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(45, 7);
            label6.Name = "label6";
            label6.Size = new Size(134, 70);
            label6.TabIndex = 6;
            label6.Text = "Tạo Phòng Mới";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.Click += CreateZoom;
            // 
            // panelThamGia
            // 
            panelThamGia.BackColor = Color.FromArgb(56, 126, 244);
            panelThamGia.Controls.Add(label14);
            panelThamGia.Controls.Add(label5);
            panelThamGia.Cursor = Cursors.Hand;
            panelThamGia.Location = new Point(601, 450);
            panelThamGia.Margin = new Padding(3, 4, 3, 4);
            panelThamGia.Name = "panelThamGia";
            panelThamGia.Size = new Size(220, 85);
            panelThamGia.TabIndex = 1;
            panelThamGia.Click += JoinRoom;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label14.ForeColor = SystemColors.ButtonHighlight;
            label14.Location = new Point(23, 32);
            label14.Name = "label14";
            label14.Size = new Size(28, 21);
            label14.TabIndex = 5;
            label14.Text = "@";
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(35, 7);
            label5.Name = "label5";
            label5.Size = new Size(149, 70);
            label5.TabIndex = 4;
            label5.Text = "Tham Gia Phòng";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Click += JoinRoom;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.ForeColor = Color.FromArgb(28, 38, 52);
            label2.Location = new Point(443, 27);
            label2.Name = "label2";
            label2.Size = new Size(423, 40);
            label2.TabIndex = 5;
            label2.Text = "Welcome To Chat Rooms";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label7.ForeColor = Color.FromArgb(103, 111, 123);
            label7.Location = new Point(452, 74);
            label7.Name = "label7";
            label7.Size = new Size(405, 19);
            label7.TabIndex = 6;
            label7.Text = "Connect with friends and join interesting conversations";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(219, 234, 254);
            panel2.Controls.Add(panel4);
            panel2.Location = new Point(755, 137);
            panel2.Name = "panel2";
            panel2.Size = new Size(148, 148);
            panel2.TabIndex = 7;
            // 
            // panel4
            // 
            panel4.BackgroundImage = (Image)resources.GetObject("panel4.BackgroundImage");
            panel4.Location = new Point(42, 43);
            panel4.Name = "panel4";
            panel4.Size = new Size(64, 64);
            panel4.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label4.ForeColor = Color.FromArgb(28, 38, 52);
            label4.Location = new Point(699, 300);
            label4.Name = "label4";
            label4.Size = new Size(259, 33);
            label4.TabIndex = 8;
            label4.Text = "Start Chating Now";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 9F);
            label8.ForeColor = Color.FromArgb(103, 111, 123);
            label8.Location = new Point(674, 355);
            label8.Name = "label8";
            label8.Size = new Size(319, 17);
            label8.TabIndex = 9;
            label8.Text = "Join an existing room or create your own to start\r\n";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 9F);
            label9.ForeColor = Color.FromArgb(103, 111, 123);
            label9.Location = new Point(755, 385);
            label9.Name = "label9";
            label9.Size = new Size(154, 17);
            label9.TabIndex = 10;
            label9.Text = "connecting with others\r\n";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 60, 78);
            panel1.Controls.Add(panel9);
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panelStatus);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(338, 700);
            panel1.TabIndex = 11;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(52, 63, 79);
            panel9.Location = new Point(0, 74);
            panel9.Name = "panel9";
            panel9.Size = new Size(338, 2);
            panel9.TabIndex = 13;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(52, 63, 79);
            panel8.Location = new Point(0, 140);
            panel8.Name = "panel8";
            panel8.Size = new Size(338, 2);
            panel8.TabIndex = 12;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(103, 111, 123);
            label13.Location = new Point(18, 170);
            label13.Name = "label13";
            label13.Size = new Size(71, 18);
            label13.TabIndex = 16;
            label13.Text = "All Users";
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(37, 99, 235);
            panel7.Controls.Add(label12);
            panel7.Location = new Point(221, 91);
            panel7.Name = "panel7";
            panel7.Size = new Size(97, 36);
            panel7.TabIndex = 15;
            // 
            // label12
            // 
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label12.ForeColor = SystemColors.ButtonHighlight;
            label12.Location = new Point(0, 0);
            label12.Name = "label12";
            label12.Size = new Size(97, 36);
            label12.TabIndex = 14;
            label12.Text = "All";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(55, 65, 81);
            panel6.Controls.Add(label11);
            panel6.Location = new Point(118, 91);
            panel6.Name = "panel6";
            panel6.Size = new Size(97, 36);
            panel6.TabIndex = 15;
            // 
            // label11
            // 
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label11.ForeColor = SystemColors.ButtonHighlight;
            label11.Location = new Point(0, 0);
            label11.Name = "label11";
            label11.Size = new Size(97, 36);
            label11.TabIndex = 14;
            label11.Text = "Offline";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(55, 65, 81);
            panel5.Controls.Add(label10);
            panel5.Location = new Point(15, 91);
            panel5.Name = "panel5";
            panel5.Size = new Size(97, 36);
            panel5.TabIndex = 12;
            // 
            // label10
            // 
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label10.ForeColor = SystemColors.ButtonHighlight;
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(97, 36);
            label10.TabIndex = 14;
            label10.Text = "Online";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(238, 239, 242);
            panel10.Location = new Point(338, 110);
            panel10.Name = "panel10";
            panel10.Size = new Size(994, 1);
            panel10.TabIndex = 13;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(238, 239, 242);
            panel11.Location = new Point(338, 620);
            panel11.Name = "panel11";
            panel11.Size = new Size(994, 1);
            panel11.TabIndex = 14;
            // 
            // Lobby
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1332, 700);
            Controls.Add(panel11);
            Controls.Add(panel10);
            Controls.Add(panel1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(panelTaoPhong);
            Controls.Add(panel2);
            Controls.Add(panelThamGia);
            Controls.Add(label7);
            Controls.Add(label2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Lobby";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lobby";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panelTaoPhong.ResumeLayout(false);
            panelTaoPhong.PerformLayout();
            panelThamGia.ResumeLayout(false);
            panelThamGia.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Panel panel3;
        private FlowLayoutPanel panelStatus;
        private Panel panelTaoPhong;
        private Panel panelThamGia;
        private Label label5;
        private Label label6;
        private System.Windows.Forms.Timer timeReload;
        private Label label2;
        private Label label3;
        private Label label7;
        private Panel panel2;
        private Panel panel4;
        private Label label4;
        private Label label8;
        private Label label9;
        private Panel panel1;
        private Panel panel8;
        private Label label13;
        private Panel panel7;
        private Label label12;
        private Panel panel6;
        private Label label11;
        private Panel panel5;
        private Label label10;
        private Panel panel9;
        private Panel panel10;
        private Panel panel11;
        private Label label14;
        private Label label15;
    }
}