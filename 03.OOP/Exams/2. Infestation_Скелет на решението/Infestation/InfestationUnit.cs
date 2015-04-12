using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infestation;

namespace Infestation
{
    public abstract class InfestationUnit : Unit
    {
        


        protected InfestationUnit(string id, UnitClassification unit, int health, int power, int aggression)
            : base(
                id, unit, health, power, aggression)
        {

        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            if (this.Id != unit.Id &&
                InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification) ==
                this.UnitClassification)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var optimalUnitToAttack = attackableUnits.OrderBy(x => x.Health).FirstOrDefault();
            return optimalUnitToAttack;
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }
    }
}
