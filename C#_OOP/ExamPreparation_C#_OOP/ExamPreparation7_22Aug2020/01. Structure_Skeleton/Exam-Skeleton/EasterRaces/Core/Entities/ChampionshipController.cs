using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driverRep;
        private CarRepository carRep;
        private RaceRepository raceRep;
        public ChampionshipController()
        {
            driverRep = new DriverRepository();
            carRep = new CarRepository();
            raceRep = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            if (driverRep.GetByName(driverName) == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (carRep.GetByName(carModel) == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            IDriver driver = driverRep.GetByName(driverName);
            ICar car = carRep.GetByName(carModel);
            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {

            if (driverRep.GetByName(driverName) == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (raceRep.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            IDriver driver = driverRep.GetByName(driverName);
            IRace race = raceRep.GetByName(raceName);
            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            if (carRep.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            carRep.Add(car);
            if (type == "Muscle")
            {
                return "MuscleCar" + $" { model} is created.";
            }
            else
            {
                return "SportsCar" + $" { model} is created.";
            }
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            if (driverRep.GetByName(driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            driverRep.Add(driver);
            return $"Driver {driver.Name} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRep.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            IRace race = new Race(name, laps);
            raceRep.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            if (raceRep.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            IRace race = raceRep.GetByName(raceName);

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var winners = driverRep.GetAll().OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).ToList();
            var sb = new StringBuilder();
            sb.AppendLine($"Driver {winners[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {winners[1].Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {winners[2].Name} is third in {race.Name} race.");
            raceRep.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
