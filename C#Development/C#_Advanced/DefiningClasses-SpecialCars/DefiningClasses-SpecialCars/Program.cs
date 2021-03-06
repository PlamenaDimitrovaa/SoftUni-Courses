using CarManufacturer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses_SpecialCars
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfTires = new List<Tire[]>();
            var listOftEngines = new List<Engine>();
            var listOfCars = new List<Car>();

            string commandForTires;
            while ((commandForTires = Console.ReadLine()) != "No more tires")
            {
                string[] tireInfo = commandForTires.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var tempListOfTires = new List<Tire>();
                for (int i = 0; i < 8; i += 2)
                {
                    int year = int.Parse(tireInfo[i]);
                    double pressure = double.Parse(tireInfo[i + 1]);
                    var currentTire = new Tire(year, pressure);
                    tempListOfTires.Add(currentTire);
                }

                var currentArrayOfTires = tempListOfTires.ToArray();
                listOfTires.Add(currentArrayOfTires);
            }

            string commandForEngine;
            while ((commandForEngine = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = commandForEngine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);
                var newEngine = new Engine(horsePower, cubicCapacity);
                listOftEngines.Add(newEngine);
            }

            string commandForCar;
            while ((commandForCar = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = commandForCar.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);
                if (engineIndex >= 0 && engineIndex < listOftEngines.Count && tiresIndex >= 0 && tiresIndex < listOfTires.Count)
                {
                    Engine engine = listOftEngines[engineIndex];
                    Tire[] tires = listOfTires[tiresIndex];

                    var newCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);
                    listOfCars.Add(newCar);
                }
            }

            var filterCars = listOfCars.Where(car => car.Year >= 2017 && car.Engine.HorsePower > 330).ToList();
            foreach (var car in filterCars)
            {
                double sumOfPressure = 0;
                foreach (var tire in car.Tires)
                {
                    sumOfPressure += tire.Pressure;
                }

                if (sumOfPressure >= 9 && sumOfPressure <= 10)
                {
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }
            }


        }
    }
}
