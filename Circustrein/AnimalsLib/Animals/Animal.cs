using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsLib.Animals
{
    public class Animal
    {
        public int Size { get; protected set; }
        public bool IsMeatLover { get; protected set; }

        public override string ToString()
        {
            return base.GetType().Name;
        }
    }
}
