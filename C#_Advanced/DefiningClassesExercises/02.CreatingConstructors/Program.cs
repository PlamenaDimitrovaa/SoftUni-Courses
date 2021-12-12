using System;
namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person();
            Console.WriteLine(person.Name + " " + person.Age);
            var person2 = new Person(5);
            Console.WriteLine(person2.Name + " " + person2.Age);
            var person3 = new Person("Plamena", 19);
            Console.WriteLine(person3.Name + " " + person3.Age);

        }
    }
}
