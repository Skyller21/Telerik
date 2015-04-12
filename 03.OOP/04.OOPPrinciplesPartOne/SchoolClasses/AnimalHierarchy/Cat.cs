using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    abstract class Cat : Animal
    {
        protected Cat(string name, int age, Sex sex)
            : base(name, age, sex)
        {

        }
    }
}
