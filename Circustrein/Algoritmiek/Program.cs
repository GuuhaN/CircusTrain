using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AnimalsLib;
using AnimalsLib.Animals;

namespace Algoritmiek
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Animal[] selectionAnimals = new Animal[]
            {
                new Elephant(),
                new T_Rex(),
                new Tiger(),
                new Camel(),
                new Monkey(),
            };

            List<Animal> animals = new List<Animal>();
            WagonAlgorithms wagonAlgorithm = new WagonAlgorithms();

            for (int i = 0; i < 10000; i++)
                animals.Add(selectionAnimals[random.Next(selectionAnimals.Length)]);

            IList<Bandwagon> wagons = wagonAlgorithm.SortAnimalsInWagons(animals);


            if (wagons.Count <= 0)
                Console.WriteLine("You have no animals, why are you calling me?");

            for (int i = 0; i < wagons.Count; i++)
            {
                Console.WriteLine("Wagon " + (i + 1) + " - Size: " + wagons[i].bandWagonSpace + "/10");
                foreach (Animal animal in wagons[i].animals.ToList().OrderByDescending(x => x.Size))
                    Console.WriteLine(" - " + animal);
                Console.WriteLine("------------------------------------------");
            }

            Console.WriteLine("Total wagons purchased: " + wagons.Count);
            Console.WriteLine("              _________________");
            Console.WriteLine("      .--H--.|                 |");
            Console.WriteLine("    _//_||  ||                 |");
            Console.WriteLine("   [    -|  |'--;--------------'");
            Console.WriteLine("   '-()-()----()" + "() ^^^^^^^ ()" + "()'");
            Console.ReadLine();
        }
    }
}