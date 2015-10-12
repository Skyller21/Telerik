using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class RocketEnemyShip :EnemyShip
    {
        public RocketEnemyShip()
        {
            this.Name = "Rocket Enemy Ship";
            this.Damage = 30;
        }
    }
}
