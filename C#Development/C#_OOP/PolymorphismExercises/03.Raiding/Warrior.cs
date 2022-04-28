using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name)
            : base(name)
        {
            this.Power = (int)HerosPowers.Warrior;
        }

        public override int Power { get => base.Power; protected set => base.Power = value; }
    }
}

