using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory.Contracts
{
    public interface IEnemyShipFactory
    {
        IWeapon AddEsGun();    

        IEngine AddEsEngine();
    }
}
