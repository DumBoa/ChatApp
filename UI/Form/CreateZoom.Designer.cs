namespace UI
{
    partial class CreateZoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateZoom));
            XacNhanButton = new Panel();
            label1 = new Label();
            txtNameRoom = new TextBox();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            txtPass = new TextBox();
            label5 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            txtRePass = new TextBox();
            panel4 = new Panel();
            XacNhanButton.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // XacNhanButton
            // 
            XacNhanButton.BackColor = Color.RoyalBlue;
            XacNhanButton.Controls.Add(label1);
            XacNhanButton.Cursor = Cursors.Hand;
            XacNhanButton.Location = new Point(236, 419);
            XacNhanButton.Name = "XacNhanButton";
            XacNhanButton.Size = new Size(178, 43);
            XacNhanButton.TabIndex = 0;
            XacNhanButton.Click += XacNhanButton_Click;
            XacNhanButton.Paint += rePaintBorder;
            // 
            // label1
            // 
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(168, 25);
            label1.TabIndex = 0;
            label1.Text = "Xác Nhận";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += XacNhanButton_Click;
            // 
            // txtNameRoom
            // 
            txtNameRoom.BackColor = SystemColors.ButtonFace;
            txtNameRoom.BorderStyle = BorderStyle.None;
            txtNameRoom.Location = new Point(15, 10);
            txtNameRoom.Name = "txtNameRoom";
            txtNameRoom.PlaceholderText = "Nhập tên phòng mới";
            txtNameRoom.Size = new Size(338, 20);
            txtNameRoom.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.Controls.Add(txtNameRoom);
            panel1.Location = new Point(46, 151);
            panel1.Name = "panel1";
            panel1.Size = new Size(368, 42);
            panel1.TabIndex = 2;
            panel1.Paint += rePaintBorder;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(46, 128);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 3;
            label3.Text = "Tên Phòng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(121, 49);
            label2.Name = "label2";
            label2.Size = new Size(219, 38);
            label2.TabIndex = 0;
            label2.Text = "Tạo Phòng Mới";
            // 
            // label4
            // 
            label4.Cursor = Cursors.Hand;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(0, 10);
            label4.Name = "label4";
            label4.Size = new Size(181, 20);
            label4.TabIndex = 10;
            label4.Text = "Quay Lại";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Click += quitPanel_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.Controls.Add(txtPass);
            panel2.Location = new Point(46, 241);
            panel2.Name = "panel2";
            panel2.Size = new Size(371, 42);
            panel2.TabIndex = 3;
            // 
            // txtPass
            // 
            txtPass.BackColor = SystemColors.ButtonFace;
            txtPass.BorderStyle = BorderStyle.None;
            txtPass.Location = new Point(15, 10);
            txtPass.Name = "txtPass";
            txtPass.PlaceholderText = "Nhập Mật Khẩu";
            txtPass.Size = new Size(338, 20);
            txtPass.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(46, 218);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 11;
            label5.Text = "Mật Khẩu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(46, 305);
            label6.Name = "label6";
            label6.Size = new Size(143, 20);
            label6.TabIndex = 13;
            label6.Text = "Nhập Lại Mật Khẩu";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonFace;
            panel3.Controls.Add(txtRePass);
            panel3.Location = new Point(46, 328);
            panel3.Name = "panel3";
            panel3.Size = new Size(371, 42);
            panel3.TabIndex = 12;
            // 
            // txtRePass
            // 
            txtRePass.BackColor = SystemColors.ButtonFace;
            txtRePass.BorderStyle = BorderStyle.None;
            txtRePass.Location = new Point(15, 10);
            txtRePass.Name = "txtRePass";
            txtRePass.PlaceholderText = "Nhập lại mật khẩu";
            txtRePass.Size = new Size(338, 20);
            txtRePass.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.RoyalBlue;
            panel4.Controls.Add(label4);
            panel4.Cursor = Cursors.Hand;
            panel4.Location = new Point(46, 419);
            panel4.Name = "panel4";
            panel4.Size = new Size(184, 43);
            panel4.TabIndex = 1;
            panel4.Click += quitPanel_Click;
            // 
            // CreateZoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(474, 519);
            Controls.Add(label2);
            Controls.Add(panel4);
            Controls.Add(label6);
            Controls.Add(panel3);
            Controls.Add(label5);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(XacNhanButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateZoom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateZoom";
            XacNhanButton.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel XacNhanButton;
        private TextBox txtNameRoom;
        private Panel panel1;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
        private Panel panel2;
        private TextBox txtPass;
        private Label label5;
        private Label label6;
        private Panel panel3;
        private TextBox txtRePass;
        private Panel panel4;
    }
}