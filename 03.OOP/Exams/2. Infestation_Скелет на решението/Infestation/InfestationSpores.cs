using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationSpores:EffectableSupplement, ISupplement
    {
        private const int AggressionEffectModifier = 20;
        private const int PowerEffectModifier = -1;

        public InfestationSpores() : base(0, -1, 20)
        {
            this.hasEffect = true;
        }
        

     


        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.hasEffect = false;
            }
        }
    }

    
}
