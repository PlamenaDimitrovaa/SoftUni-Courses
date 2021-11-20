using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquids = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] ingredients = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int sum = 0;
            bool success = false;
            Queue<int> queue = new Queue<int>(liquids);
            Stack<int> stack = new Stack<int>(ingredients);
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("Bread", 0);
            dictionary.Add("Cake", 0);
            dictionary.Add("Fruit Pie", 0);
            dictionary.Add("Pastry", 0);

            while (queue.Count > 0 && stack.Count > 0)
            {
                sum = queue.Peek() + stack.Peek();
                if (sum == 25)
                {
                    queue.Dequeue();
                    stack.Pop();
                    dictionary["Bread"]++;
                }
                else if (sum == 50)
                {
                    queue.Dequeue();
                    stack.Pop();
                    dictionary["Cake"]++;
                }
                else if (sum == 75)
                {
                    queue.Dequeue();
                    stack.Pop();
                    dictionary["Pastry"]++;
                }
                else if (sum == 100)
                {
                    queue.Dequeue();
                    stack.Pop();
                    dictionary["Fruit Pie"]++;
                }
                else
                {
                    queue.Dequeue();
                    int increased = stack.Pop();
                    stack.Push(increased + 3);
                }

                if (dictionary["Bread"] >= 1 && dictionary["Cake"] >= 1 && 
                    dictionary["Fruit Pie"] >= 1 && dictionary["Pastry"] >= 1)
                {
                    success = true;
                    break;
                }
            }

            if (success)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (queue.Count <= 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {String.Join(", ", queue)}");
            }

            if (stack.Count <= 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {String.Join(", ", stack)}");
            }

            foreach (var item in dictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
