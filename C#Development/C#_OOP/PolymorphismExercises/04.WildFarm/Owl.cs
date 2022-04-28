using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            if (!(food is Meat))
            {
                ThrowInvalidOperationExceptionForFood(this, food);
            }
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * 0.25;
        }

        public override string ProduceSound() => "Hoot Hoot";     
    }
}
