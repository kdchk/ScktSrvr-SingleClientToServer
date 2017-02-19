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
            Console.WriteLine("1");
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            Console.WriteLine("2");
            try
            {
                sckt.Connect(localEndPoint);
                Console.WriteLine("3");
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to connect to remote end point!");
                Console.WriteLine("3.1");
                Main(args);
            }
            Console.WriteLine("Enter message: ");
            string message = Console.ReadLine();
            Console.WriteLine("4");
            byte[] data = Encoding.ASCII.GetBytes(message);
            Console.WriteLine("5");
            sckt.Send(data);
            Console.WriteLine("6");
            Console.WriteLine("Data was sent");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            sckt.Shutdown(SocketShutdown.Send);
        }
    }
}