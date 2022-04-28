using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            Targets = new List<string>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }

                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
            set //??
            {
                if (value == null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }

                captain = value;
            }
        }
        public double ArmorThickness
        {
            get => this.armorThickness;

            set
            {
                this.armorThickness = value;

                if (this.armorThickness < 0)
                {
                    this.armorThickness = 0;
                }
            }
        }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets { get; }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }

            target.ArmorThickness -= this.MainWeaponCaliber;
            this.Targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().ToString()}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($"  *Speed: {this.Speed} knots");
            sb.AppendLine($" *Targets: {(this.Targets.Count <= 0 ? "None" : string.Join(", ", this.Targets))}");

            return sb.ToString().TrimEnd();
        }
    }
}
