namespace MeBubble
{
    partial class MeBubble
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeBubble));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            label2 = new Label();
            UserName = new Label();
            lblTime = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(58, 84);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(4, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 48);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Location = new Point(61, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(186, 30);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Comic Sans MS", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(61, 28);
            label2.MaximumSize = new Size(750, 0);
            label2.Name = "label2";
            label2.Size = new Size(24, 24);
            label2.TabIndex = 0;
            label2.Text = "--";
            // 
            // UserName
            // 
            UserName.AutoSize = true;
            UserName.BackColor = Color.Transparent;
            UserName.Font = new Font("Comic Sans MS", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserName.Location = new Point(61, 3);
            UserName.Name = "UserName";
            UserName.Size = new Size(136, 25);
            UserName.TabIndex = 2;
            UserName.Text = "Đào Huy Hoàng";
            // 
            // lblTime
            // 
            lblTime.BackColor = Color.Transparent;
            lblTime.Font = new Font("Comic Sans MS", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.Location = new Point(212, 3);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(542, 25);
            lblTime.TabIndex = 3;
            lblTime.Text = "--";
            // 
            // MeBubble
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(lblTime);
            Controls.Add(UserName);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "MeBubble";
            Size = new Size(757, 88);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private PictureBox pictureBox1;
        private Label UserName;
        private Label lblTime;
    }
}
