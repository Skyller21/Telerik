using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class UfoEnemyShip: EnemyShip
    {
        public UfoEnemyShip()
        {
            this.Name = "UFO Enemy Ship";
            this.Damage = 20;
        }
    }
}
