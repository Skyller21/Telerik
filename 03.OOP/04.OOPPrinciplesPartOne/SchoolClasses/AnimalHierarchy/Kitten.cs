using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Kitten:Cat
    {
        public Kitten(string name, int age)
            : base(name, age, Sex.Female)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Meow meoooow");
        }
    }
}
