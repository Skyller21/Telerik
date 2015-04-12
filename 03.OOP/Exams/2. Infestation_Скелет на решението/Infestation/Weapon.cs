using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Weapon:EffectableSupplement, ISupplement
    {
        
        public Weapon():base(0,10,3)
        {
            this.hasEffect = false;
        }

        


        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.hasEffect = true;
            }
        }
    }
}
