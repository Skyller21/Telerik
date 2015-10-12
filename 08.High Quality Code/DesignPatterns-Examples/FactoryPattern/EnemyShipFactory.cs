using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class EnemyShipFactory
    {
        public EnemyShip MakeEnemyShip(string type)
        {
            EnemyShip enemyShip = null;

            if (type.ToLower() == "u")
            {
                return new UfoEnemyShip();
            }
            else if(type.ToLower()=="r")
            {
                return new RocketEnemyShip();
            }
            else
            {
                return null;
            }
        }
    }
}
