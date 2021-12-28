using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation9
{
    class Program
    {
        static void Main(string[] args)
        {
            var theEatingCapacityOfASingleGuest = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var platess = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> plates = new Stack<int>(platess);
            Queue<int> guests = new Queue<int>(theEatingCapacityOfASingleGuest);
            var wastedFood = 0;
            var leftFood = 0;

            while (guests.Any())
            {
                if (plates.Peek() >= guests.Peek())
                {
                    leftFood = plates.Peek() - guests.Peek();
                    wastedFood += leftFood;
                    plates.Pop();
                    guests.Dequeue();
                }
            }

            if (plates.Any())
            {
                Console.WriteLine($"Plates: {String.Join(" ", plates)}");
            }
            else if (guests.Any())
            {
                Console.WriteLine($"Guests: {String.Join(" ", guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
