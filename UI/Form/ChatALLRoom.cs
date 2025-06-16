using System;
using System.Drawing;
using System.Globalization;

namespace UI
{
    public partial class ChatALLRoom : Form
    {
        private int currentUserId;
        private ClientTcp client;

        public ChatALLRoom(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
            this.Load += ChatALLRoom_Load;
            btnSend.Click += btnSend_Click;
        }

        private void ChatALLRoom_Load(object sender, EventArgs e)
        {
            InitializeClient();
        }

        /// <summary>
        /// Khởi tạo và cấu hình client, đăng ký xử lý tin nhắn và kết nối đến server.
        /// </summary>
        private void InitializeClient()
        {
            client = new ClientTcp();

            client.OnMessageReceived += (msg) =>
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        ProcessReceivedMessage(msg);
                    }));
                }
            };

            client.OnStatusChanged += (status) =>
            {
                Console.WriteLine($"Client status: {status}");
            };

            if (client.Connect("127.0.0.1", 9000))
            {
                System.Threading.Thread.Sleep(100);
                client.Send($"LOGIN:{currentUserId}");
                Console.WriteLine($"Sent LOGIN:{currentUserId}");
            }
            else
            {
                MessageBox.Show("Không thể kết nối tới server!");
            }
        }

        /// <summary>
        /// Phân tích và xử lý các tin nhắn nhận được từ server.
        /// Giả sử tin nhắn broadcast được server gửi theo định dạng:
        /// "GROUP_MSG:{groupName}:{senderId}:{message}"
        /// Trong đó, tin nhắn broadcast có tiền tố "[All]" được server thêm vào.
        /// </summary>
        private void ProcessReceivedMessage(string message)
        {
            try
            {
                if (message.StartsWith("GROUP_MSG:"))
                {
                    // Tách chuỗi với 4 phần: groupName, senderId, message
                    var parts = message.Split(new char[] { ':' }, 4);
                    if (parts.Length == 4)
                    {
                        string groupName = parts[1];
                        if (int.TryParse(parts[2], out int senderId))
                        {
                            string content = parts[3];

                            // Nếu tin nhắn broadcast có tiền tố "[All]", hiển thị chuyên biệt
                            if (content.StartsWith("[All]"))
                            {
                                // Loại bỏ tiền tố "[All] " nếu có khoảng trắng sau
                                string broadcastText = content.StartsWith("[All] ") ?
                                    content.Substring("[All] ".Length) : content.Substring(5);
                                AddBubbleMessage(groupName, senderId, broadcastText, DateTime.Now);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xử lý tin nhắn: {ex.Message}");
            }
        }


        /// <summary>
        /// Sự kiện click của nút gửi tin nhắn.
        /// Lấy tin từ Typing.Value và gửi tin broadcast.
        /// </summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string text = Typing.Value.Trim();
            SendBroadcastMessage(text);
            // Xóa nội dung trong Typing sau khi gửi
            Typing.Value = "";
        }

        /// <summary>
        /// Gửi tin nhắn broadcast tới tất cả các phòng mà người dùng của bạn tham gia.
        /// Gửi theo định dạng: "CHAT_ALL:{userId}:{message}"
        /// Server sẽ chuyển tiếp tin đó tới từng phòng.
        /// </summary>
        private void SendBroadcastMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Nhập tin nhắn trước khi gửi.");
                return;
            }

            // Gửi lệnh broadcast đến server
            string command = $"CHAT_ALL:{currentUserId}:{message}";
            client.Send(command);
            Console.WriteLine($"Sent broadcast message: {command}");

            // Hiển thị tin nhắn của chính người gửi tại giao diện với tag [You]
            AddBubbleMessage("Broadcast", currentUserId, message, DateTime.Now, isSelf: true);
        }

        /// <summary>
        /// Thêm một bubble chat vào panelChat.
        /// Dùng control MeBubble.MeBubble (đã được custom) để hiển thị tên người gửi, thời gian và nội dung tin nhắn.
        /// Nếu isSelf == true, hiển thị là tin nhắn của chính bạn.
        /// </summary>
        private void AddBubbleMessage(string groupName, int senderId, string message, DateTime sentAt, bool isSelf = false)
        {
            // Bạn có thể thay thế cách lấy tên người gửi bằng cách gọi hàm trong UserBLL.
            string senderName = isSelf ? "Bạn" : $"User {senderId}";

            // Tạo bubble chat
            var bubble = new MeBubble.MeBubble
            {
                uName = senderName,
                Time = sentAt.ToString("HH:mm", CultureInfo.GetCultureInfo("vi-VN")),
                // Cho biết đây là broadcast, bạn có thể thêm tên group/room trong nội dung tin nhắn
                Body = $"[{groupName}] {message}",
                Dock = DockStyle.Top // Hiển thị theo thứ tự từ trên xuống
            };

            // Thêm bubble vào panelChat
            panelChat.Controls.Add(bubble);
            // Đưa bubble vừa thêm lên đầu danh sách nếu cần
            panelChat.Controls.SetChildIndex(bubble, 0);
            panelChat.ScrollControlIntoView(bubble);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            client?.Disconnect();
            base.OnFormClosed(e);
        }
    }
}
