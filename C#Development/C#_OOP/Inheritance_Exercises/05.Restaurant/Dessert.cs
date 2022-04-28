using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Dessert : Food
    {
        public double Calories { get; set; }
        public Dessert(string name, decimal price, double grams, double calories)
           : base(name, price, grams)
        {
            this.Name = name;
            this.Price = price;
            this.Grams = grams;
            this.Calories = calories;
        }
    }
}
