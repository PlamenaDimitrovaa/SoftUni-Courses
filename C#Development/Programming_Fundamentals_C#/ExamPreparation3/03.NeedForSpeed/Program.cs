using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split("|");
                string car = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);

                if (!dictionary.ContainsKey(car))
                {
                    dictionary.Add(car, new List<int> { mileage, fuel });
                }

                string command = Console.ReadLine();

                while (command != "Stop")
                {
                    var inputInfo = command.Split(" : ");
                    string action = inputInfo[0];

                    if (action == "Drive")
                    {
                        string carName = inputInfo[1];
                        int distance = int.Parse(inputInfo[2]);
                        int fuelNeeded = int.Parse(inputInfo[3]);

                        if (fuel < fuelNeeded)
                        {
                            Console.WriteLine($"Not enough fuel to make that ride");
                        }
                        else
                        {
                            mileage += distance;
                            fuel -= fuelNeeded;
                            Console.WriteLine($"{carName} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                        }

                        if (dictionary.ContainsKey(carName))
                        {
                            if (mileage >= 100000)
                            {
                                dictionary.Remove(carName);
                                Console.WriteLine($"Time to sell the {carName}!");
                            }
                        }

                    }
                    else if (action == "Refuel")
                    {
                        string carName = inputInfo[1];
                        int fuelNeeded = int.Parse(inputInfo[2]);

                        int differentFuel = 75 - dictionary[carName][1];
                        dictionary[carName][1] += fuelNeeded;

                        if (dictionary[carName][1] > 75)
                        {
                            dictionary[carName][1] = 75;
                            differentFuel = fuelNeeded;
                        }

                        Console.WriteLine($"{carName} refueled with {differentFuel} liters");
                    }
                    else if (action == "Revert")
                    {
                        string carName = inputInfo[1];

                        int km = int.Parse(inputInfo[2]);

                        mileage -= km;


                        if (mileage <= 10000)
                        {
                            mileage = 10000;

                        }
                        else
                        {

                            Console.WriteLine($"{carName} mileage decreased by {km} kilometers");
                        }
                    }

                    command = Console.ReadLine();
                }

                foreach (var item in dictionary)
                {
                    Console.WriteLine($"{car} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt.");
                }
            }


        }

    }
}

