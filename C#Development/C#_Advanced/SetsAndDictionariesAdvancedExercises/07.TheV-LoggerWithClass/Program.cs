using _07.TheV_LoggerWithClass;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var vlogger = new Dictionary<string, Vlogger>();
  
            while (input != "Statistics")
            {
                string[] inputArgs = input.Split();
                string user = inputArgs[0];
                string action = inputArgs[1];
                string oldUser = inputArgs[2];
                if (action == "joined" && !vlogger.ContainsKey(user))
                {
                    vlogger.Add(user, new Vlogger());
              

                }
                else if (action == "followed" && vlogger.ContainsKey(user) && vlogger.ContainsKey(oldUser)
                    && user != oldUser)
                {
                    vlogger[user].Following.Add(oldUser);
                    vlogger[oldUser].Followers.Add(user);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");

            var sortedVloggers = vlogger.OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count);

            int counter = 1;

            foreach (var currentVlogger in sortedVloggers)
            {
                Console.WriteLine($"{counter}. {currentVlogger.Key} : {currentVlogger.Value.Followers.Count}" +
                    $" followers, {currentVlogger.Value.Following.Count} following");

                if (counter == 1)
                {
                    foreach (var item in currentVlogger.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }

                counter++;
            }

        }
    }
}
