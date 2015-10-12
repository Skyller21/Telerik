using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractFactory.Contracts;

namespace AbstractFactory
{
    public class BossWeapon : IWeapon
    {
        public override string ToString()
        {
            return "40 damage";
        }
    }
}
