using System;

namespace DefiningClasses
{
   public class StartUp
    {
        public class Person
        {
            private string name;
            private int age;
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            public int Age
            {
                get
                {
                    return age;
                }
                set
                {
                    age = value;
                }
            }

        }
        static void Main(string[] args)
        {
            var person = new Person("Peter", 20);
            var person2 = new Person("George", 18);
            var person3 = new Person("Jose", 43);
        }
    }
}
