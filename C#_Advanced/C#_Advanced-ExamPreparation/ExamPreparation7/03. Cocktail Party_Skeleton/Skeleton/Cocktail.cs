using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> Ingredients;
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (Capacity > Ingredients.Count && (!Ingredients.Exists(x => x.Name == ingredient.Name)) && MaxAlcoholLevel > CurrentAlcoholLevel)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.Exists(x => x.Name == name))
            {
                Ingredients.Remove(Ingredients.FirstOrDefault(x => x.Name == name));
                return true;
            }
            else
            {
                return false;
            }
        }

        public Ingredient FindIngredient(string name)
        {
            var ingredient = Ingredients.FirstOrDefault(x => x.Name == name);
            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            var ingredient = Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
            return ingredient;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
