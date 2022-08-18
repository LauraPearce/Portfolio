using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPChallenges.Animals
{
    //TODO: add in more summary comments

    public abstract class Animal
    {
        public string Name { get; set; }

        /// <summary>
        /// determines the species of the animal
        /// note: no set as shouldnt be able to change the species post creation
        /// </summary>
        public string Species { get; private set; }

       
        public Animal (string name, string species)
        {
            Name = name;
            Species = species;
        }


        public override bool Equals(object? obj)
        {
            Animal animalToCompareTo = obj as Animal;

            if (animalToCompareTo == null)
            {
                return false;
            }

            if (Name == animalToCompareTo.Name && 
                Species == animalToCompareTo.Species &&
                GetType() == animalToCompareTo.GetType()) 
            {
                return true;
            }
            else
            {
                return false;
            }
   
        }
        public abstract string Move();

        public override string ToString()
        {
           return $"This is {Name} the {Species} which is a {GetType().Name}.";
        }

    }
}
