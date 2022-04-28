using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            data = new List<Present>();
        }

        public int Count => data.Count();
        public string Color { get; set; }
        public int Capacity { get; set; }

        public void Add(Present present)
        {
            if (Capacity > data.Count)
            {
                data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            if (data.Exists(x => x.Name == name))
            {
                data.Remove(data.Where(x => x.Name == name).FirstOrDefault());
                return true;
            }
                return false;   
        }

        public Present GetHeaviestPresent()
        {
           return data.OrderByDescending(x => x.Weight).FirstOrDefault();
        }

        public Present GetPresent(string name)
        {
            return data.Where(x => x.Name == name).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Color} bag contains:");
            foreach (var present in data)
            {
                sb.AppendLine(present.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
