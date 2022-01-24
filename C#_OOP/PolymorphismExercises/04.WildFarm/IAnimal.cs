using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public interface IAnimal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public string ProduceSound();
        public void Eat(IFood food);
    }
}
