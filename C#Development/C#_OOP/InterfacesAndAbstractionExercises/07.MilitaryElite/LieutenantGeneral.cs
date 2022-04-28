using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public List<IPrivate> Privates { get; set; }

        public override string ToString()
        {
            string baseInfo =  base.ToString();
            var sb = new StringBuilder();
            sb.AppendLine(baseInfo);
            sb.AppendLine("Privates:");
            foreach (var item in Privates)
            {
                sb.AppendLine($"  {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
