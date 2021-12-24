using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public string Name  { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count();
        public void Add(Racer racer)
        {
            if (Capacity > data.Count)
            {
                data.Add(racer);
            }
        }
        public bool Remove(string name)
        {        
            if (data.Exists(x => x.Name == name))
            {
                data.Remove(data.FirstOrDefault(x => x.Name == name));
                return true;
            }
            else
            {
                return false;
            }
        }

        public Racer GetOldestRacer()
        {
            var oldest = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldest;
        }

        public Racer GetRacer(string name)
        {
            var racer = data.FirstOrDefault(x => x.Name == name);
            return racer;
        }

        public Racer GetFastestRacer()
        {
            var racer = data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
            return racer;
          
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (Racer racer in data)
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
