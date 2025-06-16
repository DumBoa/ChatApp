using BLL;
using Model;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Themes;
namespace UI
{
    public partial class Lobby : Form
    {
        public Lobby(UserModel user)
        {
            InitializeComponent();
            currentUser = user;
            Border(null, null);
            LoadUser();
            this.FormClosing += Lobby_FormClosing;
            LoadTime();
            MakeCirclePanel(panel2);
            this.panelThamGia.Paint += RGBpanelThamGia;
            this.panelTaoPhong.Paint += RGBpanelTaoPhong;
            LayUserCount();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.Text = string.Empty;
            cw.EnableDrag(this);
            cw.ApplyRoundedRegion(this, 20);
        }
        CustomWindow cw = new CustomWindow();
        private UserModel currentUser;
        UserBLL userBLL = new UserBLL();

        private void LayUserCount()
        {
            label13.Text = "All Users (" + userBLL.GetUserCount() + ")";
        }
        private void Lobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            userBLL.SetUserStatus(currentUser.Id, false);
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
        private void Border(object s, EventArgs e)
        {
            BoGocPanel(panelTaoPhong, 20);
            BoGocPanel(panelThamGia, 20);
            BoGocPanel(panel5,15);
            BoGocPanel(panel6, 15);
            BoGocPanel(panel7, 15);
        }

        private void RGBpanelThamGia(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel.ClientRectangle,
                Color.FromArgb(59, 129, 246),
                Color.FromArgb(30, 79, 217),
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            }
        }
        private void RGBpanelTaoPhong(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel.ClientRectangle,
                Color.FromArgb(177, 105, 246),
                Color.FromArgb(128, 38, 207),
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            }
        }
        public void MakeCirclePanel(Panel panel)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, panel.Width, panel.Height);
            panel.Region = new Region(path);
        }
        private void DrawSoftShadowPanel(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            Rectangle shadowRect = new Rectangle(8, 8, panel.Width - 16, panel.Height - 16);
            using (GraphicsPath path = RoundedRect(shadowRect, 20))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(shadowBrush, path);
            }
            Rectangle panelRect = new Rectangle(0, 0, panel.Width - 16, panel.Height - 16);
            using (GraphicsPath path = RoundedRect(panelRect, 20))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            {
                e.Graphics.FillPath(whiteBrush, path);
            }

            panel.Region = new Region(RoundedRect(panel.ClientRectangle, 20));
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private bool isTimerInitialized = false;

        private void LoadTime()
        {
            if (!isTimerInitialized)
            {
                timeReload.Interval = 10000;
                timeReload.Tick += (sender, e) => LoadUser();
                isTimerInitialized = true;
            }
            timeReload.Start();
        }

        public void LoadUser()
        {

            UserBLL userBLL = new UserBLL();
            List<UserModel> onlineUsers = userBLL.GetOnlineUsers();
            List<UserModel> offlineUsers = userBLL.GetOfflineUsers();

            panelStatus.Controls.Clear();
            int y = 10;

            void AddUserControl(UserModel user)
            {
                var userStatus = new UserOnlineStatus();
                userStatus.name.Text = user.Username;
                userStatus.status.Text = user.Status;
                userStatus.Location = new Point(10, y);
                userStatus.Width = panelStatus.Width - 20;

                userStatus.status.ForeColor = user.IsOnline ? Color.Green : Color.Gray;

                panelStatus.Controls.Add(userStatus);
                y += userStatus.Height + 10;
            }

            foreach (var user in onlineUsers) AddUserControl(user);
            foreach (var user in offlineUsers) AddUserControl(user);
        }


        private void CreateZoom(object s, EventArgs e)
        {
            CreateZoom createZoomForm = new CreateZoom(currentUser);
            createZoomForm.ShowDialog();
        }

        private void JoinRoom(object s, EventArgs e)
        {
            JoinRoom joinRoomForm = new JoinRoom(currentUser);
            joinRoomForm.ShowDialog();
        }
    }
}
