using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Queen : InfestationUnit
    {


        public Queen(string id)
            : base(id, UnitClassification.Psionic, 30, 1, 1)
        {
        }
    }
}
