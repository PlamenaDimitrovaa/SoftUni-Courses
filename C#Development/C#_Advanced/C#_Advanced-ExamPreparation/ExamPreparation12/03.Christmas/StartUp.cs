﻿using System;

namespace Christmas
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Bag bag = new Bag("Blue", 20);
            Present present = new Present("Train", 0.4, "Boy");
            Console.WriteLine(present);
            bag.Add(present);
            Console.WriteLine(bag.Count);
            bag.Remove("Doll");
            Present secondPresent = new Present("Doll", 0.7, "Girl");
            bag.Add(secondPresent);
            Present heaviestPresent = bag.GetHeaviestPresent();
            Present searchedPresent = bag.GetPresent("Train");
            Console.WriteLine(bag.Report());
        }
    }
}
