using System;
using System.Text.RegularExpressions;

namespace _02.Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int totalCal = 0;
            int neededDay = 0;

            Regex regText = new Regex(@"(#|\|)+(?<name>[A-Z *a-z]+)\1(?<date>[\d]{2}\/[\d]{2}\/[\d]{2})\1(?<cal>[\d]+)\1");

            MatchCollection match = regText.Matches(text);
            
            foreach (Match mathches in match)
            {
                string name = mathches.Groups["name"].Value;
                string date = mathches.Groups["date"].Value;
                int cal = int.Parse(mathches.Groups["cal"].Value);

                totalCal += cal;
            }

            neededDay = totalCal / 2000;

            Console.WriteLine($"You have food to last you for: {neededDay} days!");
            foreach (Match mathches in match)
            {
                string name = mathches.Groups["name"].Value;
                string date = mathches.Groups["date"].Value;
                int cal = int.Parse(mathches.Groups["cal"].Value);

                Console.WriteLine($"Item: {name}, Best before: {date}, Nutrition: {cal}");
            }

        }
    }
}
