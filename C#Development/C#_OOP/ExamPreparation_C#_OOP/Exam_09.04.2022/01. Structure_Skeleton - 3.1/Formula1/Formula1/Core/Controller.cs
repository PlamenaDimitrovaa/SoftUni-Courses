using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private IRepository<IPilot> pilotRepository;
        private IRepository<IRace> raceRepository;
        private IRepository<IFormulaOneCar> carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            if(pilotRepository.FindByName(pilotName) == null || pilotRepository.FindByName(pilotName).CanRace)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }

            if(carRepository.FindByName(carModel) == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            IPilot pilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = carRepository.FindByName(carModel);
            pilot.AddCar(car);
            carRepository.Remove(car); 
            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if(raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException($"Race { raceName} does not exist.");
            }

            if(pilotRepository.FindByName(pilotFullName) == null || pilotRepository.FindByName(pilotFullName).CanRace == false
                || raceRepository.FindByName(raceName).Pilots == pilotRepository.FindByName(pilotFullName)) //??
            {
                throw new InvalidOperationException($"Can not add pilot { pilotFullName} to the race.");
            }


            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            IRace race = raceRepository.FindByName(raceName);
            race.AddPilot(pilot);
            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = null;
            if(type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if(type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException($"Formula one car type {type} is not valid.");
            }

            if(carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }

            carRepository.Add(car);
            if(type == "Ferrari")
            {
                return $"Car Ferrari, model {model} is created.";
            }
            else
            {
                return $"Car Williams, model {model} is created.";
            }
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }

            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return $"Pilot {pilot.FullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if(raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            IRace race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);
            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {
            var pilots = pilotRepository.Models.OrderByDescending(x => x.NumberOfWins);
            var sb = new StringBuilder();
            foreach (var pilot in pilots)
            {
                sb.AppendLine($"Pilot {pilot.FullName} has {pilot.NumberOfWins} wins.");
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();
            var races = raceRepository.Models.Where(x => x.TookPlace == true).ToList();

            foreach (var race in races)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            if(raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            IRace race = raceRepository.FindByName(raceName);

            if(race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race { raceName} cannot start with less than three participants.");
            }


            if (race.TookPlace) //????
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }

            var winners = pilotRepository.Models.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            var sb = new StringBuilder();
            sb.AppendLine($"Pilot {winners[0].FullName} wins the {race.RaceName} race.");
            sb.AppendLine($"Pilot {winners[1].FullName} is second in the { race.RaceName} race.");
            sb.AppendLine($"Pilot {winners[2].FullName} is third in the {race.RaceName} race.");
            raceRepository.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
