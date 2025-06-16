using System.Net.Sockets;
using System.Text;

public class ClientTcp
{
    private Socket socket;
    private Thread receiveThread;
    private bool isConnected = false;

    public event Action<string> OnMessageReceived;
    public event Action<string> OnStatusChanged;

    public bool Connect(string host, int port)
    {
        try
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(host, port);
            isConnected = true;

            receiveThread = new Thread(ReceiveLoop);
            receiveThread.IsBackground = true;
            receiveThread.Start();

            OnStatusChanged?.Invoke("Kết nối thành công");
            return true;
        }
        catch (Exception ex)
        {
            OnStatusChanged?.Invoke($"Kết nối thất bại: {ex.Message}");
            return false;
        }
    }
    // TEST 
    public void SendFileData(byte[] fileData, string fileName)
    {
        if (fileData == null || fileData.Length == 0 || !socket.Connected)
        {
            Console.WriteLine("Dữ liệu file không hợp lệ hoặc socket chưa kết nối!");
            return;
        }

        try
        {
            // Gửi header: FILE_DATA:{fileName}:{fileSize}
            string header = $"FILE_DATA:{fileName}:{fileData.Length}";
            byte[] headerBytes = Encoding.UTF8.GetBytes(header);
            socket.Send(headerBytes);

            int totalSent = 0;
            int bufferSize = 8192;

            while (totalSent < fileData.Length)
            {
                int toSend = Math.Min(bufferSize, fileData.Length - totalSent);
                int sent = socket.Send(fileData, totalSent, toSend, SocketFlags.None);
                totalSent += sent;
            }

            Console.WriteLine($"Đã gửi file: {fileName} ({fileData.Length} bytes)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi gửi file: {ex.Message}");
        }
    }

    public byte[] ReceiveFileData(int fileSize)
    {
        byte[] fileData = new byte[fileSize];
        int totalReceived = 0;
        while (totalReceived < fileSize)
        {
            int bytesRemaining = fileSize - totalReceived;
            int received = socket.Receive(fileData, totalReceived, bytesRemaining, SocketFlags.None);

            if (received <= 0)
            {
                Console.WriteLine("Kết nối bị gián đoạn hoặc không nhận được dữ liệu.");
                return null;
            }

            totalReceived += received;
        }

        return fileData;
    }

    //
    public void Send(string message)
    {
        if (socket == null || !socket.Connected || !isConnected)
        {
            Console.WriteLine("Socket không kết nối, không thể gửi message");
            return;
        }

        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            socket.Send(data);
            Console.WriteLine($"CLIENT SENT: {message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi gửi message: {ex.Message}");
            OnStatusChanged?.Invoke($"Lỗi gửi: {ex.Message}");
        }
    }

    public void Disconnect()
    {
        try
        {
            isConnected = false;
            socket?.Shutdown(SocketShutdown.Both);
            socket?.Close();
            OnStatusChanged?.Invoke("Đã ngắt kết nối");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi ngắt kết nối: {ex.Message}");
        }
    }

    private void ReceiveLoop()
    {
        byte[] buffer = new byte[4096];
        while (isConnected)
        {
            try
            {
                int received = socket.Receive(buffer);
                if (received == 0) break;

                string msg = Encoding.UTF8.GetString(buffer, 0, received);
                Console.WriteLine($"CLIENT RECEIVED: {msg}");
                OnMessageReceived?.Invoke(msg);
            }
            catch (Exception ex)
            {
                if (isConnected)
                {
                    Console.WriteLine($"Lỗi nhận message: {ex.Message}");
                    OnStatusChanged?.Invoke($"Mất kết nối: {ex.Message}");
                }
                break;
            }
        }
        isConnected = false;
    }
}
