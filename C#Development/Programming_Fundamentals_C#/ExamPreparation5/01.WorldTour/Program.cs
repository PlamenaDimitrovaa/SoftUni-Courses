using System;

namespace ExamPreparation5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Travel")
            {
                var inputInfo = command.Split(':');             

                if (command.Contains("Add Stop"))
                {
                    int index = int.Parse(inputInfo[1]);
                    string text = inputInfo[2];

                    if (index >= 0 && index < input.Length)
                    {
                        input = input.Insert(index, text);
                    }

                    Console.WriteLine(input);
                  
                }
                else if (command.Contains("Remove Stop"))
                {
                    int startIndex = int.Parse(inputInfo[1]);
                    int endIndex = int.Parse(inputInfo[2]);
                    

                    if (startIndex >= 0 && endIndex < input.Length)
                    {
                        input = input.Remove(startIndex, endIndex - startIndex + 1);
                    }

                    Console.WriteLine(input);
                }
                else if (command.Contains("Switch"))
                {
                    string oldString = inputInfo[1];
                    string newString = inputInfo[2];

                    if(input.Contains(oldString))
                    {
                        input = input.Replace(oldString, newString);
                    }

                    Console.WriteLine(input);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}
