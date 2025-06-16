using BLL;
using Model;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace UI
{
    public partial class PrivateChatHub : Form
    {
        private int currentUserId;
        private int targetUserId;
        private ClientTcp client;
        private PrivateChatBLL chatBLL;
        private UserBLL userBLL = new UserBLL();

        /// <summary>
        /// Nếu có client đã khởi tạo (ví dụ: được dùng chung từ form HubChat), thì truyền vào để tránh tạo kết nối mới.
        /// Nếu không, PrivateChatHub sẽ tự khởi tạo client mới.
        /// </summary>
        /// <param name="senderId"></param>
        /// <param name="receiverId"></param>
        /// <param name="existingClient"></param>
        public PrivateChatHub(int senderId, int receiverId, ClientTcp existingClient = null)
        {
            InitializeComponent();

            this.currentUserId = senderId;
            this.targetUserId = receiverId;
            this.chatBLL = new PrivateChatBLL();

            // Sử dụng instance client truyền vào nếu có, ngược lại tạo kết nối mới
            if (existingClient != null)
            {
                client = existingClient;
                SetupClientEventHandlers();
            }
            else
            {
                InitializeClient();
            }

            // Khởi tạo các sự kiện của form và UI
            this.Shown += PrivateChatHub_Shown;
            Typing.KeyDown += TxtTyping_KeyDown;
            LoadPrivateMessages(currentUserId, targetUserId);
            MakePanelCircle(panel2);
        }

        private void PrivateChatHub_Shown(object sender, EventArgs e)
        {
        
        }

        private void InitializeClient()
        {
            client = new ClientTcp();
            SetupClientEventHandlers();

            if (client.Connect("127.0.0.1", 9000))
            {
                System.Threading.Thread.Sleep(100);
                client.Send($"LOGIN:{currentUserId}");
                Console.WriteLine($"Sent LOGIN command for user {currentUserId}");
            }
            else
            {
                MessageBox.Show("Không thể kết nối đến server!");
            }
        }

        /// <summary>
        /// Đăng ký các sự kiện nhận message và status từ client.
        /// </summary>
        private void SetupClientEventHandlers()
        {
            client.OnMessageReceived += (msg) =>
            {
                if (!this.IsHandleCreated)
                    return;
                this.Invoke((MethodInvoker)(() =>
                {
                    ProcessReceivedMessage(msg);
                }));
            };

            client.OnStatusChanged += (status) =>
            {
                if (!this.IsHandleCreated)
                    return;
                this.Invoke((MethodInvoker)(() =>
                {
                    Console.WriteLine($"Client status: {status}");
                }));
            };
        }

        private void MakePanelCircle(Panel panel)
        {
            int diameter = Math.Min(panel.Width, panel.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, diameter, diameter);
            panel.Region = new Region(path);
        }

        private void LoadPrivateMessages(int user1Id, int user2Id)
        {
            var messages = chatBLL.GetPrivateMessages(user1Id, user2Id);
            panelChat.Controls.Clear();
            if (messages != null)
            {
                foreach (var msg in messages)
                {
                    AddMessageToPanel(msg);
                }
            }
            if (panelChat.Controls.Count > 0)
                panelChat.ScrollControlIntoView(panelChat.Controls[panelChat.Controls.Count - 1]);
        }

        private void SendPrivateMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Nhập tin nhắn trước khi gửi.");
                return;
            }

            var msgModel = new PrivateChatModel
            {
                SenderId = currentUserId,
                ReceiverId = targetUserId,
                Message = message.Trim(),
                SentAt = DateTime.Now
            };

            if (chatBLL.AddPrivateMessage(msgModel))
            {
                string command = $"CHAT_PRIVATE:{currentUserId}:{targetUserId}:{message.Trim()}";
                client.Send(command);
                Console.WriteLine($"Sent private message: {command}");

                AddMessageToPanel(msgModel);
                Typing.Value = "";
            }
            else
            {
                MessageBox.Show("Không thể lưu tin nhắn.");
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string text = Typing.Value.Trim();
            SendPrivateMessage(text);
        }

        private void TxtTyping_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnSend_Click(sender, e);
            }
        }
        private void ProcessReceivedMessage(string message)
        {
            try
            {
                // định dạng: PRIVATE_MSG:{senderId}:{message}
                if (message.StartsWith("PRIVATE_MSG:"))
                {
                    var parts = message.Split(new char[] { ':' }, 3);
                    if (parts.Length == 3 && int.TryParse(parts[1], out int incomingSenderId))
                    {
                        
                        if (incomingSenderId == targetUserId)
                        {
                            var privateMessage = new PrivateChatModel
                            {
                                SenderId = incomingSenderId,
                                ReceiverId = currentUserId,
                                Message = parts[2].Trim(),
                                SentAt = DateTime.Now
                            };
                            AddMessageToPanel(privateMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xử lý tin nhắn: {ex.Message}");
            }
        }

        private void AddMessageToPanel(PrivateChatModel msg)
        {
            var bubble = new MeBubble.MeBubble
            {
                uName = userBLL.GetUserById(msg.SenderId)?.Username ?? "Unknown User",
                Time = msg.SentAt.ToString("HH:mm", new CultureInfo("vi-VN")),
                Body = msg.Message,
                Dock = DockStyle.Bottom
            };

            panelChat.Controls.Add(bubble);
            panelChat.ScrollControlIntoView(bubble);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            client?.Disconnect();
            base.OnFormClosed(e);
        }
    }
}
