namespace UI
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            panelTenDangNhap = new Panel();
            txtUsername = new TextBox();
            panelMatKhau = new Panel();
            txtPassword = new TextBox();
            label5 = new Label();
            checkBox1 = new CheckBox();
            SignInButton = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            LoginButton = new Button();
            LoginPanel = new Panel();
            panel1.SuspendLayout();
            panelTenDangNhap.SuspendLayout();
            panelMatKhau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            LoginPanel.SuspendLayout();
           
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(34, 161);
            panel1.Name = "panel1";
            panel1.Size = new Size(568, 92);
            panel1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlDark;
            label3.Location = new Point(18, 62);
            label3.Name = "label3";
            label3.Size = new Size(242, 21);
            label3.TabIndex = 3;
            label3.Text = "Sign in to get more information";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(429, 51);
            label2.TabIndex = 0;
            label2.Text = "Welcome to Zessenger";
            // 
            // panelTenDangNhap
            // 
            panelTenDangNhap.BackColor = Color.WhiteSmoke;
            panelTenDangNhap.BackgroundImageLayout = ImageLayout.None;
            panelTenDangNhap.Controls.Add(txtUsername);
            panelTenDangNhap.Location = new Point(37, 273);
            panelTenDangNhap.Name = "panelTenDangNhap";
            panelTenDangNhap.Size = new Size(355, 49);
            panelTenDangNhap.TabIndex = 3;
            panelTenDangNhap.Paint += panelTenDangNhap_Paint;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.WhiteSmoke;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.Gray;
            txtUsername.Location = new Point(33, 15);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(293, 21);
            txtUsername.TabIndex = 0;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // panelMatKhau
            // 
            panelMatKhau.BackColor = Color.WhiteSmoke;
            panelMatKhau.Controls.Add(txtPassword);
            panelMatKhau.Location = new Point(37, 341);
            panelMatKhau.Name = "panelMatKhau";
            panelMatKhau.Size = new Size(355, 47);
            panelMatKhau.TabIndex = 4;
            panelMatKhau.Paint += panelMatKhau_Paint;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.WhiteSmoke;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Location = new Point(33, 14);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(293, 21);
            txtPassword.TabIndex = 1;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(274, 404);
            label5.Name = "label5";
            label5.Size = new Size(125, 20);
            label5.TabIndex = 6;
            label5.Text = "Forgot Password";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(37, 403);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(102, 24);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Remember";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // SignInButton
            // 
            SignInButton.Cursor = Cursors.Hand;
            SignInButton.FlatStyle = FlatStyle.Flat;
            SignInButton.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SignInButton.Location = new Point(255, 449);
            SignInButton.Name = "SignInButton";
            SignInButton.Size = new Size(137, 37);
            SignInButton.TabIndex = 11;
            SignInButton.Text = "Sign In";
            SignInButton.UseVisualStyleBackColor = true;
            SignInButton.Click += SignInButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(34, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 50);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Georgia", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(79, 21);
            label1.Name = "label1";
            label1.Size = new Size(215, 50);
            label1.TabIndex = 14;
            label1.Text = "Zessenger";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.FromArgb(99, 74, 157);
            LoginButton.BackgroundImageLayout = ImageLayout.None;
            LoginButton.Cursor = Cursors.Hand;
            LoginButton.FlatStyle = FlatStyle.Flat;
            LoginButton.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginButton.ForeColor = SystemColors.Window;
            LoginButton.Location = new Point(15, 3);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(181, 34);
            LoginButton.TabIndex = 15;
            LoginButton.Text = "Login\r\n";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // LoginPanel
            // 
            LoginPanel.BackColor = Color.FromArgb(99, 74, 157);
            LoginPanel.Controls.Add(LoginButton);
            LoginPanel.Location = new Point(37, 449);
            LoginPanel.Name = "LoginPanel";
            LoginPanel.Size = new Size(212, 40);
            LoginPanel.TabIndex = 16;
            LoginPanel.Paint += LoginPanel_Paint;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1206, 656);
            Controls.Add(LoginPanel);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(SignInButton);
            Controls.Add(checkBox1);
            Controls.Add(label5);
            Controls.Add(panelMatKhau);
            Controls.Add(panelTenDangNhap);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zessenger";
            WindowState = FormWindowState.Minimized;
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelTenDangNhap.ResumeLayout(false);
            panelTenDangNhap.PerformLayout();
            panelMatKhau.ResumeLayout(false);
            panelMatKhau.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            LoginPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Panel panelTenDangNhap;
        private Panel panelMatKhau;
        private Label label5;
        private CheckBox checkBox1;
        private Button SignInButton;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private PictureBox pictureBox1;
        private Label label1;
        private Button LoginButton;
        private Panel LoginPanel;
    }
}
