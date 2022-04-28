using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private List<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            TookPlace = false;
            pilots = new List<IPilot>();
        }
        public string RaceName
        {
            get => raceName;
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }

                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }

                numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; } //?

        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
            TookPlace = true; //??
        }

        public string RaceInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The {this.RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}"); //?
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            if (TookPlace)
            {
                sb.AppendLine("Took place: Yes");
            }
            else
            {
                sb.AppendLine("Took place: No");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
