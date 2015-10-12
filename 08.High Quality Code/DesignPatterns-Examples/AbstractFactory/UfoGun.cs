using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Contracts;

namespace AbstractFactory
{
    public class UfoGun : IWeapon
    {
        public override string ToString()
        {
            return "20 damage";
        }
    }
}
