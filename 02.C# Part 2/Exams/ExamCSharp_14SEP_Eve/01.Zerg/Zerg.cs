using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Zerg
{
    class Zerg
    {
        static void Main(string[] args)
        {
            string[] zergNum = {"Rawr",
                                "Rrrr",
                                "Hsst",
                                "Ssst",
                                "Grrr",
                                "Rarr",
                                "Mrrr",
                                "Psst",
                                "Uaah",
                                "Uaha",
                                "Zzzz",
                                "Bauu",
                                "Djav",
                                "Myau",
                                "Gruh"};

            string line = Console.ReadLine();

            Regex regex = new Regex("[A-Z]{1}[a-z]{3}");
            Match m = regex.Match(line);

            List<int> num = new List<int>();

            while (m.Success)
            {

                num.Add(Array.IndexOf(zergNum, m.ToString()));
                m = m.NextMatch();
            }

            //Console.WriteLine(num);
            ulong multiple = 1;
            ulong result = 0;
            for (int i = num.Count - 1; i >= 0; i--)
            {
                result += ulong.Parse(num[i].ToString()) * multiple;
                multiple *= 15;
            }

            Console.WriteLine(result);
        }
    }
}
