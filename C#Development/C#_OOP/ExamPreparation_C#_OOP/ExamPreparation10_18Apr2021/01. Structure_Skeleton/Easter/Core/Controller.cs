using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private IRepository<IBunny> bunnies;
        private IRepository<IEgg> eggs;
        private readonly IWorkshop workshop;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
            workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            Bunny bunny = null;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }

            bunnies.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            if (bunnies.FindByName(bunnyName) == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }

            var dye = new Dye(power);
            var bunny = bunnies.FindByName(bunnyName);
            bunny.AddDye(dye);
            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> bunies = this.bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();
            IEgg egg = eggs.FindByName(eggName);

            if (bunies.Count == 0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

           while(bunies.Count > 0 && !egg.IsDone())
            {
                var bunny = bunies.FirstOrDefault();
                workshop.Color(egg, bunny);
                if (bunny.Energy <= 0 || bunny.Dyes.Count <= 0)
                {
                    bunies.Remove(bunny);
                }
            }

            return $"Egg {eggName} is {(egg.IsDone() ? "done" : "not done")}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            var colored = eggs.Models.Where(x => x.IsDone()).ToList();
            sb.AppendLine($"{colored.Count} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
