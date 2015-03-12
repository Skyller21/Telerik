using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.TRES4Numbers
{
    class TRES4Numbers
    {
        static void Main(string[] args)
        {
            BigInteger numberDecimal = BigInteger.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            //Console.WriteLine(ulong.MaxValue);
            string[] values = {"LON+",
                                "VK-",
                                "*ACAD",
                                "^MIM",
                                "ERIK|",
                                "SEY&",
                                "EMY>>",
                                "/TEL",
                                "<<DON"
                                };

            do
            {
                BigInteger tempNum = numberDecimal % 9;
                list.Add(values.ElementAt((int)tempNum));
                numberDecimal /= 9;
            } while (numberDecimal > 0);

            for (int i = list.Count - 1; i >= 0; i--)
            {
                Console.Write(list[i]);
            }
            Console.WriteLine();
        }
    }
}
