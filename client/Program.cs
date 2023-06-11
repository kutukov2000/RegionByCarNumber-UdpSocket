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
        const string IpAddress = "192.168.3.48";
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient();

            // create server endpoint
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpAddress), port);

            string message = string.Empty;
            do
            {
                // write a message from keyboard
                Console.Write("Enter a car number (enter 'END' to exit): ");
                message = Console.ReadLine();

                // create byte array to send
                byte[] data = Encoding.UTF8.GetBytes(message);

                // send data to the server
                udpClient.Send(data, data.Length, endPoint);

            } while (message != "END");

            Console.WriteLine("Closing the client application...");
        }
    }
}
