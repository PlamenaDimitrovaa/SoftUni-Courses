using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers
{
    public class Driver : IDriver
    {
        private string name;

        public Driver(string name)
        {
            Name = name;
            CanParticipate = false;
            NumberOfWins = 0;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException("Car cannot be null.");
            }

            Car = car;
            CanParticipate = true;

        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
