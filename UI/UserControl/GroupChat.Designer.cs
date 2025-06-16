namespace UI
{
    partial class GroupChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupChat));
            panel1 = new Panel();
            txtRoomName = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtRoomName);
            panel1.Controls.Add(panel2);
            panel1.Cursor = Cursors.Hand;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(246, 80);
            panel1.TabIndex = 1;
            // 
            // txtRoomName
            // 
            txtRoomName.AutoSize = true;
            txtRoomName.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtRoomName.Location = new Point(83, 25);
            txtRoomName.Name = "txtRoomName";
            txtRoomName.Size = new Size(123, 26);
            txtRoomName.TabIndex = 1;
            txtRoomName.Text = "RoomName";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.Location = new Point(13, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(48, 48);
            panel2.TabIndex = 0;
            // 
            // GroupChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "GroupChat";
            Size = new Size(247, 80);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label txtRoomName;
        private Panel panel2;
    }
}
