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
        const string IpAddress = "192.168.3.48";
        static void Main(string[] args)
        {
            

            Dictionary<string, string> CarNumbers = new Dictionary<string, string>
            {
                { "AA", "Київ" },
                { "KA", "Київ" },

                { "AK", "АР Крим" },
                { "KK", "АР Крим" },

                { "AB", "Вінницька область" },
                { "KB", "Вінницька область" },

                { "AC", "Волинська область" },
                { "KC", "Волинська область" },

                { "AE", "Дніпропетровська область" },
                { "KE", "Дніпропетровська область" },

                { "AH", "Донецька область" },
                { "KH", "Донецька область" },

                { "AI", "Київська область" },
                { "KI", "Київська область" },

                { "AM", "Житомирська область" },
                { "KM", "Житомирська область" },

                { "AO", "Закарпатська область" },
                { "KO", "Закарпатська область" },

                { "AP", "Запорізька область" },
                { "KP", "Запорізька область" },

                { "AT", "Івано-Франківська область" },
                { "KT", "Івано-Франківська область" },

                { "AX", "Харківська область" },
                { "KX", "Харківська область" },

                { "BA", "Кіровоградська область" },
                { "HA", "Кіровоградська область" },

                { "BB", "Луганська область" },
                { "HB", "Луганська область" },

                { "BC", "Львівська область" },
                { "HC", "Львівська область" },

                { "BE", "Миколаївська область" },
                { "HE", "Миколаївська область" },

                { "BH", "Одеська область" },
                { "HH", "Одеська область" },

                { "BI", "Полтавська область" },
                { "HI", "Полтавська область" },

                { "BK", "Рівненська область" },
                { "HK", "Рівненська область" },

                { "BM", "Сумська область" },
                { "HM", "Сумська область" },

                { "BO", "Тернопільська область" },
                { "HO", "Тернопільська область" },

                { "BT", "Херсонська область" },
                { "HT", "Херсонська область" },

                { "BX", "Хмельницька область" },
                { "HX", "Хмельницька область" },

                { "CA", "Черкаська область" },
                { "IA", "Черкаська область" },

                { "CB", "Чернігівська область" },
                { "IB", "Чернігівська область" },

                { "CE", "Чернівецька область" },
                { "IE", "Чернівецька область" }
            };

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpAddress), port);

            // create UDP socket
            UdpClient server = new UdpClient(endPoint); // bind to endpoint

            while (true)
            {
                Console.WriteLine("Waiting for the request...");

                IPEndPoint clientEndPoint = null; // stores sender endpoint

                byte[] request = server.Receive(ref clientEndPoint); // wait until new data received

                string message = Encoding.UTF8.GetString(request);

                if (CarNumbers.ContainsKey(message))
                    Console.WriteLine($"Number: {message} Region: {CarNumbers[message]}\n");
                else
                    Console.WriteLine("Incorrect Number\n");
            }
        }
    }
}
