
namespace YouBubble
{
    public partial class YouBubble : UserControl
    {

        public YouBubble()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string uName
        {
            get { return UserName.Text; }
            set { UserName.Text = value; }
        }
        public string Time
        {
            get { return lblTime.Text; }
            set { lblTime.Text = value; }
        }
        public string Body
        {
            get { return label2.Text; }
            set { label2.Text = value; }
        }
        public Image UserImage
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public Cursor CharImageCursor
        {
            get { return pictureBox1.Cursor; }
            set { pictureBox1.Cursor = value; }
        }

        public Cursor ChatTextCursor
        {
            get {return label2.Cursor; }
            set {label2.Cursor = value; }
        }

        public Color MsgColor
        {
            get
            {
                return label2.BackColor;
            }
            set
            {
                label2.BackColor = value;
            }
        }

        public Color MsgTextColor
        {
            get
            {
                return label2.ForeColor;
            }
            set
            {
                label2.ForeColor = value;
            }
        }

        private void Bubble_Load(object sender, EventArgs e)
        {

        }
    }
}