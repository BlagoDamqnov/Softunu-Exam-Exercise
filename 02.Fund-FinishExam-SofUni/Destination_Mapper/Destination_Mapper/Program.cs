using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex pattern = new Regex(@"([=|\/])(?<name>[A-Z][a-zA-Z]{2,})\1");

            List<string> destination = new List<string>();

            MatchCollection match = pattern.Matches(text);

            int destinationPoint = 0;

            foreach (Match item in match)
            {
                destination.Add(item.Groups["name"].Value);
            }

            foreach (var item in destination)
            {
                destinationPoint += item.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ",destination)}");
            Console.WriteLine($"Travel Points: {destinationPoint}");
        }
    }
}
