using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }


        protected override bool CanAttackUnit(UnitInfo unit)
        {
            return (unit.Id!=this.Id && unit.Power <= this.Aggression);
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var optimalUnitToAttack = attackableUnits.OrderByDescending(x => x.Health).FirstOrDefault();
            return optimalUnitToAttack;
        }
    }
}
