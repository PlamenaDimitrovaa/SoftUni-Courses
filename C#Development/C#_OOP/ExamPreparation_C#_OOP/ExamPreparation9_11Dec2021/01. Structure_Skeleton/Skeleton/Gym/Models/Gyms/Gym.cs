using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Equipment = new List<IEquipment>();
            this.Athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity { get; }

        public double EquipmentWeight => Equipment.Sum(x => x.Weight);
        public ICollection<IEquipment> Equipment { get; }

        public ICollection<IAthlete> Athletes { get; }

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity <= Athletes.Count) //?? <= 
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }

            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Name} is a {this.GetType().Name}:");
            if (Athletes.Any())
            {
                sb.AppendLine($"Athletes: {string.Join(", ", Athletes.Select(x => x.FullName))}");
            }
            else
            {
                sb.AppendLine("Athletes: No athletes");
            }

            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }
    }
}
