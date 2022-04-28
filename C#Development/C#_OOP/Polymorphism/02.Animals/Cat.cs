using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favFood)
            : base(name, favFood)
        {
        }

        public override string ExplainSelf()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ExplainSelf());
            sb.AppendLine("MEEOW");
            return sb.ToString().TrimEnd();
        }
    }
}
