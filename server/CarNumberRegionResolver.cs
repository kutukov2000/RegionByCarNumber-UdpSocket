using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace server
{
    public class CarNumberRegionResolver
    {
        private Dictionary<string, string> CarNumbers;

        public CarNumberRegionResolver()
        {
            var serializer=new DictionarySerializer<string, string>();
            CarNumbers = serializer.Deserialize("dictionary.xml");
        }
        private bool CheckNumber(string message)
        {
            string pattern = @"^[A-Z]{2}\d{4}[A-Z]{2}$";

            Match match = Regex.Match(message, pattern);

            return match.Success;
        }
        public void FindRegion(string message)
        {
            if (CheckNumber(message.ToUpper()))
            {
                if (CarNumbers.ContainsKey(message.ToUpper().Substring(0, 2)))
                    Console.WriteLine($"Number: {message.ToUpper()} Region: {CarNumbers[message.ToUpper().Substring(0, 2)]}\n");
                else
                    Console.WriteLine("Incorrect Number\n");
            }
            else
                Console.WriteLine("Incorrect Number\n");
        }
    }
}