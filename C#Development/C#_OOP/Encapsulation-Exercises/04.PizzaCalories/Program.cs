using System;

namespace _04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaInfo = Console.ReadLine().Split();
                var doughInfo = Console.ReadLine().Split();

                var pizzaName = pizzaInfo[1];
                var doughFlourType = doughInfo[1];
                var bakingTechnique = doughInfo[2];
                var doughWeight = double.Parse(doughInfo[3]);

                Dough dough = new Dough(doughFlourType, bakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);
                var toppingType = Console.ReadLine();

                while (toppingType != "END")
                {
                    var toppingInfo = toppingType.Split();
                    var type = toppingInfo[1];
                    var weight = double.Parse(toppingInfo[2]);

                    Topping topping = new Topping(type, weight);

                    pizza.AddToppings(topping);

                    toppingType = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.CalculateTotalCalories():F2} Calories.");
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
