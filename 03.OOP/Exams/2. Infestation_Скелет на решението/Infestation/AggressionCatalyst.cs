using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class AggressionCatalyst:Catalyst,ISupplement
    {
        private const int AggressionEffectModifier = 3;
        public AggressionCatalyst()
            : base(0, 0, AggressionEffectModifier)
        {
        }

        
    }
}
