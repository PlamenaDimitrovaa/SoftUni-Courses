using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests =
                new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> participants =
                new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] inputArgs = input.Split(':');
                string contest = inputArgs[0];
                string password = inputArgs[1];
                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] inputArgs = input.Split("=>");
                string contest = inputArgs[0];
                string password = inputArgs[1];
                string username = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                if (!contests.ContainsKey(contest) || contests[contest] != password)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!participants.ContainsKey(username))
                {
                    participants.Add(username, new Dictionary<string, int>());
                }

                if (!participants[username].ContainsKey(contest))
                {
                    participants[username].Add(contest, 0);
                }

                if (participants[username][contest] < points)
                {
                    participants[username][contest] = points;
                }

                input = Console.ReadLine();
            }

            int topSum = 0;
            string name = "";
            foreach (var participant in participants)
            {
                if (participant.Value.Sum(x=>x.Value) > topSum)
                {
                    topSum = participant.Value.Sum(x => x.Value);
                    name = participant.Key;
                }
            }
            Console.WriteLine($"Best candidate is {name} with total {topSum} points.");
            Console.WriteLine("Ranking:");

            foreach (var item in participants.OrderBy(x=>x.Key))
            {
                Console.WriteLine(item.Key);

                foreach (var contest in item.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
