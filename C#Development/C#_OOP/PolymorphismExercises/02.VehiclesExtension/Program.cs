using System;

namespace _02.VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();
            var carFuelQty = double.Parse(carInfo[1]);
            var carLittersPerKm = double.Parse(carInfo[2]);
            var carTankCapacity = double.Parse(carInfo[3]);
            IVehicle car = new Car(carFuelQty, carLittersPerKm, carTankCapacity);

            var truckInfo = Console.ReadLine().Split();
            var truckFuelQty = double.Parse(truckInfo[1]);
            var truckLittersPerKm = double.Parse(truckInfo[2]);
            var truckTankCapacity = double.Parse(truckInfo[3]);
            IVehicle truck = new Truck(truckFuelQty, truckLittersPerKm, truckTankCapacity);

            var busInfo = Console.ReadLine().Split();
            var busFuelQty = double.Parse(busInfo[1]);
            var busLittersPerKm = double.Parse(busInfo[2]);
            var busTankCapacity = double.Parse(busInfo[3]);
            IVehicle bus = new Bus(busFuelQty, busLittersPerKm, busTankCapacity);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commands = Console.ReadLine().Split();
                var action = commands[0];
                var vehicle = commands[1];
                double value = double.Parse(commands[2]);
                try
                {
                    if (action == "Drive")
                    {                      
                        if (vehicle == "Car")
                        {
                            if (car.CanDrive(value))
                            {
                                car.Drive(value);
                                Console.WriteLine($"Car travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine("Car needs refueling");
                            }
                        }
                        else if (vehicle == "Truck")
                        {
                            if (truck.CanDrive(value))
                            {
                                truck.Drive(value);
                                Console.WriteLine($"Truck travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine("Truck needs refueling");
                            }
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.IsEmpty = false;
                            if (bus.CanDrive(value))
                            {
                                bus.Drive(value);
                                Console.WriteLine($"Bus travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine("Bus needs refueling");
                            }
                        }
                    }
                    else if (action == "Refuel")
                    {
                        if (vehicle == "Truck")
                        {
                            truck.Refuel(value);
                        }
                        else if (vehicle == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(value);
                        }
                    }
                    else if (action == "DriveEmpty")
                    {
                        bus.IsEmpty = true;
                        if (bus.CanDrive(value))
                        {
                            bus.Drive(value);
                            Console.WriteLine($"Bus travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Bus needs refueling");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");

        }
    }
}
 
