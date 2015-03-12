using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.MathProblem
{
    class MathProblem
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            //string numStr="";
            
            BigInteger sum = new BigInteger();

            foreach (var item in text)
            {
                BigInteger number = new BigInteger();
                int multiply = 1;
                for (int i = item.Length - 1; i >= 0; i--)
                {
                    number = number + (item[i] - 'a') * multiply;
                    multiply *= 19;
                }
                sum += number;
            }

            BigInteger numTemp = sum;
            string dec = "";
            while (numTemp>0)
            {


                dec = dec + (char)(numTemp % 19 + 'a');
                numTemp = numTemp / 19;
            }

            string str = "";
            for (int i = dec.Length - 1; i >= 0; i--)
            {
                str += dec[i];
            }

            Console.WriteLine("{0} = {1}", str, sum);
            

            
        }
    }
}
