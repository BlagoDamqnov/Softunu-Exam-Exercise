using System;
using System.Collections.Generic;

namespace _03.The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string[] pieces = Console.ReadLine().Split("|");
                string key = pieces[0];
                string author = pieces[1];
                string tonalnost = pieces[2];

                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, new List<string>() { author, tonalnost });
                }
            }

            string command = Console.ReadLine();

            while (command!="Stop")
            {
                string[] token = command.Split("|");
                if (token[0]=="Add")
                {
                    string piece = token[1];
                    string comp = token[2];
                    string tonalnost = token[3];

                    if (!dic.ContainsKey(piece))
                    {
                        dic.Add(piece, new List<string>() { comp, tonalnost });
                        Console.WriteLine($"{piece} by {comp} in {tonalnost} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (token[0]== "Remove")
                {
                    string piece = token[1];
                    if (dic.ContainsKey(piece))
                    {
                        dic.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (token[0]== "ChangeKey")
                {
                    string piece = token[1];
                    string newKey = token[2];
                    if (dic.ContainsKey(piece))
                    {
                        dic[piece][1] = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                command = Console.ReadLine();
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }
        }
    }
}
