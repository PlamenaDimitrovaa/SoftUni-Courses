using System;
using System.Linq;

namespace ExamPreparation3
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                var inputInfo = input.Split(":|:");
                string command = inputInfo[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(inputInfo[1]);

                    message = message.Insert(index, " ");
                    Console.WriteLine(message);
                }

                else if (command == "Reverse")
                {
                    string substring = inputInfo[1];
  
                    if (message.Contains(substring))
                    {
                        var reversedSubstr = string.Empty;
                        var index = message.IndexOf(substring);

                        message = message.Remove(index, substring.Length);

                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reversedSubstr += substring[i];
                        }

                        message += reversedSubstr;
                        Console.WriteLine(message);

                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                else if (command == "ChangeAll")
                {
                    string substring = inputInfo[1];
                    string replacement = inputInfo[2];

                    while (message.Contains(substring))
                    {
                        message = message.Replace(substring, replacement);
                    }

                    Console.WriteLine(message);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
