using System.Collections.Generic;
using System.Linq;
using AnimalsLib.Animals;

namespace AnimalsLib
{
    public class Bandwagon
    {
        public IList<Animal> animals { get; set; }
        public int bandWagonSpace;

        public Bandwagon(List<Animal> _animals)
        {
            animals = _animals;
        }
    }
}
