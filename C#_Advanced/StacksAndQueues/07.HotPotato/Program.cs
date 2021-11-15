using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> kids = new Queue<string>();

            foreach (var name in names)
            {
                kids.Enqueue(name);
            }

            while (kids.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    var potatoKid = kids.Dequeue();
                    kids.Enqueue(potatoKid);

                }

                var kidToRemove = kids.Dequeue();
                Console.WriteLine($"Removed {kidToRemove}");
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
