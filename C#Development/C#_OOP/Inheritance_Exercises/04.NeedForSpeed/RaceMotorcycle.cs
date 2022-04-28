using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel)
        : base(horsePower, fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            DefaultFuelConsumption = 8;
        }
    }
}
