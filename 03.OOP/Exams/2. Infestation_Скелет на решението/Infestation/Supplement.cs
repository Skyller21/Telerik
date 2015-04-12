using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class Supplement:ISupplement
    {
        protected Supplement(int healthEffect, int powerEffect, int aggressionEffect)
        {
            this.HealthEffect = healthEffect;
            this.PowerEffect = powerEffect;
            this.AggressionEffect = aggressionEffect;
        }
        public virtual void ReactTo(ISupplement otherSupplement)
        {
            
        }

        public virtual int PowerEffect { get; protected set; }

        public virtual int HealthEffect { get; protected set; }

        public virtual int AggressionEffect { get; protected set; }
    }
}
