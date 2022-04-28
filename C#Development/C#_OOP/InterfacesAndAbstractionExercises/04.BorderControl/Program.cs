using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> all = new List<IIdentifiable>();
            var command = Console.ReadLine();

            while (command != "End")
            {
                var lines = command.Split();
                if (lines.Length == 3)
                {
                    var name = lines[0];
                    var age = int.Parse(lines[1]);
                    var id = lines[2];
                    all.Add(new Citizens(name, age, id));
                }
                else if (lines.Length == 2 )
                {
                    var model = lines[0];
                    var id = lines[1];
                    all.Add(new Robots(model, id));
                }

                command = Console.ReadLine();
            }

            var lastDigitsOfFakeId = Console.ReadLine();
            all.Where(c => c.Id.EndsWith(lastDigitsOfFakeId)).Select(c => c.Id).ToList().ForEach(Console.WriteLine);
        }
    }
}
