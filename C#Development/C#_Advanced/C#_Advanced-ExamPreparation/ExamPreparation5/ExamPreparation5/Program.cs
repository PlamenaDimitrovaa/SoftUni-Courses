using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation5
{
    class Program
    {
        static void Main(string[] args)
        {
            var liquids = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var ingredients = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(liquids);
            Stack<int> stack = new Stack<int>(ingredients);

            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitpieCount = 0;

            while (queue.Any() && stack.Any())
            {
                var currentSum = queue.Peek() + stack.Peek();
                if (currentSum == 25)
                {
                    breadCount++;
                    queue.Dequeue();
                    stack.Pop();
                }
                else if (currentSum == 50)
                {
                    cakeCount++;
                    queue.Dequeue();
                    stack.Pop();
                }
                else if (currentSum == 75)
                {
                    pastryCount++;
                    queue.Dequeue();
                    stack.Pop();
                }
                else if (currentSum == 100)
                {
                    fruitpieCount++;
                    queue.Dequeue();
                    stack.Pop();
                }
                else
                {
                    queue.Dequeue();
                    var removed = stack.Pop();
                    stack.Push(removed + 3);
                }
            }

            if (breadCount >= 1 && cakeCount >= 1 && pastryCount >= 1 && fruitpieCount >= 1)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (queue.Any())
            {
                Console.WriteLine($"Liquids left: {String.Join(", ", queue)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (stack.Any())
            {
                Console.WriteLine($"Ingredients left: {String.Join(", ", stack)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            Console.WriteLine($"Bread: {breadCount}");
            Console.WriteLine($"Cake: {cakeCount}");
            Console.WriteLine($"Fruit Pie: {fruitpieCount}");
            Console.WriteLine($"Pastry: {pastryCount}");

        }
    }
}
