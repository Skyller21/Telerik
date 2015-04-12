using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Square : Rectangle
    {
        public Square(double side)
            : base(side, side)
        {

        }

        public override double CalculateSurface()
        {
            return this.Height*this.Width;
        }
    }
}
