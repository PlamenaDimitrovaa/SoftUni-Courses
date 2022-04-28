using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Soup : Starter
    {
        public Soup(string name, decimal price, double grams)
            :base(name, price, grams)
        {
            this.Name = name;
            this.Price = price;
            this.Grams = grams;
        }
    }
}
