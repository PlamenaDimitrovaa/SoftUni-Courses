using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Person
{
    public class Person
    {
        private string name;
        private int age;
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {Name.ToString()}, Age: {Age.ToString()}");
            return sb.ToString();
        }

    }
}
