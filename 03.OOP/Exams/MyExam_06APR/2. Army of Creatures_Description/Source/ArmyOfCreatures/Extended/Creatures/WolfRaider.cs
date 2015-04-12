using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;
using ArmyOfCreatures.Extended.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class WolfRaider:Creature
    {
        private const int     InitialWolfRaiderAttack = 8;
        private const int     InitialWolfRaiderDefense = 5;
        private const int     InitialWolfRaiderHealth = 10;
        private const decimal InitialWolfRaiderDamage = 3.5m;
        public WolfRaider()
            : base(InitialWolfRaiderAttack, InitialWolfRaiderDefense, InitialWolfRaiderHealth, InitialWolfRaiderDamage)
        {
            this.AddSpecialty(new DoubleDamage(7));
            //TODO: Check it
            
        }
    }
}
