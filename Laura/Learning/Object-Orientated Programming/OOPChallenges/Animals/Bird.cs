using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPChallenges.Animals
{
   /// <summary>
   /// represents a bird
   /// </summary>
   public class Bird : Animal
   {
        /// <summary>
        /// determines if a bird can fly
        /// </summary>
        public bool CanFly { get; private set; }


        /// <summary>
        /// creates new bird
        /// </summary>
        /// <param name="name">name of the bird</param>
        /// <param name="species"></param>
        /// <param name="canFly"></param>
        public Bird(string name, string species, bool canFly) : base(name, species)
        {
            CanFly = canFly;
        }

        /// <summary>
        /// checks what movement the bird has
        /// </summary>
        /// <returns> movement described as a string </returns>
        public override string Move()
        {
            
            if (CanFly == true)
            {
                 return "Fly";
            }
            else
            { 
                return "Waddle";
            }
            
        }
    }

}
