using System.Linq;
using AnimalsLib.Animals;
using System.Collections.Generic;

namespace AnimalsLib
{
    public class WagonAlgorithms
    {
        /// <summary>
        /// Explicitly checking for wagon space, ignoring the meateaters and vegans rule.
        /// </summary>
        /// <returns></returns>
        public bool CheckWagonSpace()
        {
            bool returnValue = true;
            Bandwagon bandwagon = new Bandwagon(new List<Animal>
            {
                new Elephant(),
                new Elephant()
            });

            foreach (var t in bandwagon.animals)
                bandwagon.bandWagonSpace += t.Size;

            if (bandwagon.bandWagonSpace > 10)
                returnValue = false;

            return returnValue;
        }

        /// <summary>
        /// Explicitly checking for wagon space by users own animal list, ignoring the meateaters and vegans rule.
        /// </summary>
        /// <returns></returns>
        public bool CheckWagonSpace(List<Animal> animals)
        {
            bool returnValue = true;
            Bandwagon bandwagon = new Bandwagon(animals);

            foreach (var t in bandwagon.animals)
                bandwagon.bandWagonSpace += t.Size;

            if (bandwagon.bandWagonSpace > 10)
                returnValue = false;

            return returnValue;
        }

        /// <summary>
        /// Explicitly checking for meateaters and vegans rule, ignores space rule. Using users animal list
        /// </summary>
        /// <returns></returns>
        public bool IsWagonCompatibleWithMeatEaters()
        {
            bool returnValue = true;
            Bandwagon bandwagon = new Bandwagon(new List<Animal> {new Monkey(), new Tiger()});
            Animal meatEater = bandwagon.animals.FirstOrDefault(x => x.IsMeatLover);

            if (meatEater != null)
            {
                foreach (Animal bandwagonAnimal in bandwagon.animals.ToList().FindAll(x => x != meatEater))
                {
                    if (bandwagonAnimal.Size <= meatEater.Size)
                        returnValue = false;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Explcitly checking for meateaters and vegans rule, ignores space rule. Using users animal list
        /// </summary>
        /// <param name="animals"></param>
        /// <returns></returns>
        public bool IsWagonCompatibleWithMeatEaters(List<Animal> animals)
        {
            bool returnValue = true;
            Bandwagon bandwagon = new Bandwagon(animals);
            Animal meatEater = bandwagon.animals.FirstOrDefault(x => x.IsMeatLover);

            if (meatEater != null)
            {
                foreach (Animal bandwagonAnimal in bandwagon.animals.ToList().FindAll(x => x != meatEater))
                {
                    if (bandwagonAnimal.Size <= meatEater.Size)
                        returnValue = false;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Uses pre-defined list of animals to put in wagons.
        /// </summary>
        /// <returns></returns>
        public IList<Bandwagon> SortAnimalsInWagons()
        {
            List<Animal> AvailableAnimals = new List<Animal>
           {
               new Elephant(),
               new Elephant(),
               new Elephant(),
               new Elephant(),
               new Elephant(),
               new Elephant(),
               new Elephant(),
               new Elephant(),
               new Elephant(),
               new Elephant(),
               new Camel(),
               new Camel(),
               new Camel(),
               new Monkey(),
               new Monkey(),
               new Monkey(),
               new Monkey(),
               new Monkey(),
               new Monkey()
           };
            IList<Bandwagon> OrderWagons = new List<Bandwagon>();

            IList<Animal> meatEaters = AvailableAnimals.FindAll(x => x.IsMeatLover).OrderByDescending(x => x.Size).ToList();
            IList<Animal> vegans = AvailableAnimals.FindAll(x => !x.IsMeatLover).OrderByDescending(x => x.Size).ToList();

            while (AvailableAnimals.Any())
            {
                Bandwagon newBandwagon = new Bandwagon(new List<Animal>());
                Animal meatEaterSelected = new Animal();
                if (meatEaters.Count > 0)
                {
                    meatEaterSelected = meatEaters.First();
                    newBandwagon.animals.Add(meatEaterSelected);
                    newBandwagon.bandWagonSpace += meatEaterSelected.Size;
                    meatEaters.Remove(meatEaterSelected);
                }

                foreach (Animal vegan in vegans)
                {
                    if (meatEaterSelected.Size < vegan.Size)
                    {
                        if (vegan.Size + newBandwagon.bandWagonSpace <= 10)
                        {
                            newBandwagon.animals.Add(vegan);
                            newBandwagon.bandWagonSpace += vegan.Size;
                        }
                    }
                }

                OrderWagons.Add(newBandwagon);
                foreach (Animal newBandwagonAnimal in newBandwagon.animals)
                {
                    AvailableAnimals.RemoveAt(AvailableAnimals.IndexOf(newBandwagonAnimal));
                    vegans.Remove(newBandwagonAnimal);
                }
            }

            return OrderWagons;
        }

        /// <summary>
        /// User can enter his own set of animals to sort in wagons.
        /// </summary>
        /// <param name="_AvailableAnimals"></param>
        /// <returns></returns>
        public IList<Bandwagon> SortAnimalsInWagons(List<Animal> _AvailableAnimals)
        {
            IList<Bandwagon> OrderWagons = new List<Bandwagon>();

            IList<Animal> meatEaters = _AvailableAnimals.FindAll(x => x.IsMeatLover).OrderByDescending(x => x.Size).ToList();
            IList<Animal> vegans = _AvailableAnimals.FindAll(x => !x.IsMeatLover).OrderByDescending(x => x.Size).ToList();

            while (_AvailableAnimals.Count > 0)
            {
                Bandwagon newBandwagon = new Bandwagon(new List<Animal>());
                Animal meatEaterSelected = new Animal();
                if (meatEaters.Count > 0)
                {
                    meatEaterSelected = meatEaters.First();
                    newBandwagon.animals.Add(meatEaterSelected);
                    newBandwagon.bandWagonSpace += meatEaterSelected.Size;
                    meatEaters.Remove(meatEaterSelected);
                }

                foreach (Animal vegan in vegans)
                {   
                    if (meatEaterSelected.Size < vegan.Size)
                    {
                        if (vegan.Size + newBandwagon.bandWagonSpace <= 10)
                        {
                            newBandwagon.animals.Add(vegan);
                            newBandwagon.bandWagonSpace += vegan.Size;
                        }
                    }
                }

                OrderWagons.Add(newBandwagon);
                foreach (Animal newBandwagonAnimal in newBandwagon.animals)
                {
                    _AvailableAnimals.RemoveAt(_AvailableAnimals.IndexOf(newBandwagonAnimal));
                    vegans.Remove(newBandwagonAnimal);
                }
            }

            return OrderWagons;
        }
    }
}