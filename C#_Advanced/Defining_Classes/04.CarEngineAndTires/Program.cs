using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public class Engine
        {
            public int HorsePower { get; set; }
            public double CubicCapacity { get; set; }
            public Engine(int horsePower, double cubicCapacity)
            {
                HorsePower = horsePower;
                CubicCapacity = cubicCapacity;
            }
        }
        public class Tire
        {
            public int Year { get; set; }
            public double Pressure { get; set; }

            public Tire(int year, double pressure)
            {
                Year = year;
                Pressure = pressure;
            }
        }
        public class Car
        {

            public Car(string make, string model, int year, double fuelQuantity,
                double fuelConsumption)
            {
                Make = make;
                Model = model;
                Year = year;
                FuelQuantity = fuelQuantity;
                FuelConsumption = fuelConsumption;
            }

            public Car(string make, string model, int year, double fuelQuantity,
                double fuelConsumption, Engine engine, Tire[] tires)
                :this(make, model, year, fuelQuantity,fuelConsumption)
            {
                Engine = engine;
                Tires = tires;
            }

            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public double FuelQuantity { get; set; }
            public double FuelConsumption { get; set; }
            public Engine Engine { get; set; }
            public Tire[] Tires { get; set; }

            public void Drive(double distance)
            {
                var consumption = (FuelQuantity - distance) * FuelConsumption;
                if (consumption > 0)
                {
                    FuelQuantity -= consumption;
                }
                else
                {
                    Console.WriteLine("Not enough fuel to perform this trip!");
                }
            }

            public string WhoAmI()
            {
                return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}";
            }
        }
        static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2,2.3),
            };

            var engine = new Engine(560, 6300);
            var car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

        }
    }
}
