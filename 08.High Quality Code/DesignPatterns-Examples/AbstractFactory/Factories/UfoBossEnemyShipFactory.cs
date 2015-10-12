using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractFactory.Contracts;

namespace AbstractFactory.Factories
{
    class UfoBossEnemyShipFactory : IEnemyShipFactory
    {
        public IWeapon AddEsGun()
        {
            return new BossWeapon();
        }

        public IEngine AddEsEngine()
        {
            return new BossEngine();
        }
    }
}
