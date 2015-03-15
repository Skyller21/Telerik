using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Point : IComparable,IComparable<Point>
    {
        public Point() { }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Point other)
        {
            throw new NotImplementedException();
        }
    }
}
