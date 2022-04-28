using System;

namespace ExamPreparation4
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Registration")
            {
                var inputInfo = command.Split();
                string action = inputInfo[0];
                if (action == "Letters")
                {
                    string lowerUpper = inputInfo[1];
                    if (lowerUpper == "Lower")
                    {
                        username = username.ToLower();

                    }
                    else if (lowerUpper == "Upper")
                    {
                        username = username.ToUpper();
                    }

                    Console.WriteLine(username);
                }
                else if (action == "Reverse")
                {
                    int startIndex = int.Parse(inputInfo[1]);
                    int endIndex = int.Parse(inputInfo[2]);
                    if (startIndex >= 0 && endIndex < username.Length)
                    {
                        string substring = username.Substring(startIndex, endIndex - startIndex + 1);
                        string reversed = String.Empty;
                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reversed += substring[i];
                        }

                        Console.WriteLine(reversed);
                    }
                    else
                    {
                        continue;
                    }

                }
                else if(action == "Substring")
                {
                    string substring = inputInfo[1];

                    if (username.Contains(substring))
                    {
                        int index = username.IndexOf(substring);
                        username = username.Remove(index, substring.Length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The username {username} doesn't contain {substring}.");
                    }
                }
                else if(action == "Replace")
                {
                    char chaar = char.Parse(inputInfo[1]);

                    if (username.Contains(chaar))
                    {
                       username =  username.Replace(chaar, '-');
                    }

                    Console.WriteLine(username);

                }
                else if (action == "IsValid")
                {
                    char chaar = char.Parse(inputInfo[1]);

                    if (username.Contains(chaar))
                    {
                        Console.WriteLine("Valid username.");
                    }
                    else
                    {
                        Console.WriteLine($"{chaar} must be contained in your username.");
                    }

                }
                command = Console.ReadLine();
            }
        }
    }
}
