using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Servers;

public class Task2
{
    public static void Main(string[] args)
    // public static void Task2Run()
    {
        IPHostEntry host = Dns.GetHostEntry("localhost");
        IPAddress ipAddress = host.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
        
        Socket socketSerwera = new(
            localEndPoint.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp);

        socketSerwera.Bind(localEndPoint);
        socketSerwera.Listen(100);
        Socket socketKlienta = socketSerwera.Accept();

        byte []bufor = new byte[4];

        int received1 = socketKlienta.Receive(bufor, SocketFlags.None);
        int dl = BitConverter.ToInt32(bufor, 0);

        byte []bufor2 = new byte[dl];
        
        int received = socketKlienta.Receive(bufor2, SocketFlags.None);
        string odpowiedz = "odczytalem: " + Encoding.UTF8.GetString(bufor2, 0, received);
        Console.WriteLine(odpowiedz);
        var echoBytes = Encoding.UTF8.GetBytes(odpowiedz);
        var responseSize = echoBytes.Length;
        var responseSizeBytes = BitConverter.GetBytes(echoBytes.Length);

        socketKlienta.Send(responseSizeBytes, 0);
        socketKlienta.Send(echoBytes, 0);

        try
        {
            socketSerwera.Shutdown(SocketShutdown.Both);
            socketSerwera.Close();
        }
        catch
        {
            // Console.WriteLine(e);
        }
    }
}