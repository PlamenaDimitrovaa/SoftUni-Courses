using System;

namespace CarManufacturer
{
    public class StartUp
    {

        public class Car
        {
            public Car()
            {
                Make = "VW";
                Model = "Golf";
                Year = 2025;
                FuelQuantity = 200;
                FuelConsumption = 10;
            }
 

            public Car(string make, string model, int year)
            {
                Year = year;
            }

            public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
                : this(make, model, year)
            {
                FuelQuantity = fuelQuantity;
                FuelConsumption = fuelConsumption;
            }

            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public double FuelQuantity { get; set; }
            public double FuelConsumption { get; set; }

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
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());
            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

        }
    }
}
