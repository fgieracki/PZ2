using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Clients;

public class Task3
{
    public static void Task3Run()
        // public static void Main(string[] args)
    {
        IPHostEntry host = Dns.GetHostEntry("localhost");
        IPAddress ipAddress = host.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

        Socket socket = new(
            localEndPoint.AddressFamily, 
            SocketType.Stream, 
            ProtocolType.Tcp);

        socket.Connect(localEndPoint);
        while (true)
        {
            Console.WriteLine("Insert message: ");
            string message = Console.ReadLine();


            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            var messageSizeBytes = BitConverter.GetBytes(messageBytes.Length);
            socket.Send(messageSizeBytes, SocketFlags.None);
            socket.Send(messageBytes, SocketFlags.None);
            if (message == "!end")
            {
                try {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch{}

                return;
            }
                

            var sizeBuffor = new byte[4];
            socket.Receive(sizeBuffor, SocketFlags.None);
            int responseSize = BitConverter.ToInt32(sizeBuffor, 0);
            var responseBuffor = new byte[responseSize];
            socket.Receive(responseBuffor, SocketFlags.None);

            string serverResponse = Encoding.UTF8.GetString(responseBuffor);
            Console.WriteLine(serverResponse);
        }

        try {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
        catch{}
    }
}