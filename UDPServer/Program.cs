using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 12345));

            // начинаем прослушивание
            
            byte[] buffer = new byte[64 * 1024];
            EndPoint clientEndPoint = new IPEndPoint(0, 0);
            int recSize = serverSocket.ReceiveFrom(buffer, ref clientEndPoint);

            Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, recSize));

            string time = DateTime.Now.ToShortTimeString();
            buffer = Encoding.UTF8.GetBytes(time);
            serverSocket.SendTo(buffer, clientEndPoint);
        }
    }
}
