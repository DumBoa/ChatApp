
using BLL;
using Themes;

namespace UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.Text = string.Empty;
            CustomWindow cw = new CustomWindow();
            cw.EnableDrag(this);
            LoginButton.TabStop = false;
            SignInButton.TabStop = false;
        }
        
        CustomBorder border = new CustomBorder();
        private void panelTenDangNhap_Paint(object sender, PaintEventArgs e) { border.SetRoundedCornersPanel(panelTenDangNhap, 50); }
        private void panelMatKhau_Paint(object sender, PaintEventArgs e) { border.SetRoundedCornersPanel(panelMatKhau, 50); }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e) { txtPassword.UseSystemPasswordChar = true; }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            try
            {
                UserBLL userBLL = new UserBLL();
                var user = userBLL.Login(username, password);

                if (user != null)
                {
                    userBLL.SetUserStatus(user.Id, true); 

                    Lobby lobbyForm = new Lobby(user);
                    lobbyForm.Show();  
                    this.Hide();     
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginPanel_Paint(object sender, PaintEventArgs e)
        {
            LoginButton.FlatAppearance.BorderSize = 0;
            LoginButton.FlatAppearance.MouseOverBackColor = LoginButton.BackColor;
            LoginButton.FlatAppearance.MouseDownBackColor = LoginButton.BackColor;
            LoginButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            border.SetRoundedCornersPanel(LoginPanel, 37);

            SignInButton.FlatAppearance.BorderSize = 0;
            SignInButton.FlatAppearance.MouseOverBackColor = SignInButton.BackColor;
            SignInButton.FlatAppearance.MouseDownBackColor = SignInButton.BackColor;
            SignInButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
           
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        

    }
}
