using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPChallenges.Animals
{
    public class Fish : Animal
    {
        // properties
        public int NumberOfFins { get; }

        // constructor 
        public Fish (string name, string species, int numberOfFins) : base (name, species)
        {
            NumberOfFins = numberOfFins;   
        }

        // methods
        public override string Move()
        {
            string movement = "Swim";
            return movement; 
        }

    }  
}


  