using Model;
using Themes;
namespace UI
{
    public partial class CreateZoom : Form
    {

        public CreateZoom(UserModel user)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.Text = string.Empty;
            cw.EnableDrag(this);
            cw.ApplyRoundedRegion(this, 20);
            currentUser = user;
        }
        CustomBorder border = new CustomBorder();
        private UserModel currentUser;
        CustomWindow cw = new CustomWindow();
        private void XacNhanButton_Click(object sender, EventArgs e)
        {
            string groupName = txtNameRoom.Text.Trim();
            string password = txtPass.Text;
            int creatorId = currentUser.Id;

            var groupBLL = new GroupChatBLL();

            if (txtRePass.Text != password)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (groupBLL.IsGroupNameExists(groupName))
            {
                MessageBox.Show("Tên phòng đã tồn tại. Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = groupBLL.CreateGroup(groupName, password, creatorId);
            if (success)
            {
                MessageBox.Show("Tạo phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNameRoom.Clear();
                txtPass.Clear();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tạo phòng thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quitPanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rePaintBorder(object sender, PaintEventArgs e)
        {
            border.SetRoundedCornersPanel(panel1, 20);
            border.SetRoundedCornersPanel(XacNhanButton, 20);
            border.SetRoundedCornersPanel(panel4, 20);
            border.SetRoundedCornersPanel(panel2, 20);
            border.SetRoundedCornersPanel(panel3, 20);
        }
    }


}
