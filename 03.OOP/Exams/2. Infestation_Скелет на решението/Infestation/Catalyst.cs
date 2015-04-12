using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class Catalyst : Supplement, ISupplement
    {


        
        protected Catalyst(int healthEffect, int powerEffect, int aggressionEffect)
            : base(healthEffect, powerEffect, aggressionEffect)
        {

        }

        
    }
}
