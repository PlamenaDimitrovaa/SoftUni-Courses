using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKilometer = double.Parse(input[2]);
                Car currentCar = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                cars.Add(currentCar);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                var inputInfo = command.Split();
                string carModel = inputInfo[1];
                double amountOfKm = double.Parse(inputInfo[2]);
                Car carForDriving = cars.Where(x => x.Model == carModel).ToList().FirstOrDefault();
                carForDriving.DoesTheCarCanMoveThatDistance(carModel, amountOfKm);

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {

                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
