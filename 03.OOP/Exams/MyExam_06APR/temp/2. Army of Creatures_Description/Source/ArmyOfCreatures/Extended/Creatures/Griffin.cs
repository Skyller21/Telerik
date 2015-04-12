using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Griffin:Creature
    {
        private const int     InitialGriffinAttack = 8;
        private const int     InitialGriffinDefense = 8;
        private const int     InitialGriffinHealth = 25;
        private const decimal InitialGriffinDamage = 4.5m;
        public Griffin()
            : base(InitialGriffinAttack, InitialGriffinDefense, InitialGriffinHealth, InitialGriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
            this.AddSpecialty(new AddDefenseWhenSkip(3));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
