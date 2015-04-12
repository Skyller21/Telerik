using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    public class InvalidRangeException<T> : ApplicationException where T : IComparable<T>
    {
        public InvalidRangeException(T start, T end)
            : base("The value is not in the boundaries")
        {
            this.Start = start;
            this.End = end;

        }

        public T Start { get; set; }

        public T End { get; set; }
    }
}
