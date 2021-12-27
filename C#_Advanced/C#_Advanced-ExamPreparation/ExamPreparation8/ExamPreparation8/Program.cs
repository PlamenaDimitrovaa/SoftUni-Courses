using System;
using System.Linq;
using System.Collections.Generic;

namespace ExamPreparation8
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> firstBox = new Queue<int>(firstInput);
            Stack<int> secondBox = new Stack<int>(secondInput);
            var claimedItems = 0;
            while (firstBox.Any() && secondBox.Any())
            {
                var sum = firstBox.Peek() + secondBox.Peek();
                if (sum % 2 == 0)
                {
                    claimedItems += firstBox.Dequeue() + secondBox.Pop();
                }
                else
                {
                    var removed = secondBox.Pop();
                    firstBox.Enqueue(removed);
                }
            }

            if (!firstBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (!secondBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");

            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
