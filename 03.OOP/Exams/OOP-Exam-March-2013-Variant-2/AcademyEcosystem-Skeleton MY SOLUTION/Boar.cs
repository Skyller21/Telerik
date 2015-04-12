using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Boar : Carnivore, ICarnivore, IHerbivore
    {
        private const int BoarInitialSize = 4;
        private const int BoarBiteSize = 2;

        public Boar(string name, Point location, int biteSize = BoarBiteSize)
            : base(name, location, BoarInitialSize)
        {

        }
        public override int TryEatAnimal(Animal animal)
        {
            if (base.TryEatAnimal(animal) == 0 && animal != null)
            {
                if (this.Size >= animal.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }
            return base.TryEatAnimal(animal);
        }

        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                this.Size++;
                return plant.GetEatenQuantity(BoarBiteSize); //Check if it is OK
            }

            return 0;
        }
    }
}
