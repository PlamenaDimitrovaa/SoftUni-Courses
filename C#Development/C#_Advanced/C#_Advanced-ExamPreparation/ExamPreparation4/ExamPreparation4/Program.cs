using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation4
{
    class Program
    {
        static void Main(string[] args)
        {
            var bombEffects = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var bombCasings = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int currentValue = 0;

            Queue<int> queue = new Queue<int>(bombEffects);
            Stack<int> stack = new Stack<int>(bombCasings);

            int daturaCount = 0;
            int cherryCount = 0;
            int smokeCount = 0;

            while (queue.Any() && stack.Any())
            {
                currentValue = queue.Peek() + stack.Peek();

                if (currentValue == 40 || currentValue == 60 || currentValue == 120)
                {
                    queue.Dequeue();
                    stack.Pop();

                    if (currentValue == 40)
                    {
                        daturaCount++;

                    }
                    else if (currentValue == 60)
                    {
                        cherryCount++;
                    }
                    else if (currentValue == 120)
                    {
                       smokeCount++;
                    }
                }
                else
                {
                    int decreased = stack.Pop();
                    stack.Push(decreased - 5);
                }

                if (daturaCount >= 3 && cherryCount >= 3 && smokeCount >= 3)
                {
                    break;
                }
            }

            if (daturaCount >= 3 && cherryCount >= 3 && smokeCount >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (queue.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {String.Join(", ", queue)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (stack.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {String.Join(", ", stack)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryCount}");
            Console.WriteLine($"Datura Bombs: {daturaCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeCount}");



        }
    }
}
