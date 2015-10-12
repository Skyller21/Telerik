using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractFactory.Contracts;

namespace AbstractFactory
{
    public class UfoEnemyShip : EnemyShip
    {
        private readonly IEnemyShipFactory shipFactory;

        public UfoEnemyShip(IEnemyShipFactory shipFactory)
        {
            this.shipFactory = shipFactory;
        }
        public override void MakeShip()
        {
            Console.WriteLine("Making enemy ship {0}", this.Name);
            this.weapon = shipFactory.AddEsGun();
            this.engine = shipFactory.AddEsEngine();
        }
    }
}
