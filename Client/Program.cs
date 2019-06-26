using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            string str = "Hello! Send me Time";
            
            string ipServer = "127.0.0.1";
            int port = 12345;
            EndPoint srvEP = new IPEndPoint(IPAddress.Parse(ipServer), port);

            client.SendTo(Encoding.UTF8.GetBytes(str), srvEP);
            //Console.WriteLine("Send size: {0}", recSize);
            
            byte[] buffer = new byte[1024];
            int recSize = client.Receive(buffer);
            string message = Encoding.UTF8.GetString(buffer, 0, recSize);
            Console.WriteLine("Time for this moment: {0}", message);
        }
    }
}
