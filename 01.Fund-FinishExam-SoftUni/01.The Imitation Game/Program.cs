using System;

namespace _01.The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = Console.ReadLine();
            string command = Console.ReadLine();

            while (command!="Decode")
            {
                string[] token = command.Split("|");
                if (token[0]=="Move")
                {
                    int numberOfLetters = int.Parse(token[1]);
                    string substring = code.Substring(0, numberOfLetters);
                    code = code.Remove(0,substring.Length);
                    code = code + substring;
                }
                else if (token[0]=="Insert")
                {
                    int index = int.Parse(token[1]);
                    string value = token[2];

                     code = code.Insert(index, value);
                }
                else if (token[0]=="ChangeAll")
                {
                    string substring = token[1];
                    string substitute = token[2];
                    if (code.Contains(substring))
                    {
                        code = code.Replace(substring, substitute);
                    }
                }
                
                command = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {code}");
        }
    }
}
