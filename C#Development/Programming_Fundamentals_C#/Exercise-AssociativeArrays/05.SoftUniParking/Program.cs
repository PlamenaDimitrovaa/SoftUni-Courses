using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> register = new Dictionary<string, string>();
           

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];
                if (command == "register")
                {
                    string username = input[1];
                    string licensePlateNumber = input[2];
                   
                    if(!register.ContainsKey(username))
                    {
                        register.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }

                   
                }
                else if(command == "unregister")
                {
                    string username = input[1];
                    if (!register.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{username} unregistered successfully");
                        register.Remove(username);
                    }
                }

            }

            foreach (var item in register)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
