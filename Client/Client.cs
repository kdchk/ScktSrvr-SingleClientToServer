using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Client
    {
        static Socket sckt;
        static void Main(string[] args)
        {
            Console.WriteLine("[Client]");

            sckt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try
            {
                sckt.Connect(localEndPoint);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to connect to remote end point!");
                Main(args);
            }
            Console.WriteLine("Enter message: ");
            string message = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(message);
            sckt.Send(data);
            Console.WriteLine("Data was sent");
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
            sckt.Shutdown(SocketShutdown.Send);
        }
    }
}