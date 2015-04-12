using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class AnimalKingdomProgram
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>()
            {
                new Dog("Sharo",4,Sex.Male, "Huskey"),
                new Dog("Jessica",7,Sex.Female, "Shepard"),
                new Frog("Jabcho",2,Sex.Male),
                new Frog("Princess",1,Sex.Female),
                new Kitten("Maca",5),
                new Tomcat("Tom",3)
            };
            Console.WriteLine("The animals in the list are\n----------------------");
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);   
            }

            Console.WriteLine("\nAnimals makes sound\n----------------------");
            foreach (var animal in animals)
            {
                Console.Write(animal.Name + ": ");
                animal.MakeSound();
            }
            Console.WriteLine("\nAverage age of the animals\n----------------------");
            Console.WriteLine(Animal.CalcAverageAge(animals, Type.Animal));
            Console.WriteLine(Animal.CalcAverageAge(animals, Type.Dog));
            Console.WriteLine(Animal.CalcAverageAge(animals, Type.Cat));
            Console.WriteLine(Animal.CalcAverageAge(animals,Type.Frog));

            
        }
    }
}
