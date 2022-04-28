using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 200)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            this.SubmergeMode = this.SubmergeMode == false ? true : false;

            if (SubmergeMode == true)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < 200)
            {
                ArmorThickness = 200;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {(this.SubmergeMode ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
