using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ScktSrvr_SCtS
{
    class Server
    {
        static byte[] Buffer { get; set; }
        static Socket sckt;
        static void Main(string[] args)
        {
            Console.WriteLine("[Server]");

            sckt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("1");
            sckt.Bind(new IPEndPoint(0, 1234));
            Console.WriteLine("2");
            sckt.Listen(100);
            Console.WriteLine("3");

            Socket accepted = sckt.Accept();
            Console.WriteLine("4");
            Buffer = new byte[accepted.SendBufferSize];
            Console.WriteLine("5");
            int bytesRead = accepted.Receive(Buffer);
            Console.WriteLine("6");

            byte[] formatted = new byte[bytesRead];
            Console.WriteLine("7");
            for (int i = 0; i < bytesRead; i++)
                formatted[i] = Buffer[i];
            Console.WriteLine("8");

            string strData = Encoding.ASCII.GetString(formatted);
            Console.WriteLine("9");
            Console.WriteLine(strData);
            Console.WriteLine("10");
            Console.ReadKey();
            sckt.Shutdown(SocketShutdown.Both);
            accepted.Shutdown(SocketShutdown.Both);


        }
    }
}