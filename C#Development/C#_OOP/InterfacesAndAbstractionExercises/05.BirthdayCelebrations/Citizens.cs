using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public class Citizens : IIdentifiable, IName, IBirthdays
    {
        public Citizens(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public DateTime Birthdate { get; private set; }
    }
}
