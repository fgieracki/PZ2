using System.Net;
using System.Net.Sockets;
using System.Text;

namespace task1;

public class Client
{
    static void Main(string[] args)
    {
        IPHostEntry host = Dns.GetHostEntry("localhost");
        IPAddress ipAddress = host.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

        Socket socket = new(
            localEndPoint.AddressFamily, 
            SocketType.Stream, 
            ProtocolType.Tcp);

        socket.Connect(localEndPoint);
        string wiadomosc = "Wiadomość od klienta";
        byte[] wiadomoscBajty = Encoding.UTF8.GetBytes(wiadomosc);
        socket.Send(wiadomoscBajty, SocketFlags.None);

        var bufor = new byte[1_024];
        int liczbaBajtów = socket.Receive(bufor, SocketFlags.None);
        String odpowiedzSerwera = Encoding.UTF8.GetString(bufor, 0, liczbaBajtów);
        Console.WriteLine(odpowiedzSerwera);
        try {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
        catch{}
    }
}