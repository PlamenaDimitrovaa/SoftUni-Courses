using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {


            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split("|");

                string piece = input[0];
                string composer = input[1];
                string key = input[2];
                dictionary.Add(piece, new List<string> { composer, key }); ;
            }

            string command = Console.ReadLine();
            while (command != "Stop")
            {
                var inputInfo = command.Split("|");

                string action = inputInfo[0];
                if (action == "Add")
                {
                    string piece = inputInfo[1];
                    string composer = inputInfo[2];
                    string key = inputInfo[3];

                    if (!dictionary.ContainsKey(piece))
                    {
                        dictionary.Add(piece, new List<string> { composer, key });
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if(action == "Remove")
                {
                    string piece = inputInfo[1];
                    if (dictionary.ContainsKey(piece))
                    {
                        dictionary.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if(action == "ChangeKey")
                {
                    string piece = inputInfo[1];
                    string newKey = inputInfo[2];

                    if (dictionary.ContainsKey(piece))
                    {
                        dictionary[piece][1] = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                command = Console.ReadLine();
            }

            foreach (var item in dictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }
        }
    }
}
