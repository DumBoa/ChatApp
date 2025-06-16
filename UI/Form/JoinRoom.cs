using BLL;
using Model;
using System;
using System.Windows.Forms;
using Themes;

namespace UI
{
    public partial class JoinRoom : Form
    {
        private readonly UserModel currentUser;
        private readonly GroupChatBLL groupBLL = new GroupChatBLL();

        public JoinRoom(UserModel user)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.Text = string.Empty;
            cw.EnableDrag(this);
            cw.ApplyRoundedRegion(this, 20);
            currentUser = user;
        }
        CustomWindow cw = new CustomWindow();
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string roomName = txtNameRoom.Text.Trim();
            string password = txtPass.Text;

            if (string.IsNullOrEmpty(roomName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = groupBLL.JoinGroup(roomName, password, currentUser.Id, out string errorMsg);

            if (success)
            {
                MessageBox.Show("Vào phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                HubChat chatForm = new HubChat(currentUser, roomName);
                chatForm.Show();
                Application.OpenForms["Lobby"]?.Hide();
                this.Close();
            }
            else
            {
                MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // chưa thêm khi người dùng thoát thì cập nhật lại sql là đã thoát phòng
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
