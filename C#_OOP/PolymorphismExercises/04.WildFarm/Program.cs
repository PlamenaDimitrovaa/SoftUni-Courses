using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                var inputInfo = input.Split();
                var foodInfo = Console.ReadLine().Split();

                string animalType = inputInfo[0];
                string name = inputInfo[1];
                double weight = double.Parse(inputInfo[2]);

                string foodType = foodInfo[0];
                int foodQty = int.Parse(foodInfo[1]);

                try
                {
                    IAnimal animal = null;

                    if (animalType == "Cat" || animalType == "Tiger")
                    {
                        string livingRegion = inputInfo[3];
                        string breed = inputInfo[4];
                        if (animalType == "Cat")
                        {
                            animal = new Cat(name, weight, livingRegion, breed);
                        }
                        else if (animalType == "Tiger")
                        {
                            animal = new Tiger(name, weight, livingRegion, breed);
                        }
                    }
                    else if (animalType == "Owl" || animalType == "Hen")
                    {
                        double wingSize = double.Parse(inputInfo[3]);

                        if (animalType == "Owl")
                        {
                            animal = new Owl(name, weight, wingSize);
                        }
                        else if (animalType == "Hen")
                        {
                            animal = new Hen(name, weight, wingSize);
                        }
                    }
                    else if (animalType == "Mouse" || animalType == "Dog")
                    {
                        string livingRegion = inputInfo[3];
                        if (animalType == "Mouse")
                        {
                            animal = new Mouse(name, weight, livingRegion);
                        }
                        else if (animalType == "Dog")
                        {
                            animal = new Dog(name, weight, livingRegion);
                        }
                    }

                    Console.WriteLine(animal.ProduceSound());
                    animals.Add(animal);

                    IFood food = null;

                    if (foodType == "Fruit")
                    {
                        food = new Fruit(foodQty);
                    }
                    else if (foodType == "Meat")
                    {
                        food = new Meat(foodQty);
                    }
                    else if (foodType == "Vegetable")
                    {
                        food = new Vegetable(foodQty);
                    }
                    else if (foodType == "Seeds")
                    {
                        food = new Seeds(foodQty);
                    }

                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
