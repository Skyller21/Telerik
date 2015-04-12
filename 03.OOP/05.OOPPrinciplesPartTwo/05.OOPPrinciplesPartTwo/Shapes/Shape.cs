using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Shapes
{
    abstract class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public string Type { get; set; }
        public abstract double CalculateSurface();


        

        public override string ToString()
        {
            return String.Format("Area {0} ({1},{2}) = {3}", this.GetType().Name, this.Width, this.Height,
                this.CalculateSurface());
        }
    }
}
