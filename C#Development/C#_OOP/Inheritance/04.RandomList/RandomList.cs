using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public Random random { get; set; }

        public RandomList()
        {
            random = new Random();
        }
        public string RandomString()
        {
            var index = random.Next(0, this.Count);
            return this[index];
            this.RemoveAt(index);
        }
    }
}
