using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SantaFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var materials = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var magicLevel = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(materials);
            Queue<int> queue = new Queue<int>(magicLevel);

            var dolls = 0; //150
            var trains = 0; //250
            var bears = 0; //300
            var bicycles = 0; //400

            while (stack.Any() && queue.Any())
            {
                var totalMagicLevel = stack.Peek() * queue.Peek();
                if (totalMagicLevel == 150)
                {
                    dolls++;
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (totalMagicLevel == 250)
                {
                    trains++;
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (totalMagicLevel == 300)
                {
                    bears++;
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (totalMagicLevel == 400)
                {
                    bicycles++;
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (totalMagicLevel < 0)
                {
                    var sum = stack.Pop() + queue.Dequeue();
                    stack.Push(sum);
                }
                else if (totalMagicLevel > 0)
                {
                    queue.Dequeue();
                    var increased = stack.Pop();
                    stack.Push(increased + 15);
                }
                else if (totalMagicLevel == 0)
                {
                    if (stack.Peek() == 0)
                    {
                        stack.Pop();
                    }

                    if (queue.Peek() == 0)
                    {
                        queue.Dequeue();
                    }
                }
            }

            if (dolls > 0 && trains > 0 || bears > 0 && bicycles > 0)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (stack.Any())
            {
                Console.WriteLine($"Materials left: {String.Join(", ", stack)}");
            }

            if (queue.Any())
            {
                Console.WriteLine($"Magic left: {String.Join(", ", queue)}");
            }

            var sd = new SortedDictionary<string, int>();
            sd.Add("Doll", dolls);
            sd.Add("Teddy bear", bears);
            sd.Add("Bicycle", bicycles);
            sd.Add("Wooden train", trains);

            foreach (var present in sd)
            {
                if (present.Value > 0)
                {
                    Console.WriteLine($"{present.Key}: {present.Value}");
                }
            }
        }
    }
}
