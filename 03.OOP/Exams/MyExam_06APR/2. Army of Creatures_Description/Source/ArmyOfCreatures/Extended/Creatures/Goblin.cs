using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Goblin : Creature
    {
        private const int InitialGoblinAttack = 4;
        private const int InitialGoblinDefense = 2;
        private const int InitialGoblinHealth = 5;
        private const decimal InitialGoblinDamage = 1.5m;
        public Goblin()
            : base(InitialGoblinAttack, InitialGoblinDefense, InitialGoblinHealth, InitialGoblinDamage)
        {

        }
    }
}
