using System;
using System.Windows.Forms;

namespace UI
{
    public partial class GroupChat : UserControl
    {
        public GroupChat()
        {
            InitializeComponent();
            this.Click += GroupChat_Click;
            txtRoomName.Click += GroupChat_Click;
        }

        public Label rName
        {
            get { return txtRoomName; }
            set { txtRoomName = value; }
        }

        public event EventHandler GroupClicked;

        private void GroupChat_Click(object sender, EventArgs e)
        {
            GroupClicked?.Invoke(this, e);
        }



    }
}
