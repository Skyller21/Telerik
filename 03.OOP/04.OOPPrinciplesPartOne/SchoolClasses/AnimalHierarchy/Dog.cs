using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Dog : Animal
    {
        public string Breed { get; private set; }
        public Dog(string name, int age, Sex sex, string breed)
            : base(name, age, sex)
        {
            this.Breed = breed;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Djaf bau");
        }
    }
}
