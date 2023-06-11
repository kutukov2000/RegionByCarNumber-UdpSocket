using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace server
{
    public class Program
    {
        const short port = 6666;
        const string IpAddress = "192.168.3.48";
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpAddress), port);

            // create UDP socket
            UdpClient server = new UdpClient(endPoint); // bind to endpoint

            CarNumberRegionResolver carNumberRegionResolver = new CarNumberRegionResolver();
            while (true)
            {
                Console.WriteLine("Waiting for the request...");

                IPEndPoint clientEndPoint = null; // stores sender endpoint

                byte[] request = server.Receive(ref clientEndPoint); // wait until new data received

                string message = Encoding.UTF8.GetString(request);

                carNumberRegionResolver.FindRegion(message);
            }
        }
    }
}