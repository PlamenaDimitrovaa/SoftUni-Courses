using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codenumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codenumber;
        }

        public int CodeNumber { get; set; }

        public override string ToString()
        {
           var sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id}");
            sb.AppendLine($"Code Number: {CodeNumber}");
            return sb.ToString().TrimEnd();
        }
    }
}
