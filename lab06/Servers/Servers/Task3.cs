using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Servers;

public class Task3
{
    // public static void Main(string[] args)
    public static void Task3Run()
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
        
        var my_dir = Directory.GetCurrentDirectory();

        while (true)
        {
            int received1 = socketKlienta.Receive(bufor, SocketFlags.None);
            int dl = BitConverter.ToInt32(bufor, 0);

            byte[] bufor2 = new byte[dl];

            int received = socketKlienta.Receive(bufor2, SocketFlags.None);
            string clientMessage = Encoding.UTF8.GetString(bufor2, 0, received);

            if (clientMessage == "!end")
            {
                socketKlienta.Send(Encoding.UTF8.GetBytes("end"));
                try
                {
                    socketSerwera.Shutdown(SocketShutdown.Both);
                    socketSerwera.Close();
                }
                catch
                {
                    // Console.WriteLine(e);
                }
                break;
            }
            else if (clientMessage == "list")
            {
                string[] files = Directory.GetFiles(my_dir);
                string filesString = "Directory: " + my_dir + "\n";
                foreach (string file in files)
                {
                    filesString += file + "\n";
                }
                
                string[] directories = Directory.GetDirectories(my_dir);
                foreach (var dir in directories)
                {
                    filesString += dir + "\n";
                }
                
                
                var echoBytes = Encoding.UTF8.GetBytes(filesString);
                var responseSize = echoBytes.Length;
                var responseSizeBytes = BitConverter.GetBytes(echoBytes.Length);

                socketKlienta.Send(responseSizeBytes, 0);
                socketKlienta.Send(echoBytes, 0);
            }

            else if (clientMessage.StartsWith("in "))
            {
                var new_dir = clientMessage.Substring(3);
                var new_dir_full = Path.Combine(my_dir, new_dir);
                if (Directory.Exists(new_dir_full))
                {
                    my_dir = Path.GetFullPath(new_dir_full);
                    // my_dir = new_dir_full;
                    Console.WriteLine(my_dir);
                    string[] files = Directory.GetFiles(my_dir);
                    string filesString = "Files: \n";
                    foreach (string file in files)
                    {
                        filesString += file + "\n";
                    }

                    string[] directories = Directory.GetDirectories(my_dir);
                    foreach (var dir in directories)
                    {
                        filesString += dir + "\n";
                    }

                    var echoBytes = Encoding.UTF8.GetBytes(filesString);
                    var responseSize = echoBytes.Length;
                    var responseSizeBytes = BitConverter.GetBytes(echoBytes.Length);

                    socketKlienta.Send(responseSizeBytes, 0);
                    socketKlienta.Send(echoBytes, 0);

                }
                else
                {
                    var msg = "Directory does not exist";
                    var echoBytes = Encoding.UTF8.GetBytes(msg);
                    var responseSize = echoBytes.Length;
                    var responseSizeBytes = BitConverter.GetBytes(echoBytes.Length);
                    
                    socketKlienta.Send(responseSizeBytes, 0);
                    socketKlienta.Send(echoBytes, 0);
                }
            }
            else
            {
                var msg = "Unknown command";
                var echoBytes = Encoding.UTF8.GetBytes(msg);
                var responseSize = echoBytes.Length;
                var responseSizeBytes = BitConverter.GetBytes(echoBytes.Length);
                    
                socketKlienta.Send(responseSizeBytes, 0);
                socketKlienta.Send(echoBytes, 0);
            }
        }
        ;

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