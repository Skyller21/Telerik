using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class ExtensionMethods
    {
        //Task 1
        public static StringBuilder Substring(this StringBuilder sb, int startIndex, int length)
        {
            StringBuilder result = new StringBuilder();
            for (int i = startIndex; i < startIndex+length; i++)
            {
                result.Append(sb[i]);
            }
            return result;
        }
         
        //Task 2
        //##########Question 1? How not to use dynamic without operator overloading?
        public static T Sum<T>(this IEnumerable<T> list)
        where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            if (list.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("ERROR: The list is empty");
            }
            T sum = default(T);
            foreach (var item in list)
            {
                sum = (dynamic)sum + item;
            }
            return sum;
        }

        public static T Min<T>(this IEnumerable<T> list)
        //where T: IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            if (list.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("ERROR: The list is empty");
            }
            return list.OrderBy(x => x).First();
        }

        public static T Max<T>(this IEnumerable<T> list)
        //where T: IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            if (list.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("ERROR: The list is empty");
            }
            return list.OrderByDescending(x => x).First();
        }

        public static T Average<T>(this IEnumerable<T> list)
        //where T: IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            if (list.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("ERROR: The list is empty");
            }
            //######Question 2? How to use lambda for Generic Average
            //return list.Average(x => x);
            T sum = default(T);
            T average = default(T);
            foreach (var item in list)
            {
                sum += (dynamic)item;
            }
            average = (dynamic)sum / list.Count();

            return average;
        }

        public static string ToStringT<T>(this IEnumerable<T> list)
        {
            return String.Join(",", list);
        }
    }
}
