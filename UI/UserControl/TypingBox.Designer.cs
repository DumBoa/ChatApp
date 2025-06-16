namespace UI
{
    partial class TypingBox
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
            ChatText = new TextBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ChatText
            // 
            ChatText.BackColor = SystemColors.ButtonHighlight;
            ChatText.BorderStyle = BorderStyle.None;
            ChatText.Cursor = Cursors.IBeam;
            ChatText.Font = new Font("Comic Sans MS", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ChatText.Location = new Point(21, 10);
            ChatText.Multiline = true;
            ChatText.Name = "ChatText";
            ChatText.PlaceholderText = "Type something to send...";
            ChatText.Size = new Size(1330, 33);
            ChatText.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(ChatText);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1351, 53);
            panel1.TabIndex = 5;
            // 
            // TypingBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "TypingBox";
            Size = new Size(1351, 53);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox ChatText;
        private Panel panel1;
    }
}
