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
            var wasted = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                int guest = guests.Peek();
                int plate = plates.Peek();

                if (plate >= guest)
                {
                    plate -= guest;

                    if (plate > 0)
                    {
                        wasted += plate;
                    }

                    guests.Dequeue();
                    plates.Pop();
                }
                else
                {
                    guest -= plate;

                    plates.Pop();
                    guests.Dequeue();

                    guests.Enqueue(guest);

                    for (int i = 1; i < guests.Count; i++)
                    {
                        guests.Enqueue(guests.Dequeue());
                    }
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {String.Join(" ", guests)}");
                Console.WriteLine($"Wasted grams of food: {wasted}");
            }
            else
            {
                Console.WriteLine($"Plates: {String.Join(" ", plates)}");
                Console.WriteLine($"Wasted grams of food: {wasted}");
            }
        }
    }
}
