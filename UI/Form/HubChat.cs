using BLL;
using Model;
using System.Drawing.Drawing2D;
using Themes;
using System.Globalization;
using System.Media;

namespace UI
{
    public partial class HubChat : Form
    {
        private UserModel currentUser;
        private int currentGroupId = -1;
        private string currentRoomName = null;
        private ClientTcp client;
        CustomWindow cw = new CustomWindow();
        UserBLL userBLL = new UserBLL();
        private bool isPrivateChat = false;
        private int privateChatUserId = -1;
        private PrivateChatBLL privateChatBLL = new PrivateChatBLL();

        public HubChat(UserModel user, string room)
        {
            InitializeComponent();
            currentUser = user;
            LoadUser();
            this.Load += HubChat_Load;
            Border(null, null);
            cw.EnableDrag(this);
            LoadPrivateChatUser();
            this.Load += UserStatus_Click;
            this.FormClosing += HubChat_close;
            MakeCirclePanel(panel12);

        }

        // Ping Pong
        private void PlaySendSound()
        {
            SoundPlayer player = new SoundPlayer(@"C:\\Users\\Laptop\\source\\repos\\UngDungTroTruyen\\UI\\Themes\\live-chat-353605.wav");
            player.Play();
        }
        // Typing
        private void Typing_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Typing.Value.Trim()))
            {
                client.Send($"TYPING:{currentUser.Id}");
            }
        }

        private void HubChat_close(object sender, FormClosingEventArgs e)
        {
            UserBLL userBLL = new UserBLL();
            userBLL.SetUserStatus(currentUser.Id, false);

            try
            {
                client?.Send($"DISCONNECT:{currentUser.Id}");
                client?.Disconnect();
            }
            catch { }
        }

        private void HubChat_Load(object sender, EventArgs e)
        {
            InitializeClient();
            LoadChatGroup(currentUser.Id);
        }

        private bool isTimerInitialized = false;

        public void MakeCirclePanel(Panel panel)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, panel.Width, panel.Height);
            panel.Region = new Region(path);
        }
        private void LoadTime()
        {
            if (!isTimerInitialized)
            {
                timeReload.Interval = 60000;
                timeReload.Tick += (sender, e) => LoadUser();
                isTimerInitialized = true;
            }
            timeReload.Start();
        }
        private void SendBroadcastMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Nhập tin nhắn trước khi gửi.");
                return;
            }

            string command = $"CHAT_ALL:{currentUser.Id}:{message}";
            client.Send(command);
            Console.WriteLine($"Sent broadcast message: {command}");

            AddMessageToPanel(new GroupChatModel
            {
                GroupId = currentGroupId,
                SenderId = currentUser.Id,
                Message = message,
                SentAt = DateTime.Now
            });
        }

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

            bool connected = client.Connect("127.0.0.1", 9000);
            if (connected)
            {

                Thread.Sleep(100);
                client.Send($"LOGIN:{currentUser.Id}");
                Console.WriteLine($"Đã gửi LOGIN cho user {currentUser.Id}");
            }
            else
            {
                MessageBox.Show("Không thể kết nối tới server!");
            }
        }
        private void ProcessReceivedMessage(string message)
        {
            try
            {
                Console.WriteLine($"Processing message: {message}");

                if (message.StartsWith("LOGIN_SUCCESS"))
                {
                    Console.WriteLine("Đăng nhập thành công");
                    return;
                }
                else if (message.StartsWith("GROUP_MSG:"))
                {
                    var parts = message.Split(new[] { ':' }, 4);
                    if (parts.Length == 4 && int.TryParse(parts[2], out int senderId))
                    {
                        string groupName = parts[1];
                        string msg = parts[3];

                        Console.WriteLine($"Nhận group message từ {senderId} trong group {groupName}: {msg}");

                        if (groupName == currentRoomName)
                        {
                            var receivedMessage = new GroupChatModel
                            {
                                GroupId = currentGroupId,
                                SenderId = senderId,
                                Message = msg.Trim(),
                                SentAt = DateTime.Now
                            };
                            var chatBLL = new GroupChatBLL();
                            chatBLL.AddMessageToGroup(receivedMessage);

                            AddMessageToPanel(receivedMessage);
                        }
                    }
                }
                else if (message.StartsWith("USER_JOINED_GROUP:"))
                {
                    string userIdStr = message.Substring("USER_JOINED_GROUP:".Length);
                    if (int.TryParse(userIdStr, out int userId))
                    {
                        string username = userBLL.GetUserById(userId)?.Username ?? userId.ToString();
                        string notif = $"{username} đã tham gia phòng chat.";

                        var notificationMessage = new GroupChatModel
                        {
                            GroupId = currentGroupId,
                            SenderId = 0,
                            Message = notif,
                            SentAt = DateTime.Now
                        };

                        AddMessageToPanel(notificationMessage);
                    }
                }
                else if (message.StartsWith("USER_LEFT_GROUP:"))
                {
                    string userIdStr = message.Substring("USER_LEFT_GROUP:".Length);
                    if (int.TryParse(userIdStr, out int userId))
                    {
                        string username = userBLL.GetUserById(userId)?.Username ?? userId.ToString();
                        string notif = $"{username} đã rời khỏi phòng chat.";

                        var notificationMessage = new GroupChatModel
                        {
                            GroupId = currentGroupId,
                            SenderId = 0,
                            Message = notif,
                            SentAt = DateTime.Now
                        };

                        AddMessageToPanel(notificationMessage);
                    }
                }
                else if (message.StartsWith("PRIVATE_MSG:"))
                {
                    var parts = message.Split(new[] { ':' }, 3);
                    if (parts.Length == 3 && int.TryParse(parts[1], out int senderId))
                    {
                        string msg = parts[2];
                        Console.WriteLine($"Nhận private message từ {senderId}: {msg}");
                    }
                }
                else if (message.StartsWith("FILE_RECEIVED:"))
                {
                    var parts = message.Split(':', 4);
                    if (parts.Length == 4 && int.TryParse(parts[1], out int senderId) && int.TryParse(parts[3], out int fileSize))
                    {
                        string fileName = parts[2];
                        Console.WriteLine($"Bắt đầu nhận file: {fileName} ({fileSize} bytes) từ user {senderId}");

                        byte[] fileData = client.ReceiveFileData(fileSize);
                        if (fileData != null)
                        {
                            Console.WriteLine($"Nhận file thành công: {fileName}");

                            var fileMessage = new GroupChatModel
                            {
                                SenderId = senderId,
                                Message = fileName,
                                SentAt = DateTime.Now
                            };

                            this.Invoke((MethodInvoker)(() =>
                            {
                                AddMessageToPanel(fileMessage, true, fileData);
                            }));
                        }
                    }
                }

                else if (message.StartsWith("USER_TYPING:"))
                {
                    var parts = message.Split(':');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int typingUserId))
                    {
                        string username = userBLL.GetUserById(typingUserId)?.Username ?? typingUserId.ToString();
                        Console.WriteLine($"{username} đang nhập...");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi xử lý tin nhắn: {ex.Message}");
                MessageBox.Show($"Lỗi xử lý tin nhắn: {ex.Message}");
            }
        }


        // TEST
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file để gửi";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                SendFile(filePath);
            }
        }

        private void SendFile(string filePath)
        {
            // Chạy gửi file trên background thread
            Task.Run(() =>
            {
                try
                {
                    byte[] fileData = File.ReadAllBytes(filePath);
                    string fileName = Path.GetFileName(filePath);

                    client.Send($"SEND_FILE:{currentUser.Id}:{fileName}");

                    client.SendFileData(fileData, fileName);
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, hiển thị bằng MessageBox trên UI thread
                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show($"Lỗi gửi file: {ex.Message}");
                    }));
                }
            });
        }


        //
        private void JoinServerRoom(string roomName, int groupId)
        {
            if (string.IsNullOrEmpty(roomName)) return;

            try
            {
                client.Send($"JOIN_GROUP:{roomName}:{currentUser.Id}");
                currentRoomName = roomName;
                currentGroupId = groupId;
                Console.WriteLine($"Đã join group {roomName} với ID {groupId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi tham gia phòng: {ex.Message}");
                MessageBox.Show($"Lỗi tham gia phòng: {ex.Message}");
            }
        }

        private void SendGroupMessage(string message)
        {
            if (string.IsNullOrEmpty(message.Trim()) || currentGroupId == -1)
            {
                MessageBox.Show("Chọn phòng chat và nhập tin nhắn trước khi gửi.");
                return;
            }

            var messageModel = new GroupChatModel
            {
                GroupId = currentGroupId,
                SenderId = currentUser.Id,
                Message = message.Trim(),
                SentAt = DateTime.Now
            };

            var chatBLL = new GroupChatBLL();
            if (chatBLL.AddMessageToGroup(messageModel))
            {
                // Gửi message lên server
                string formattedMessage = $"CHAT_GROUP:{currentRoomName}:{currentUser.Id}:{message.Trim()}";
                client.Send(formattedMessage);
                Console.WriteLine($"Đã gửi message: {formattedMessage}");

                // Hiển thị message của mình
                AddMessageToPanel(messageModel);
                Typing.Value = "";
            }
            else
            {
                MessageBox.Show("Gửi tin nhắn thất bại, vui lòng thử lại.");
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            try
            {
                client?.Send($"DISCONNECT:{currentUser.Id}");
                client?.Disconnect();
            }
            catch { }
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                client?.Send($"DISCONNECT:{currentUser.Id}");
                client?.Disconnect();
            }
            catch { }
            base.OnFormClosed(e);
        }

        // Hub Decor
        private void Border(object s, EventArgs e)
        {
            BoGocPanel(panel3, 20);
            BoGocPanel(panel4, 20);
            BoGocPanel(panel5, 20);
            BoGocPanel(panel9, 20);
            BoGocPanel(panel3, 20);
            BoGocPanel(panel13, 20);
            BoGocPanel(panel7, 20);
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

        // Group Chat Methods
        public void LoadChatGroup(int userId)
        {
            GroupChatBLL grBLL = new GroupChatBLL();
            List<GroupModel> userGroups = grBLL.GetGroupsByUser(userId);

            panelBoxChat.Controls.Clear();
            int y = 10;

            foreach (var group in userGroups)
            {
                GroupChat groupControl = new GroupChat();
                groupControl.rName.Text = group.GroupName;
                groupControl.Tag = group.Id;

                groupControl.GroupClicked += GroupControl_GroupClicked;

                groupControl.Location = new Point(10, y);
                groupControl.Width = panelBoxChat.Width - 20;
                panelBoxChat.Controls.Add(groupControl);

                y += groupControl.Height + 10;
            }
        }

        private void GroupControl_GroupClicked(object sender, EventArgs e)
        {
            if (sender is GroupChat groupControl && groupControl.Tag is int groupId)
            {
                currentGroupId = groupId;
                GroupChatBLL chatBLL = new GroupChatBLL();
                string roomName = chatBLL.GetGroupName(groupId);

                if (!string.IsNullOrEmpty(roomName))
                {
                    JoinServerRoom(roomName, groupId);
                    currentRoomName = roomName;
                }

                var messages = chatBLL.GetMessagesByGroupId(groupId);
                panelChat.Controls.Clear();

                if (messages != null && messages.Count > 0)
                {
                    LoadMessagesToPanel(messages, currentUser.Id, panelChat);
                }

                LoadGroupMembers(groupId);
            }
        }

        /*private void AddMessageToPanel(GroupChatModel msg)
        {
            MeBubble.MeBubble bubble = new MeBubble.MeBubble
            {
                uName = userBLL.GetUserById(msg.SenderId)?.Username ?? "Server",
                Time = msg.SentAt.ToString("h:mm tt", new CultureInfo("vi-VN")),
                Body = msg.Message,
                Margin = new Padding(10)
            };

            panelChat.Controls.Add(bubble);
            panelChat.ScrollControlIntoView(bubble);
        }*/
        private void AddMessageToPanel(GroupChatModel msg, bool isFile = false, byte[] fileData = null)
        {
            MeBubble.MeBubble bubble = new MeBubble.MeBubble
            {
                uName = userBLL.GetUserById(msg.SenderId)?.Username ?? "Server",
                Time = msg.SentAt.ToString("h:mm tt", new CultureInfo("vi-VN")),
                Body = isFile ? $"📁 File: {msg.Message} (Nhấn để tải về)" : msg.Message,
                Margin = new Padding(10)
            };

            if (isFile && fileData != null)
            {
                bubble.Click += (s, e) =>
                {
                    using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                    {
                        folderDialog.Description = "Chọn thư mục để lưu file";

                        if (folderDialog.ShowDialog() == DialogResult.OK)
                        {
                            string savePath = Path.Combine(folderDialog.SelectedPath, msg.Message);
                            File.WriteAllBytes(savePath, fileData);
                            MessageBox.Show($"File đã được lưu tại {savePath}");
                        }
                    }
                };
            }

            panelChat.Controls.Add(bubble);
            panelChat.ScrollControlIntoView(bubble);
        }
        public void LoadMessagesToPanel(List<GroupChatModel> messageList, int currentUserId, Panel panel)
        {
            panel.Controls.Clear();
            foreach (var msg in messageList)
            {
                MeBubble.MeBubble bubble = new MeBubble.MeBubble
                {
                    uName = userBLL.GetUserById(msg.SenderId)?.Username ?? "Server",
                    Time = msg.SentAt.ToString("h:mm tt", new CultureInfo("vi-VN")),
                    Body = msg.Message,
                    Margin = new Padding(10)
                };
                panel.Controls.Add(bubble);
            }

            // Cuộn xuống cuối
            if (panel.Controls.Count > 0)
                panel.ScrollControlIntoView(panel.Controls[panel.Controls.Count - 1]);
        }

        private void LoadGroupMembers(int groupId)
        {
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string text = Typing.Value.Trim();
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Vui lòng nhập tin nhắn.");
                return;
            }

            if (text.StartsWith("/all "))
            {
                string broadcastMessage = text.Substring(5).Trim();
                SendBroadcastMessage(broadcastMessage);
            }
            else
            {
                PlaySendSound();
                SendGroupMessage(text);
            }

            Typing.Value = "";
        }



        public void LoadUser()
        {
            UserBLL userBLL = new UserBLL();
            List<UserModel> onlineUsers = userBLL.GetOnlineUsers();
            List<UserModel> offlineUsers = userBLL.GetOfflineUsers();

            panelHideUser.Controls.Clear();
            int y = 10;

            void AddUserControl(UserModel user)
            {
                LoadTime();
                var userStatus = new UserOnlineStatus();
                userStatus.name.Text = user.Username;
                userStatus.status.Text = user.Status;
                userStatus.Location = new Point(10, y);
                userStatus.Width = panelHideUser.Width - 20;

                userStatus.status.ForeColor = user.IsOnline ? Color.Green : Color.Red;

                panelHideUser.Controls.Add(userStatus);
                y += userStatus.Height + 10;
            }

            foreach (var user in onlineUsers) AddUserControl(user);
            foreach (var user in offlineUsers) AddUserControl(user);
        }

        public void LoadPrivateChatUser()
        {
            UserBLL userBLL = new UserBLL();
            List<UserModel> onlineUsers = userBLL.GetOnlineUsers();
            List<UserModel> offlineUsers = userBLL.GetOfflineUsers();

            panelPrivateUserChat.Controls.Clear();
            int y = 10;

            void AddUserControl(UserModel user)
            {
                LoadTime();
                PrivateChat userStatus = new PrivateChat();
                userStatus.name.Text = user.Username;
                userStatus.status.Text = user.Status;
                userStatus.Tag = user.Id;
                userStatus.Location = new Point(10, y);
                userStatus.Width = panelPrivateUserChat.Width - 20;
                panelPrivateUserChat.Controls.Add(userStatus);
                y += userStatus.Height + 10;
                userStatus.status.ForeColor = user.IsOnline ? Color.Green : Color.Gray;
                userStatus.PrivateChatClicked += UserStatus_Click;
            }
            foreach (var user in onlineUsers) AddUserControl(user);
            foreach (var user in offlineUsers) AddUserControl(user);

        }
        private void UserStatus_Click(object sender, EventArgs e)
        {
            if (sender is PrivateChat userStatus && userStatus.Tag is int userId)
            {
                OpenPrivateChatForm(userId);
            }
        }

        private void OpenPrivateChatForm(int userId)
        {
            if (!userBLL.IsUserExist(currentUser.Id) || !userBLL.IsUserExist(userId))
            {
                MessageBox.Show("Người dùng không tồn tại trong hệ thống.");
                return;
            }
            PrivateChatHub chatForm = new PrivateChatHub(currentUser.Id, userId);
            chatForm.Show();
        }

        private void OpenAdminChat(object s, EventArgs e)
        {

            ChatALLRoom adminChat = new ChatALLRoom(currentUser.Id);
            adminChat.Show();
        }
    }
}




/*foreach (var user in onlineUsers)
{
    PrivateChat userStatus = new PrivateChat();
    userStatus.name.Text = user.Username;
    userStatus.status.Text = user.Status;
    userStatus.Tag = user.Id;
    userStatus.Location = new Point(10, y);
    userStatus.Width = panelPrivateUserChat.Width - 20;
    panelPrivateUserChat.Controls.Add(userStatus);
    y += userStatus.Height + 10;
    userStatus.status.ForeColor = user.IsOnline ? Color.Green : Color.Gray;
    userStatus.PrivateChatClicked += UserStatus_Click;
}

foreach (var user in offlineUsers)
{
    PrivateChat userStatus = new PrivateChat();
    userStatus.name.Text = user.Username;
    userStatus.status.Text = user.Status;
    userStatus.Tag = user.Id;
    userStatus.Location = new Point(10, y);
    userStatus.Width = panelPrivateUserChat.Width - 20;
    panelPrivateUserChat.Controls.Add(userStatus);
    y += userStatus.Height + 10;
    userStatus.status.ForeColor = user.IsOnline ? Color.Green : Color.Gray;
    userStatus.PrivateChatClicked += UserStatus_Click;
}*/