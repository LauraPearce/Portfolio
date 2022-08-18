using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPChallenges.Animals;

namespace ConsoleForTesting
{
    public static class OOPAnimalConsole
    {
        public static void Run()
        {                  
            // this demonstrates creating different types of animals
            Fish fishOne = new Fish("Finley", "Salmon", 2);
            Fish fishTwo = new Fish("Fred", "Trout", 4);
            Bird birdOne = new Bird("Bridget", "Pengiun", false);
            Bird birdTwo = new Bird("Brian", "Sparrow", true);
            Mammal mammalOne = new Mammal("Moana", "Lion", 5);
            Mammal mammalTwo = new Mammal("Matthew", "Dog", 4);


            // this will prove I can/cannot access specific properties of my animals
            Console.WriteLine(fishOne.NumberOfFins);
            // fishOne.NumberOfFins = 5; // this should not work because you cannot change number of fins
            // mammalOne.NumberOfLegs = 6; // this should not work because you cannot change the number of legs
                      
            // this is how I can create a list of different types of animals
            List<Animal> allAnimals = new List<Animal> { fishOne, fishTwo, birdOne, birdTwo, mammalOne, mammalTwo };

            
            foreach (Animal animal in allAnimals)
            {
            
                // this should output the animal movement
                Console.WriteLine(animal.Move());
                
                // this should output info about all animals
                Console.WriteLine(animal.ToString());
                Console.WriteLine();
            }
            
            // this should prove equals is not on memory but is on content
            Fish bob = new Fish("Bob", "Goldfish", 2); 
            Fish bobCopy = new Fish("Bob", "Goldfish", 2);

            if (bob.Equals(bobCopy))
            {
                // this should be true
                Console.WriteLine("This is the same fish");
            }
            else
            {
                Console.WriteLine("These fish are different");
            }
        }       
    }
}
