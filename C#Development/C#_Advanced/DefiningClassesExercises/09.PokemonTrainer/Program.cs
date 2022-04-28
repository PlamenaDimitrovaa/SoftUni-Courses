using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            string command = Console.ReadLine();
            while (command != "Tournament")
            {
                var inputInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = inputInfo[0];
                string pokemonName = inputInfo[1];
                string pokemonElement = inputInfo[2];
                int pokemonHealth = int.Parse(inputInfo[3]);
                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    trainers.Add(trainerName, newTrainer);
                }

                Trainer trainer = trainers[trainerName];
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainer.Pokemons.Add(pokemon);
                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while (command != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(x=>x.Element == command))
                    {
                        trainer.Value.NumberOfBadges += 1;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Value.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var item in trainers.OrderByDescending(t => t.Value.NumberOfBadges))
            {
                Console.WriteLine($"{item.Key} {item.Value.NumberOfBadges} {item.Value.Pokemons.Count}");
            }
        }
    }
}
