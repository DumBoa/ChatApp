namespace UI
{
    partial class PrivateChat
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
            panel1 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            randomText = new Label();
            Status = new Label();
            Username = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Cursor = Cursors.Hand;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(338, 80);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(Status);
            panel3.Controls.Add(Username);
            panel3.Location = new Point(21, 7);
            panel3.Name = "panel3";
            panel3.Size = new Size(273, 65);
            panel3.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(randomText);
            panel2.Location = new Point(14, 8);
            panel2.Name = "panel2";
            panel2.Size = new Size(48, 48);
            panel2.TabIndex = 0;
            // 
            // randomText
            // 
            randomText.Dock = DockStyle.Fill;
            randomText.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            randomText.ForeColor = SystemColors.ButtonHighlight;
            randomText.Location = new Point(0, 0);
            randomText.Name = "randomText";
            randomText.Size = new Size(48, 48);
            randomText.TabIndex = 0;
            randomText.Text = "T";
            randomText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Status
            // 
            Status.AutoSize = true;
            Status.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            Status.Location = new Point(71, 38);
            Status.Name = "Status";
            Status.Size = new Size(21, 20);
            Status.TabIndex = 2;
            Status.Text = "--";
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Font = new Font("Arial", 13.8F, FontStyle.Bold);
            Username.ForeColor = SystemColors.ActiveCaptionText;
            Username.Location = new Point(68, 10);
            Username.Name = "Username";
            Username.Size = new Size(85, 27);
            Username.TabIndex = 1;
            Username.Text = "Hoàng";
            // 
            // PrivateChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "PrivateChat";
            Size = new Size(338, 80);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Label randomText;
        private Label Status;
        private Label Username;
    }
}
