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
            var vlogger = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            string following = "following";
            string followers = "followers";
            while (input != "Statistics")
            {
                string[] inputArgs = input.Split();
                string user = inputArgs[0];
                string action = inputArgs[1];
                string oldUser = inputArgs[2];
                if (action == "joined" && !vlogger.ContainsKey(user))
                {
                    vlogger.Add(user, new Dictionary<string, HashSet<string>>());
                    vlogger[user].Add(following, new HashSet<string>());
                    vlogger[user].Add(followers, new HashSet<string>());

                }
                else if (action == "followed" && vlogger.ContainsKey(user) && vlogger.ContainsKey(oldUser) 
                    && user!= oldUser && !vlogger[oldUser][followers].Contains(user))
                {
                    vlogger[user][following].Add(oldUser);
                    vlogger[oldUser][followers].Add(user);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");

            var sortedVloggers = vlogger.OrderByDescending(x => x.Value[followers].Count)
                .ThenBy(x => x.Value[following].Count);

            int counter = 1;

            foreach (var currentVlogger in sortedVloggers)
            {
                Console.WriteLine($"{counter}. {currentVlogger.Key} : {currentVlogger.Value[followers].Count}" +
                    $" followers, {currentVlogger.Value[following].Count} following");

                if (counter == 1)
                {
                    foreach (var item in currentVlogger.Value[followers].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }

                counter++;
            }
                
        }
    }
}
