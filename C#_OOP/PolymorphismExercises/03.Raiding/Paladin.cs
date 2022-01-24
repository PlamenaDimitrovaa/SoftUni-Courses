using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name)
            : base(name)
        {
            this.Power = (int)HerosPowers.Paladin;
        }

        public override int Power { get => base.Power; protected set => base.Power = value; }
    }
}

