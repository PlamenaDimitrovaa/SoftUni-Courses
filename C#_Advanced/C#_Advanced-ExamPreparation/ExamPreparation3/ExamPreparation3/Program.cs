using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation3
{
    class Program
    {
        static void Main(string[] args)
        {
            var lilies = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var roses = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> liliesStack = new Stack<int>(lilies);
            Queue<int> rosesQueue = new Queue<int>(roses);
            int wreaths = 0;
            int store = 0;
            int sum = 0;
            while (liliesStack.Count > 0 && rosesQueue.Count > 0)
            {
               
               sum = liliesStack.Peek() + rosesQueue.Peek();

                if (sum == 15)
                {
                    wreaths++;
                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                }
                else if (sum > 15)
                {
                    int decreased = liliesStack.Pop();
                    liliesStack.Push(decreased - 2);
                }
                else if (sum < 15)
                {
                    store += liliesStack.Pop() + rosesQueue.Dequeue();
                }
            }

            wreaths += store / 15;

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
