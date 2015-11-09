using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.NumberOfOccurrences
{
    class Startup
    {
        static void Main(string[] args)
        {
            double[] arr = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5};

            var dict = new SortedDictionary<double, int>();

            foreach (var item in arr)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 0);
                }
                else
                {
                    dict[item]++;
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }
        }
    }
}
