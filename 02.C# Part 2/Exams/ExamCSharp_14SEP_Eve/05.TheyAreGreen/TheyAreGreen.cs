using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.TheyAreGreen
{
    class TheyAreGreen
    {
        static void Main(string[] args)
        {
            string str = "jihgfedcba";
            IEnumerable<char> list = new List<char>() { 'j', 'i', 'h', 'g', 'f', 'e', 'd', 'c', 'b', 'a', };
            int n = str.Length;
            //Console.WriteLine(GetPermutations(list,n));
            IEnumerable<IEnumerable<char>> fin = Enumerable.Empty<IEnumerable<char>>();
            fin = GetPermutations(list, n);

            Regex regex = new Regex("(.)\\1{1,}");
            int count = 0;
            foreach (var item in fin)
            {
                string str1 = string.Join("", item.ToArray());
                Match m = regex.Match(str1);
                if (!m.Success)
                {
                    count++;
                }
                    //Console.WriteLine(str1);
            }

            Console.WriteLine(count);
        }

        static IEnumerable<IEnumerable<T>>
    GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
