using System;
using System.Collections.Generic;

namespace ExamPreparation2
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();      
            string command = Console.ReadLine();

            while (command != "Decode")
            {
                var inputInfo = command.Split("|");
                string action = inputInfo[0];

                if (action == "Move")
                {
                    int n = int.Parse(inputInfo[1]);

                    string remove = message.Substring(0, n);
                    message = message.Remove(0, remove.Length);                
                    message = message.Insert(message.Length, remove);
                }
                else if(action == "Insert")
                {
                    int index = int.Parse(inputInfo[1]);
                    string value = inputInfo[2];
                    message = message.Insert(index, value);

                }
                else if(action == "ChangeAll")
                {
                    string substring = inputInfo[1];
                    string replacement = inputInfo[2];
                    if (message.Contains(substring))
                    {
                        message = message.Replace(substring, replacement);
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
