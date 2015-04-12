using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    public class Frog : Animal
    {
        public Frog(string name, int age, Sex sex)
            : base(name, age, sex)
        {

        }
        public override void MakeSound()
        {
            Console.WriteLine("Qwak qwaaaak");
        }
    }
}
