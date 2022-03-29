using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public class SportsCar : Car
    {
        public SportsCar(string model, int horsePower)
            : base(model, horsePower, 3000, 250, 450)
        {
        }
    }
}
