using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }
        public List<Car> Participants { get; set; }
        public int Count
        {
            get
            {
                return Participants.Count;
            }
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public void Add(Car car)
        {
            if (!Participants.Any(x => x.LicensePlate == car.LicensePlate)
                && Capacity >= Participants.Count + 1
                && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            } 
        }

        public bool Remove(string licensePlate)
        {
            var car = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (car == null)
            {
                return false;
            }
            else
            {
                Participants.Remove(car);
                return true;
            }
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
        }
        public Car GetMostPowerfulCar()
        {
           return Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString();
        }
    }
}
