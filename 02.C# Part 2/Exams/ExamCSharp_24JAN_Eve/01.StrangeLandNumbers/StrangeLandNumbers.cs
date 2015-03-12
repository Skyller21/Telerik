using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.StrangeLandNumbers
{
    class StrangeLandNumbers
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string num = string.Empty;

            char[] values = { 'f', 'b', 'o', 'm', 'l', 'p', 'h' };

            foreach (Match m in Regex.Matches(text,"[a-z]{1}"))
            {
                num += m;
            }
            ulong strangeNumDecimal = 0;
            ulong multiply = 1;

            for (int i = num.Length - 1; i >= 0; i--)
            {

                strangeNumDecimal += (ulong)Array.IndexOf(values, num[i]) *multiply;
                multiply *= 7;
            }

            Console.WriteLine(strangeNumDecimal);
        }
    }
}
