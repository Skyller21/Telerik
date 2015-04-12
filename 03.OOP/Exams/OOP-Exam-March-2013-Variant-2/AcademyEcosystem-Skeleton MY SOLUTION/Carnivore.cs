using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Carnivore : Animal, ICarnivore
    {
        public Carnivore(string name, Point location, int size)
            : base(name, location, size)
        {

        }
        public virtual int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal is Zombie)
                {
                    var zombie = animal as Zombie;
                    return zombie.GetMeatFromKillQuantity();
                }
                return 0;
            }
            return 0;


        }
    }
}
