using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class AncientBehemoth:Creature
    {
        private const int InitialBehemothAttack = 19;
        private const int InitialBehemothDefense = 19;
        private const int InitialBehemothHealth = 300;
        private const decimal InitialBehemothDamage = 40m;
        public AncientBehemoth()
            : base(InitialBehemothAttack, InitialBehemothDefense, InitialBehemothHealth, InitialBehemothDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
        }
    }
}
