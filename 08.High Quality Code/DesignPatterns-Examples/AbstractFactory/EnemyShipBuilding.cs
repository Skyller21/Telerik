using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class EnemyShipBuilding
    {
        public EnemyShip OrderTheShip(string typeOfShip)
        {
            EnemyShip enemyShip = MakeEnemyShip(typeOfShip);

            enemyShip.MakeShip();
            enemyShip.DisplayEnemyShip();
            enemyShip.FollowHeroShip();
            enemyShip.EnemyShipShoots();

            return enemyShip;
        }

        protected abstract EnemyShip MakeEnemyShip(string typeOfShip);
    }
}
