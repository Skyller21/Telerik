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
    public class CyclopsKing:Creature
    {
        private const int InitialCyclopsKingAttack = 17;
        private const int InitialCyclopsKingDefense = 13;
        private const int InitialCyclopsKingHealth = 70;
        private const decimal InitialCyclopsKingDamage = 18m;
        public CyclopsKing()
            : base(InitialCyclopsKingAttack, InitialCyclopsKingDefense, InitialCyclopsKingHealth, InitialCyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(3));
            this.AddSpecialty(new DoubleAttackWhenAttacking(4));
            this.AddSpecialty(new DoubleDamage(1));

            //TODO: Implement specialties

        }
    }
}
