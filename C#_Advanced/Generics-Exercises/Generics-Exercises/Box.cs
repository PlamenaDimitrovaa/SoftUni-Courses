using System;
using System.Collections.Generic;
using System.Text;

namespace Generics_Exercises
{
    public class Box<T>
    {
        private List<T> items;
        public Box()
        {
            items = new List<T>();
        }
        public void Add(T item)
        {
            items.Add(item);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in items)
            {
                sb.AppendLine($"System.String: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
