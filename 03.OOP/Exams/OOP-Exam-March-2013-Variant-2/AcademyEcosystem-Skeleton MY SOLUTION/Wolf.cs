using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Wolf : Carnivore, ICarnivore
    {
        private const int WolfInitialSize = 4;
        public Wolf(string name, Point location)
            : base(name, location, WolfInitialSize)
        {

        }
        public override int TryEatAnimal(Animal animal)
        {
            if (base.TryEatAnimal(animal)==0&&animal!=null)
            {
                if (this.Size >= animal.Size || animal.State==AnimalState.Sleeping)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }
            return base.TryEatAnimal(animal);

        }
    }
}
