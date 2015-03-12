using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.ReverseANumber
{
    class ReverseANumber
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer");
            string num = Console.ReadLine();

            Console.WriteLine("The reversed number is: " + ReverseNum(num));
        }

        static string ReverseNum(string num)
        {
            StringBuilder revNum = new StringBuilder();
            for (int i = num.Length-1; i >= 0; i--)
            {
                revNum.Append(num[i]);
            }
            return revNum.ToString();
        }
    }
}
