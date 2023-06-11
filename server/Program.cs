using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    internal class Program
    {
        const short port = 6666;
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(port);
            while (true)
            {
                Console.WriteLine("Wait for client reques");

                IPEndPoint clientEndPoint = null;
                byte[] requesData = server.Receive(ref clientEndPoint);

                string message = Encoding.UTF8.GetString(requesData);

                Console.WriteLine($"Request message: {message} from: {clientEndPoint}");
            }
        }
    }
}
