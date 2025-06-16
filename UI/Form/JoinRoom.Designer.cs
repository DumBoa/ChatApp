namespace UI
{
    partial class JoinRoom
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
            XacNhanButton = new Panel();
            label1 = new Label();
            txtNameRoom = new TextBox();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            panel2 = new Panel();
            txtPass = new TextBox();
            label5 = new Label();
            panel4 = new Panel();
            XacNhanButton.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // XacNhanButton
            // 
            XacNhanButton.BackColor = Color.RoyalBlue;
            XacNhanButton.Controls.Add(label1);
            XacNhanButton.Cursor = Cursors.Hand;
            XacNhanButton.Location = new Point(235, 416);
            XacNhanButton.Name = "XacNhanButton";
            XacNhanButton.Size = new Size(181, 43);
            XacNhanButton.TabIndex = 14;
            XacNhanButton.Click += btnXacNhan_Click;
            // 
            // label1
            // 
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(175, 25);
            label1.TabIndex = 0;
            label1.Text = "Xác Nhận";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += btnXacNhan_Click;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(120, 46);
            label2.Name = "label2";
            label2.Size = new Size(232, 38);
            label2.TabIndex = 15;
            label2.Text = "Gia Nhập Phòng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(45, 125);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 18;
            label3.Text = "Tên Phòng";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.Controls.Add(txtNameRoom);
            panel1.Location = new Point(45, 148);
            panel1.Name = "panel1";
            panel1.Size = new Size(371, 42);
            panel1.TabIndex = 17;
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
            label4.Click += btnThoat_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.Controls.Add(txtPass);
            panel2.Location = new Point(45, 238);
            panel2.Name = "panel2";
            panel2.Size = new Size(371, 42);
            panel2.TabIndex = 19;
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
            label5.Location = new Point(45, 215);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 20;
            label5.Text = "Mật Khẩu";
            // 
            // panel4
            // 
            panel4.BackColor = Color.RoyalBlue;
            panel4.Controls.Add(label4);
            panel4.Cursor = Cursors.Hand;
            panel4.Location = new Point(45, 416);
            panel4.Name = "panel4";
            panel4.Size = new Size(184, 43);
            panel4.TabIndex = 16;
            panel4.Click += btnThoat_Click;
            // 
            // JoinRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(474, 519);
            Controls.Add(XacNhanButton);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(label5);
            Controls.Add(panel4);
            Name = "JoinRoom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JoinRoom";
            XacNhanButton.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel XacNhanButton;
        private Label label1;
        private TextBox txtNameRoom;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Label label4;
        private Panel panel2;
        private TextBox txtPass;
        private Label label5;
        private Panel panel4;
    }
}