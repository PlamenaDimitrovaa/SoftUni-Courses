using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; set; }

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }

        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count => Fish.Count();

        public string AddFish(Fish fish)
        {
            if (fish.FishType == null || fish.FishType == " " || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Capacity <= Fish.Count)
            {
                return "Fishing net is full.";
            }
            else
            {
                Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }

        public bool ReleaseFish(double weight)
        {
            if (Fish.Exists(x => x.Weight == weight))
            {
                Fish.Remove(Fish.FirstOrDefault(x => x.Weight == weight));
                return true;
            }
            else
            {
                return false;
            }
        }

        public Fish GetFish(string fishType)
        {
            return Fish.Where(x => x.FishType == fishType).FirstOrDefault();
        }

        public Fish GetBiggestFish()
        {          
            return Fish.OrderByDescending(x => x.Length).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var fish in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
