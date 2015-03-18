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
        public static int Pow(this int num, int pow)
        {
            int result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *= num;
            }
            return result;
        }


        public static string ToString<T>(this IEnumerable<T> enumerable, string separator)
        {
            string str = String.Join(separator, enumerable);
            return str;
        }
    }
}
