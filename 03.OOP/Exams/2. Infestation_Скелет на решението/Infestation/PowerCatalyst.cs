using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class PowerCatalyst : Catalyst, ISupplement
    {
        private const int PowerEffectModifier = 3;
        public PowerCatalyst()
            : base(0, PowerEffectModifier, 0)
        {
        }

        
    }
}
