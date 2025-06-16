
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static Dictionary<string, List<Socket>> roomClients = new Dictionary<string, List<Socket>>();
    static object locker = new object();

    static void Main(string[] args)
    {
        Console.Title = "TCP Server Đa luồng";
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        IPEndPoint ipep = new IPEndPoint(ip, 9000);
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        serverSocket.Bind(ipep);
        serverSocket.Listen(10);
        Console.WriteLine("Server dang chay....Cho ket noi tu Client");

        while (true)
        {
            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine($"Client duoc ket noi: {clientSocket.RemoteEndPoint}");

            Thread clientThread = new Thread(() => HandleClient(clientSocket));
            clientThread.IsBackground = true;
            clientThread.Start();
        }
    }

    static void HandleClient(Socket client)
    {
        try
        {
            client.Send(Encoding.UTF8.GetBytes("Chao mung toi server!"));

            string currentRoom = null;
            byte[] buffer = new byte[1024];

            while (true)
            {
                try
                {
                    int recv = client.Receive(buffer);
                    if (recv == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, recv);
                    Console.WriteLine($"[{client.RemoteEndPoint}]: {message}");

                    if (message.StartsWith("JOIN:", StringComparison.OrdinalIgnoreCase))
                    {
                        string roomName = message.Substring(5).Trim();
                        Console.WriteLine($"Client {client.RemoteEndPoint} muon tham gia phong: {roomName}");
                        JoinRoom(client, roomName, ref currentRoom);
                        continue;
                    }

                    if (currentRoom == null)
                    {
                        client.Send(Encoding.UTF8.GetBytes("Ban chua tham gia phong nao. Hay nhap JOIN:ten_phong."));
                        continue;
                    }

                    BroadcastToRoom(currentRoom, message, client);
                }
                catch (SocketException se)
                {
                    Console.WriteLine($"Socket Exception: {se.Message}");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Loi Client: {ex.Message}");
        }
        finally
        {
            LeaveAllRooms(client);
            Console.WriteLine($"Client ngat ket noi: {client.RemoteEndPoint}");
            try { client.Shutdown(SocketShutdown.Both); client.Close(); } catch { }
        }
    }

    static void JoinRoom(Socket client, string roomName, ref string currentRoom)
    {
        if (currentRoom != null)
        {
            LeaveRoom(client, currentRoom);
        }

        lock (locker)
        {
            if (!roomClients.ContainsKey(roomName))
            {
                roomClients[roomName] = new List<Socket>();
                Console.WriteLine($"Da tao phong: {roomName}");
            }
            if (!roomClients[roomName].Contains(client))
            {
                roomClients[roomName].Add(client);
                Console.WriteLine($"Client {client.RemoteEndPoint} da vao phong: {roomName}");
                client.Send(Encoding.UTF8.GetBytes($"Ban da tham gia phong: {roomName}"));
                BroadcastToRoom(roomName, $"Mot nguoi dung moi da tham gia phong", client);
                Console.WriteLine($"Phong {roomName} co {roomClients[roomName].Count} nguoi dung");
                currentRoom = roomName;
            }
        }
    }

    static void LeaveRoom(Socket client, string roomName)
    {
        lock (locker)
        {
            if (roomClients.ContainsKey(roomName) && roomClients[roomName].Remove(client))
            {
                Console.WriteLine($"Client {client.RemoteEndPoint} da roi phong: {roomName}");
                if (roomClients[roomName].Count == 0)
                {
                    roomClients.Remove(roomName);
                    Console.WriteLine($"Phong {roomName} da duoc xoa");
                }
            }
        }
    }

    static void LeaveAllRooms(Socket client)
    {
        lock (locker)
        {
            foreach (var room in roomClients.Keys.ToList())
            {
                if (roomClients[room].Remove(client))
                {
                    Console.WriteLine($"Client {client.RemoteEndPoint} da roi phong {room}");
                    if (roomClients[room].Count == 0)
                    {
                        roomClients.Remove(room);
                        Console.WriteLine($"Phong {room} da duoc xoa");
                    }
                }
            }
        }
    }

    static void BroadcastToRoom(string roomName, string message, Socket sender)
    {
        byte[] responseData = Encoding.UTF8.GetBytes(message);

        lock (locker)
        {
            if (roomClients.ContainsKey(roomName))
            {
                foreach (var client in roomClients[roomName].Where(c => c != sender))
                {
                    try { client.Send(responseData); }
                    catch (Exception ex) { Console.WriteLine($"Loi gui toi Client: {ex.Message}"); }
                }
            }
        }
    }
}