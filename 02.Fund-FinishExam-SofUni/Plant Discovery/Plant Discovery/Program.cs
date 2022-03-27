using System;
using System.Collections.Generic;

namespace Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split("<->");
                string name = command[0];
                int rating = int.Parse(command[1]);

                if (!dic.ContainsKey(name))
                {
                    dic.Add(name, new List<int>() { rating});
                }
                else
                {
                    dic[name][0] += rating;
                }
            }

            string commandPlant = Console.ReadLine();

            while (commandPlant != "Exhibition")
            {
                string[] token = commandPlant.Split(":");

                if (token[0]=="Rate")
                {
                    string[] aboutPlant = token[1].Split(" - ");
                    string namePlant = aboutPlant[0];
                    int plantRating = int.Parse(aboutPlant[1]);

                    if (dic.ContainsKey(namePlant))
                    {
                        dic[namePlant][1] += plantRating;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (token[0] == "Update")
                {
                    string[] aboutPlant = token[0].Split(" - ");
                    string namePlant = aboutPlant[0];
                    int plantRating = int.Parse(aboutPlant[1]);

                    if (dic.ContainsKey(namePlant))
                    {
                        dic[namePlant][0] = plantRating;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (token[0] == "Reset")
                {
                    string[] aboutPlant = token[0].Split(" - ");
                    string namePlant = aboutPlant[0];

                    if (dic.ContainsKey(namePlant))
                    {
                        dic[namePlant][1] = 0;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                commandPlant = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");
            

            
            foreach (var item in dic)
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: {0}");
            }
        }
    }
}
