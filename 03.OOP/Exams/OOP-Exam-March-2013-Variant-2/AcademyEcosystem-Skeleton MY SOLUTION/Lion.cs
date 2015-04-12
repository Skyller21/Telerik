using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Lion : Carnivore, ICarnivore
    {
        private const int LionInitialSize = 6;
        public Lion(string name, Point location)
            : base(name, location, LionInitialSize)
        {

        }
        public override int TryEatAnimal(Animal animal)
        {
            if (base.TryEatAnimal(animal) == 0 && animal != null)
            {
                if (this.Size <= animal.Size*2)
                {
                    this.Size++;
                    return animal.GetMeatFromKillQuantity();
                }
            }
            return base.TryEatAnimal(animal);
        }
    }
}
