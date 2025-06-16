using System.Drawing.Drawing2D;


namespace UI
{
    public partial class TypingBox : UserControl
    {
        public TypingBox()
        {
            InitializeComponent();
        }
        public string Value
        {
            get
            { return ChatText.Text; }
            set
            { ChatText.Text = value; }
        }
        public delegate void TypingTextChanged(string newVal);
        public delegate void EmojiClicked(object sender, EventArgs e);
        public delegate void AttachmentClicked(object sender, EventArgs e);
        public delegate void HitEnter(object sender, EventArgs e);

        public event TypingTextChanged OnTypingTextChanged;
        public event EmojiClicked OnEmojiClicked;
        public event AttachmentClicked OnAttachmentClicked;
        public event HitEnter OnHitEnter;

        bool isEmpty = true;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            OnTypingTextChanged?.Invoke(ChatText.Text);

        }


        protected override void OnPaint(PaintEventArgs e)
        {
          /*  GraphicsPath gr = RoundedRectangle.Create(this.ClientRectangle, 10, RoundedRectangle.RectangleCorners.All);
            this.Region = new Region(gr);

            base.OnPaint(e);*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OnAttachmentClicked?.Invoke(sender, e);
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            ChatText.ForeColor = Color.WhiteSmoke;
            if (isEmpty || ChatText.Text == "Type here...")
            {
                ChatText.Text = "";
                isEmpty = false;
            }
            else
            {
                isEmpty = false;
            }
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            ChatText.ForeColor = SystemColors.GradientActiveCaption;
            if (string.IsNullOrEmpty(ChatText.Text) || ChatText.Text == "Type here...")
            {
                isEmpty = true;
                ChatText.Text = "Type here...";


            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.Handled = true;
                OnHitEnter?.Invoke(sender, e);

            }
        }
    }
}
