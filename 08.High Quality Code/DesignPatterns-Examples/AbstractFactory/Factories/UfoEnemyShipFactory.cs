using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractFactory.Contracts;

namespace AbstractFactory.Factories
{
    public class UfoEnemyShipFactory : IEnemyShipFactory
    {
        public IWeapon AddEsGun()
        {
            return new UfoGun();
        }

        public IEngine AddEsEngine()
        {
            return new UfoEngine();
        }
    }
}
