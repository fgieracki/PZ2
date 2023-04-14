using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Clients;

public class Task1
{
    // static void Main(string[] args)
    public static void Task1Run()
    {
        IPHostEntry host = Dns.GetHostEntry("localhost");
        IPAddress ipAddress = host.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

        Socket socket = new(
            localEndPoint.AddressFamily, 
            SocketType.Stream, 
            ProtocolType.Tcp);

        socket.Connect(localEndPoint);
        Console.WriteLine("Insert message: ");
        string message = Console.ReadLine();
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
        //cut message so that it fits in 1024 bytes
        if (messageBytes.Length > 1024)
        {
            byte[] newMessageBytes = new byte[1024];
            for (int i = 0; i < 1024; i++)
            {
                newMessageBytes[i] = messageBytes[i];
            }
            messageBytes = newMessageBytes;
        }
        

        socket.Send(messageBytes, SocketFlags.None);

        var bufor = new byte[1_024];
        int byteCount = socket.Receive(bufor, SocketFlags.None);
        String serverResponse = Encoding.UTF8.GetString(bufor, 0, byteCount);
        Console.WriteLine(serverResponse);
        try {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
        catch{}
    }
}