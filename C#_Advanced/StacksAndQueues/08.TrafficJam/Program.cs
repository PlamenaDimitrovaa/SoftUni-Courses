using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }
                else if (line == "green")
                {
                    for (int i = 0; i < numberOfCars; i++)
                    {
                        if (cars.Count > 0)
                        {
                            var car = cars.Dequeue();
                            Console.WriteLine($"{car} passed!");
                            passedCars++;

                        }
                    }
                }
                else
                {
                    cars.Enqueue(line);
                }
            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
