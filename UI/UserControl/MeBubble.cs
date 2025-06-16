
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace MeBubble
{
    public partial class MeBubble : UserControl
    {
        public byte[] FileData { get; set; } 

        public MeBubble()
        {
            InitializeComponent();
            this.Click += MeBubble_Click;
            if (label2 != null) label2.Click += MeBubble_Click;
        }

        private void MeBubble_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Body) && Body.StartsWith("📁 File:") && FileData != null)
            {
                string fileName = Body.Replace("📁 File:", "").Trim();
                OpenSaveDialog(fileName, FileData);
            }
        }

        private void OpenSaveDialog(string fileName, byte[] fileData)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Chọn thư mục để lưu file";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = Path.Combine(folderDialog.SelectedPath, fileName);
                    File.WriteAllBytes(savePath, fileData);
                    MessageBox.Show($"File đã được lưu tại {savePath}");
                }
            }
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