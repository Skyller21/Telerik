using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractFactory.Contracts;

namespace AbstractFactory
{
    public class UfoBossEnemyShip : EnemyShip
    {
        IEnemyShipFactory shipFactory;

        public UfoBossEnemyShip(IEnemyShipFactory shipFactory)
        {
            this.shipFactory = shipFactory;
        }

        public override void MakeShip()
        {
            Console.WriteLine("Making enemy ship " + this);

            this.weapon = shipFactory.AddEsGun();
            this.engine = shipFactory.AddEsEngine();
        }
    }
}
