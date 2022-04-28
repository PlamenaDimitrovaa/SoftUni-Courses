using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract string ProduceSound();
        public abstract void Eat(IFood food);

        protected void ThrowInvalidOperationExceptionForFood(IAnimal animal, IFood food)
        {
            throw new InvalidOperationException($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
