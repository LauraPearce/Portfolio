using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPChallenges.Animals
{
    public class Mammal : Animal
    {
        //properties

        public int _numberOfLegs { get; }

        //constructor
        public Mammal(string name, string species, int numberOfLegs) : base(name, species)
        {
            _numberOfLegs = numberOfLegs;
        }

        //methods
        public override string Move()
        {
            string Movement = "Run";
            return Movement;
        }

    }
}
