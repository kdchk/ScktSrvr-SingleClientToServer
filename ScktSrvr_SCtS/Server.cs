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
            sckt.Bind(new IPEndPoint(0, 1234));
            sckt.Listen(100);

            Socket accepted = sckt.Accept();
            Buffer = new byte[accepted.SendBufferSize];
            int bytesRead = accepted.Receive(Buffer);

            byte[] formatted = new byte[bytesRead];
            for (int i = 0; i < bytesRead; i++)
                formatted[i] = Buffer[i];

            string strData = Encoding.ASCII.GetString(formatted);
            Console.WriteLine(strData);
            Console.ReadKey();
            sckt.Shutdown(SocketShutdown.Both);
            accepted.Shutdown(SocketShutdown.Both);


        }
    }
}