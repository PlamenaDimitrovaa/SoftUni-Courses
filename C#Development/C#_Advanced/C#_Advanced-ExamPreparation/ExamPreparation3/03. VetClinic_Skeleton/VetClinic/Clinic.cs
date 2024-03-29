﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        public int Capacity { get; set; }
        public int Count => data.Count();
        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }

        public void Add(Pet pet)
        {
            if (Capacity > data.Count)
            {
                data.Add(pet);
            }

        }
        public bool Remove(string name)
        {
            Pet pet = data.FirstOrDefault(x => x.Name == name);
            if (pet == null)
            {
                return false;
            }

            data.Remove(pet);
            return true;
        }

        public Pet GetPet(string name, string owner)
        {
            var currentPet = data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
            return currentPet;
        }

        public Pet GetOldestPet()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            if (data.Count > 0)
            {
                sb.AppendLine("The clinic has the following patients:");
                foreach (var pet in data)
                {
                    sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
                }
            }

            return sb.ToString();
        }
    }
}
