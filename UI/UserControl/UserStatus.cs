using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UI
{
    public partial class UserOnlineStatus : UserControl
    {
        private static readonly Random rand = new Random();

        public UserOnlineStatus()
        {
            InitializeComponent();
            MakeCirclePanel(panel2);
            Border();
            RandomizeLabelText();
        }

        public Label name
        {
            get { return Username; }
            set { Username = value; }
        }
        public Label status
        {
            get { return Status; }
            set { Status = value; }
        }

        public void SetUser(string username, string statusText)
        {
            name.Text = username;
            status.Text = statusText;
        }

        public void MakeCirclePanel(Panel panel)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, panel.Width, panel.Height);
            panel.Region = new Region(path);

            panel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Random rnd = new Random();
                Color color1 = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                Color color2 = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    panel.ClientRectangle, color1, color2, LinearGradientMode.ForwardDiagonal))
                {
                    e.Graphics.FillEllipse(brush, 0, 0, panel.Width, panel.Height);
                }
            };

            panel.Invalidate(); 
        }
        private void BoGocPanel(Control control, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(control.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(control.Width - cornerRadius, control.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, control.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }

        private void Border()
        {
            BoGocPanel(panel3, 20);
        }

        private void RandomizeLabelText()
        {
            string[] texts = { "A", "B", "X", "N", "M", "Z", "E", "U", "O" };
            randomText.Text = texts[rand.Next(texts.Length)];
        }
    }
}
