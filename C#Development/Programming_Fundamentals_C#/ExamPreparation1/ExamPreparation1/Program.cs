using System;

namespace ExamPreparation1
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string command = Console.ReadLine();
            string newPassword = String.Empty;
            while (command != "Done")
            {
                string[] inputInfo = command.Split();
                string action = inputInfo[0];
                if (action == "TakeOdd")
                {
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                           
                            newPassword += password[i];
                        }
                    }

                    password = newPassword;
                    Console.WriteLine(password);
                   
                }
                else if (action == "Cut")
                {
                    int index = int.Parse(inputInfo[1]);
                    int length = int.Parse(inputInfo[2]);


                    password = password.Remove(index, length);
                    Console.WriteLine(password);
                }
                else if(action == "Substitute")
                {
                    string substring = inputInfo[1];
                    string substitute = inputInfo[2];
                    if (password.Contains(substring))
                    {
                        while (password.Contains(substring))
                        {
                            password = password.Replace(substring, substitute);
                        }

                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
