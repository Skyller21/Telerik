using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ЛамбдаЕьпрессионс
{
    class Grade
    {
        public Grade(int value)
        {
            this.Value = value;
        }
        public int Value
        {
            get;
            set;
        }
        public bool HasPassed
        {
            get { return this.HasPassed; }
            set
            {
                if (this.Value > 3)
                {
                    value = true;
                }
            }
        }
    }
}
