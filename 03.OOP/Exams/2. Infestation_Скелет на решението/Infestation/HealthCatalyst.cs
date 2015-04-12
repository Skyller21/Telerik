using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class HealthCatalyst : Catalyst, ISupplement
    {

        private const int HealthEffectModifier = 3;
        public HealthCatalyst():base(HealthEffectModifier,0,0)
        {
        }

        

    }

}
