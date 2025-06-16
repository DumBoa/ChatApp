using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static Dictionary<int, Socket> connectedUsers = new Dictionary<int, Socket>();
    static Dictionary<int, string> usernames = new Dictionary<int, string>();
    static Dictionary<string, List<int>> groupChats = new Dictionary<string, List<int>>();
    static Dictionary<int, List<string>> userGroups = new Dictionary<int, List<string>>();

    static object userLock = new object();
    static object groupLock = new object();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        IPAddress ip = IPAddress.Parse("127.0.0.1");
        IPEndPoint endpoint = new IPEndPoint(ip, 9000);
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        serverSocket.Bind(endpoint);
        serverSocket.Listen(10);

        Console.WriteLine("Server chạy, chờ kết nối...");

        while (true)
        {
            Socket client = serverSocket.Accept();
            Thread t = new Thread(() => HandleClient(client));
            t.IsBackground = true;
            t.Start();
        }
    }

    static void HandleClient(Socket client)
    {
        int userId = -1;
        byte[] buffer = new byte[4096];
        try
        {
            client.Send(Encoding.UTF8.GetBytes("WELCOME"));

            while (true)
            {
                int received = client.Receive(buffer);
                if (received == 0) break;

                string msg = Encoding.UTF8.GetString(buffer, 0, received);
                Console.WriteLine($"Received: {msg}");

                if (msg.StartsWith("LOGIN:"))
                {
                    if (int.TryParse(msg.Substring(6), out userId))
                    {
                        lock (userLock)
                        {
                            connectedUsers[userId] = client;
                            if (!userGroups.ContainsKey(userId))
                                userGroups[userId] = new List<string>();
                        }
                        client.Send(Encoding.UTF8.GetBytes("LOGIN_SUCCESS"));
                        Console.WriteLine($"User {userId} đã đăng nhập");
                        SendUserList(client, userId);
                        BroadcastUserStatus(userId, true);
                    }
                    else
                    {
                        client.Send(Encoding.UTF8.GetBytes("LOGIN_FAIL"));
                    }
                }
                else if (msg.StartsWith("LIST_USERS"))
                {
                    SendUserList(client, userId);
                }
                else if (msg.StartsWith("CHAT_PRIVATE:"))
                {
                    var parts = msg.Split(new[] { ':' }, 4);
                    if (parts.Length == 4 &&
                        int.TryParse(parts[1], out int sender) &&
                        int.TryParse(parts[2], out int receiver))
                    {
                        SendPrivateMessage(sender, receiver, parts[3]);
                    }
                }
                else if (msg.StartsWith("CREATE_GROUP:"))
                {
                    var parts = msg.Split(new[] { ':' }, 3);
                    if (parts.Length == 3 && int.TryParse(parts[2], out int creator))
                    {
                        CreateGroup(parts[1], creator);
                    }
                }
                else if (msg.StartsWith("JOIN_GROUP:"))
                {
                    var parts = msg.Split(new[] { ':' }, 3);
                    if (parts.Length == 3 && int.TryParse(parts[2], out int joinUser))
                    {
                        JoinGroup(parts[1], joinUser);
                    }
                }
                else if (msg.StartsWith("LEAVE_GROUP:"))
                {
                    var parts = msg.Split(new[] { ':' }, 3);
                    if (parts.Length == 3 && int.TryParse(parts[2], out int leaveUser))
                    {
                        LeaveGroup(parts[1], leaveUser);
                    }
                }
                else if (msg.StartsWith("CHAT_GROUP:"))
                {
                    var parts = msg.Split(new[] { ':' }, 4);
                    if (parts.Length == 4 && int.TryParse(parts[2], out int senderUser))
                    {
                        Console.WriteLine($"Gửi message group: {parts[1]}, từ user: {senderUser}, nội dung: {parts[3]}");
                        SendGroupMessage(parts[1], senderUser, parts[3]);
                    }
                }
                else if (msg.StartsWith("DISCONNECT:"))
                {
                    if (int.TryParse(msg.Substring(11), out int discUser))
                    {
                        DisconnectUser(discUser);
                        break;
                    }
                }
                else if (msg.StartsWith("CHAT_ALL:"))
                {
                    var parts = msg.Split(new[] { ':' }, 3);
                    if (parts.Length == 3 && int.TryParse(parts[1], out int senderId))
                    {
                        Console.WriteLine($"Broadcast message từ user {senderId}: {parts[2]}");
                        SendMessageToAllGroups(senderId, parts[2]);
                    }
                }
                // TEST 
                else if (msg.StartsWith("SEND_FILE:"))
                {
                    var parts = msg.Split(new[] { ':' }, 3);
                    if (parts.Length == 3 && int.TryParse(parts[1], out int senderId))
                    {
                        string fileName = parts[2];

                        int receivedBytes = client.Receive(buffer);
                        byte[] fileData = new byte[receivedBytes];
                        Array.Copy(buffer, fileData, receivedBytes);

                        foreach (var user in connectedUsers)
                        {
                            if (user.Key != senderId)
                            {
                                user.Value.Send(Encoding.UTF8.GetBytes($"FILE_RECEIVED:{senderId}:{fileName}:{fileData.Length}"));
                                user.Value.Send(fileData);
                            }
                        }
                    }
                }


                // Đang nhắn
                else if (msg.StartsWith("TYPING:"))
                {
                    var parts = msg.Split(':');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int senderId))
                    {
                        foreach (var user in connectedUsers)
                        {
                            if (user.Key != senderId)
                            {
                                user.Value.Send(Encoding.UTF8.GetBytes($"USER_TYPING:{senderId}"));
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi client: {ex.Message}");
        }
        finally
        {
            if (userId != -1)
            {
                DisconnectUser(userId);
            }
            try { client.Close(); } catch { }
        }
    }
    static void SendMessageToAllGroups(int senderId, string message)
    {
        lock (groupLock)
        {
            if (userGroups.ContainsKey(senderId))
            {
                var groups = new List<string>(userGroups[senderId]);
                foreach (var groupName in groups)
                {
                    string formattedMessage = "/all" + message;
                    SendGroupMessage(groupName, senderId, formattedMessage);
                }
            }
            else
            {
                Console.WriteLine($"Người dùng {senderId} không tham gia phòng nào cả.");
            }
        }
    }

    static void SendUserList(Socket client, int excludeUserId)
    {
        lock (userLock)
        {
            var listUsers = new List<int>(connectedUsers.Keys);
            listUsers.Remove(excludeUserId);
            string userListString = "USER_LIST:" + string.Join(",", listUsers);
            client.Send(Encoding.UTF8.GetBytes(userListString));
        }
    }

    static void BroadcastUserStatus(int userId, bool isOnline)
    {
        string msg = isOnline ? $"USER_ONLINE:{userId}" : $"USER_OFFLINE:{userId}";
        lock (userLock)
        {
            foreach (var kvp in connectedUsers)
            {
                if (kvp.Key != userId)
                {
                    try
                    {
                        kvp.Value.Send(Encoding.UTF8.GetBytes(msg));
                    }
                    catch { }
                }
            }
        }
    }

    static void SendPrivateMessage(int senderId, int receiverId, string message)
    {
        lock (userLock)
        {
            if (connectedUsers.ContainsKey(receiverId))
            {
                try
                {
                    connectedUsers[receiverId].Send(Encoding.UTF8.GetBytes($"PRIVATE_MSG:{senderId}:{message}"));
                }
                catch { }
            }
        }
    }

    static void CreateGroup(string groupName, int creatorId)
    {
        lock (groupLock)
        {
            if (!groupChats.ContainsKey(groupName))
            {
                groupChats[groupName] = new List<int> { creatorId };
                if (!userGroups.ContainsKey(creatorId))
                    userGroups[creatorId] = new List<string>();
                userGroups[creatorId].Add(groupName);
                Console.WriteLine($"Group {groupName} được tạo bởi user {creatorId}");
                NotifyGroupMembers(groupName, $"GROUP_CREATED:{groupName}");
            }
        }
    }

    static void JoinGroup(string groupName, int userId)
    {
        lock (groupLock)
        {
            if (!groupChats.ContainsKey(groupName))
            {
                groupChats[groupName] = new List<int>();
            }

            if (!groupChats[groupName].Contains(userId))
            {
                groupChats[groupName].Add(userId);
                if (!userGroups.ContainsKey(userId))
                    userGroups[userId] = new List<string>();
                userGroups[userId].Add(groupName);
                Console.WriteLine($"User {userId} đã tham gia group {groupName}");
                NotifyGroupMembers(groupName, $"USER_JOINED_GROUP:{userId}");
            }
        }
    }

    static void LeaveGroup(string groupName, int userId)
    {
        lock (groupLock)
        {
            if (!groupChats.ContainsKey(groupName)) return;
            if (groupChats[groupName].Remove(userId))
            {
                if (userGroups.ContainsKey(userId))
                    userGroups[userId].Remove(groupName);
                NotifyGroupMembers(groupName, $"USER_LEFT_GROUP:{userId}");
                if (groupChats[groupName].Count == 0)
                {
                    groupChats.Remove(groupName);
                    Console.WriteLine($"Group {groupName} đang không còn ai trong phòng");
                }
            }
        }
    }

    static void SendGroupMessage(string groupName, int senderId, string message)
    {
        if (message.StartsWith("/all", StringComparison.OrdinalIgnoreCase))
        {
            message = message.Substring(4).Trim();
        }
        lock (groupLock)
        {
            if (!groupChats.ContainsKey(groupName))
            {
                Console.WriteLine($"Group {groupName} không tồn tại");
                return;
            }

            var members = groupChats[groupName];
            Console.WriteLine($"Gửi tin nhắn tới tới {members.Count} thành viên trong group {groupName}");

            lock (userLock)
            {
                foreach (var userId in members)
                {
                    if (userId != senderId && connectedUsers.ContainsKey(userId))
                    {
                        try
                        {
                            string msgToSend = $"GROUP_MSG:{groupName}:{senderId}:{message}";
                            Console.WriteLine($"Gửi tới user {userId}: {msgToSend}");
                            connectedUsers[userId].Send(Encoding.UTF8.GetBytes(msgToSend));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Lỗi gửi message tới user {userId}: {ex.Message}");
                        }
                    }
                }
            }
        }
    }

    static void DisconnectUser(int userId)
    {
        lock (userLock)
        {
            if (connectedUsers.TryGetValue(userId, out Socket socket))
            {
                try { socket.Send(Encoding.UTF8.GetBytes("DISCONNECTED")); }
                catch { }
                try { socket.Close(); } catch { }
                connectedUsers.Remove(userId);
                Console.WriteLine($"User {userId} đã ngắt kết nối.");
                BroadcastUserStatus(userId, false);
            }
        }

        lock (groupLock)
        {
            if (userGroups.ContainsKey(userId))
            {
                var groups = new List<string>(userGroups[userId]);
                foreach (var group in groups)
                {
                    LeaveGroup(group, userId);
                }
                userGroups.Remove(userId);
            }
        }
    }
    static void NotifyGroupMembers(string groupName, string message)
    {
        if (!groupChats.ContainsKey(groupName)) return;

        var members = groupChats[groupName];

        lock (userLock)
        {
            foreach (var memberId in members)
            {
                if (connectedUsers.TryGetValue(memberId, out Socket memberSocket))
                {
                    try
                    {
                        byte[] data = Encoding.UTF8.GetBytes(message);
                        memberSocket.Send(data);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi gửi notification tới user {memberId}: {ex.Message}");
                    }
                }
            }
        }
    }
}