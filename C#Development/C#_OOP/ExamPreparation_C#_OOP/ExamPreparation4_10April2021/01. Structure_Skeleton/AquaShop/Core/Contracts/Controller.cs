using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core.Contracts
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            this.aquariums.Add(aquarium);

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            this.decorations.Add(decoration);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish fish = null;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            var sb = new StringBuilder();

            if (aquarium.GetType().Name == "FreshwaterAquarium" && fish.GetType().Name == "SaltwaterFish")
            {
                sb.AppendLine($"Water not suitable.");
            }
            else if (aquarium.GetType().Name == "SaltwaterAquarium" && fish.GetType().Name == "FreshwaterFish")
            {
                sb.AppendLine($"Water not suitable.");
            }
            else
            {
                sb.AppendLine($"Successfully added {fishType} to {aquariumName}.");
                aquarium.AddFish(fish);
            }

            return sb.ToString().TrimEnd();

        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal result = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);

            return $"The value of Aquarium {aquariumName} is {result:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IDecoration decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            aquarium.AddDecoration(decoration);

            this.decorations.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
