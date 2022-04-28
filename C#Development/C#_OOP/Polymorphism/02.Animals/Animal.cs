using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private string favouriteFood;
        public Animal(string name, string favFood)
        {
            this.name = name;
            this.favouriteFood = favFood;
        }
        public virtual string ExplainSelf()
        {
            return $"I am {name} and my fovourite food is {favouriteFood}";           
        }
    }
}
