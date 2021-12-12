using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                List<Tire> tires = new List<Tire>();

                for (int tireIndex = 5; tireIndex <= 12; tireIndex+=2)
                {
                    double tirePressure = double.Parse(input[tireIndex]);
                    int tireAge = int.Parse(input[tireIndex + 1]);
                    Tire tire = new Tire(tireAge, tirePressure);
                    tires.Add(tire);
                }
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<Car> fragileCars = cars.Where(x => x.Cargo.Type == "fragile" &&
                x.Tires.Any(t => t.Pressure < 1)).ToList();
                foreach (var item in fragileCars)
                {
                    Console.WriteLine(item.Model);
                }
            }
            else if (command == "flammable")
            {
                List<Car> flammableCars = cars.Where(x => x.Cargo.Type == "flammable" &&
                x.Engine.Power > 250).ToList();
                foreach (var item in flammableCars)
                {
                    Console.WriteLine(item.Model);
                }
            }
        }
    }
}
