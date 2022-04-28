using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();
            var carFuelQty = double.Parse(carInfo[1]);
            var carLittersPerKm = double.Parse(carInfo[2]);
            IVehicle car = new Car(carFuelQty, carLittersPerKm);

            var truckInfo = Console.ReadLine().Split();
            var truckFuelQty = double.Parse(truckInfo[1]);
            var truckLittersPerKm = double.Parse(truckInfo[2]);
            IVehicle truck = new Truck(truckFuelQty, truckLittersPerKm);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commands = Console.ReadLine().Split();
                var action = commands[0];
                var vehicle = commands[1];

                if (action == "Drive")
                {
                    double distance = double.Parse(commands[2]);
                    if (vehicle == "Car")
                    {
                        if (car.CanDrive(distance))
                        {
                            car.Drive(distance);
                            Console.WriteLine($"Car travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else if (vehicle == "Truck")
                    {
                        if (truck.CanDrive(distance))
                        {
                            truck.Drive(distance);
                            Console.WriteLine($"Truck travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                }
                else if (action == "Refuel")
                {
                    double liters = double.Parse(commands[2]);
                    if (vehicle == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                    else
                    {
                        car.Refuel(liters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
