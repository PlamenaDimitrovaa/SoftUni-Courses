using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;

        public Captain(string fullName)
        {
            FullName = fullName;
            Vessels = new List<IVessel>();
            this.CombatExperience = 0;
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }

                fullName = value;
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels { get; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }

            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            if (this.Vessels.Count > 0)
            {
                foreach (var vessel in this.Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
