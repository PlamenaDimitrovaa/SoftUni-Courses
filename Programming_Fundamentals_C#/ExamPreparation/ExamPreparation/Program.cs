using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();


            while (command != "Generate")
            {
                var splitted = command.Split(">>>");
                string action = splitted[0];


                if (action == "Contains")
                {
                    string substring = splitted[1];

                    if (input.Contains(substring))
                    {
                        Console.WriteLine($"{input} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (action == "Flip")
                {
                    string upperLower = splitted[1];
                    int startIndex = int.Parse(splitted[2]);
                    int endIndex = int.Parse(splitted[3]);
                    if (upperLower == "Upper")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            char currentChar = char.ToUpper(input[i]);
                            input = input.Remove(i, 1);
                            input = input.Insert(i, currentChar.ToString());
                           
                        }
                    }
                    else if (upperLower == "Lower")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            char currentChar = char.ToLower(input[i]);
                            input = input.Remove(i, 1);
                            input = input.Insert(i, currentChar.ToString());

                        }
                    }

                    Console.WriteLine(input);
                }
                else if (action == "Slice")
                {
                    int startIndex = int.Parse(splitted[1]);
                    int endIndex = int.Parse(splitted[2]);
                    for (int i = endIndex - 1; i >= startIndex; i--)
                    {
                        input = input.Remove(i, 1);
                    }

                    Console.WriteLine(input);

                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {input}");
        }
    }
}
