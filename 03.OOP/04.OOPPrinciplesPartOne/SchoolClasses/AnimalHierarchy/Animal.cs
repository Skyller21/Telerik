using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    

   
    public abstract class Animal : ISound
    {
        protected Animal(string name, int age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }


        public string Name { get; protected set; }

        public int Age { get; protected set; }

        public Sex Sex { get; protected set; }
        public Type Type { get; protected set; }

        public abstract void MakeSound();

        public override string ToString()
        {

            return (this.GetAnimalType() + ": " + this.Name + ", " + this.Age + " years old, " + this.Sex +
                    ".");
        }

        public string GetAnimalType()
        {
            string type = this.GetType().BaseType.Name;
            if (type != "Animal")
            {
                return this.GetType().BaseType.Name;
            }
            else
            {
                return this.GetType().Name;
            }
        }

        public static string CalcAverageAge(IEnumerable<Animal> animalsList, Type type)
        {
            if (type == Type.Animal)
            {
                var averageAge = animalsList.Average(x => x.Age);
                return String.Format("The average age of the {0}s = {1} years old", type, Math.Round(averageAge,2));
            }
            else
            {
                var averageAge = animalsList.Where(x => x.GetAnimalType() == type.ToString()).Average(x => x.Age);
                return String.Format("The average age of the {0}s = {1} years old", type, Math.Round(averageAge,2));
            }
        }
    }
}
