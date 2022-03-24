using System;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] token = command.Split(":");

                if (token[0] == "Add Stop")
                {
                    int index = int.Parse(token[1]);
                    if (index>=0&&index<word.Length)
                    {
                        string value = token[2];
                        word = word.Insert(index, value);
                    }
                    Console.WriteLine(word);
                }
                else if (token[0]=="Remove Stop")
                {
                    int startIndex = int.Parse(token[1]);
                    int endIndex = int.Parse(token[2]);
                    if (startIndex<endIndex&&startIndex>=0&&endIndex<word.Length)
                    {
                        word = word.Remove(startIndex, endIndex - startIndex+1);
                    }
                    Console.WriteLine(word);
                }
                else if (token[0]=="Switch")
                {
                    string oldString = token[1];
                    string newString = token[2];
                    if (word.Contains(oldString))
                    {
                        word = word.Replace(oldString, newString);
                    }
                    Console.WriteLine(word);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {word}");
        }
    }
}
