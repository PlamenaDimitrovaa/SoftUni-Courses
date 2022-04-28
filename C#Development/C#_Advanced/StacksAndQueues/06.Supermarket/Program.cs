using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> queue = new Queue<string>();


            while (input != "End")
            {

                if (input != "Paid")
                {
                    queue.Enqueue(input);
                }

                else if (input == "Paid")
                {

                    foreach (var currentName in queue)
                    {
                        Console.WriteLine(currentName);
                    }

                    queue.Clear();

                }


                input = Console.ReadLine();
            }


            Console.WriteLine(queue.Count + " people remaining.");
        }
    }
}
