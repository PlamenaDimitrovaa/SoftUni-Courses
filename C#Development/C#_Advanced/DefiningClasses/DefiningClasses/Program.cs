using System;

namespace DefiningClasses
{
    class Program
    {

        class Engine
        {
            public Engine(int horsePower, double cubicCapacity)
            {
                HorsePower = horsePower;
                CubicCapacity = cubicCapacity;
            }
            public int HorsePower { get; set; }
            public double CubicCapacity { get; set; }
        }

        class Tire
        {
            public Tire(int year, double pressure)
            {
                Year = year;
                Pressure = pressure;
            }
            public int Year { get; set; }
            public double Pressure { get; set; }

        }

        class Car
        {
            public Car(string make, string model, int year,
                double fuelQuantity, double fuelConsumption,
                Engine engine, Tire[] tires)
            {
                Make = make;
                Model = model;
                Year = year;
                FuelQuantity = fuelQuantity;
                FuelConsumption = fuelConsumption;
                Engine = engine;
                Tires = tires;
            }

            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public double FuelConsumption { get; set; }
            public double FuelQuantity { get; set; }
            public Engine Engine { get; set; }
            public Tire[] Tires { get; set; }

            public string WhoIAm()
            {
                return $"{Make} {Model} ({Year}) ({FuelQuantity} liters of fuel)";
            }

            public void Drive(double distance)
            {
                var consumption = distance * (FuelConsumption / 100.0);
                if (consumption <= FuelQuantity)
                {
                    FuelQuantity -= consumption;
                }
                else
                {
                    Console.WriteLine($"Cannot drive {distance:F2} km.");
                }
            }


        }
        static void Main(string[] args)
        {
            Engine engine = new Engine(300, 3000);
            Tire[] tires = new Tire[]
            {
                new Tire(2021, 2.8),
                new Tire(2021, 2.8),
                new Tire(2020, 2.6),
                new Tire(2020, 2.6),

            };

            Car car = new Car("Audi", "A7", 2017, 80, 15, engine, tires);
            Console.WriteLine(car.WhoIAm());
            car.Drive(200);
            Console.WriteLine(car.WhoIAm());
            car.Drive(200);
            Console.WriteLine(car.WhoIAm());
            car.Drive(100);
            Console.WriteLine(car.WhoIAm());
            car.Drive(34);
        }
    }
}
