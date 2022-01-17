using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
   public class Pet : IName, IBirthdays
    {
        public string Name { get; private set; }
        public DateTime Birthdate { get; private set; }
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }
    }
}
