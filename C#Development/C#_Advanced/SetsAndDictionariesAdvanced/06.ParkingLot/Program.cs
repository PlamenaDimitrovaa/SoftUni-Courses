using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            HashSet<string> set = new HashSet<string>();

            while (command != "END")
            {
                string[] input = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = input[0];
                string carNumber = input[1];
                if (direction == "IN")
                {
                    set.Add(carNumber);
                }
                else if(direction == "OUT")
                {
                    set.Remove(carNumber);
                }
               
                command = Console.ReadLine();
            }

            if (set.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (var car in set)
            {
                Console.WriteLine(car);
            }
        }
    }
}
