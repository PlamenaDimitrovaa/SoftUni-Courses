using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 300)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            this.SonarMode = this.SonarMode == false ? true : false;

            if (SonarMode == true)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < 300)
            {
                this.ArmorThickness = 300;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {(this.SonarMode ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
