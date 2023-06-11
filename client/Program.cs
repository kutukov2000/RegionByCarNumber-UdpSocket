using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    internal class Program
    {
        const short port = 6666;
        static void Main(string[] args)
        {
            IPEndPoint serverEndPoint=new IPEndPoint(IPAddress.Parse("192.168.3.48"), port);

            UdpClient client = new UdpClient();

            Console.WriteLine("Enter a message: ");
            string message=Console.ReadLine();

            byte[]data=Encoding.UTF8.GetBytes(message);

            client.Send(data, data.Length, serverEndPoint);
        }
    }
}
