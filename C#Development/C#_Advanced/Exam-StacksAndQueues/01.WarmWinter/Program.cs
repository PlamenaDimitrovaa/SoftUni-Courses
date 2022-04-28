using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hats = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] scarfs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(hats);
            Queue<int> queue = new Queue<int>(scarfs);

            Stack<int> priceOfSets = new Stack<int>();
            
            while (stack.Count > 0 && queue.Count > 0)
            {
                if (stack.Peek() > queue.Peek())
                {
                   priceOfSets.Push(stack.Peek() + queue.Peek());
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (queue.Peek() > stack.Peek())
                {
                    stack.Pop();
                   
                }
                else if(queue.Peek() == stack.Peek())
                {
                    int increase =  queue.Dequeue();
                    queue.Enqueue(increase + 1);
                    stack.Pop();
                }
            }
            
            Console.WriteLine($"The most expensive set is: {priceOfSets.Max()}");
            Console.WriteLine(String.Join(" ", priceOfSets.Reverse()));
        }
    }
}
