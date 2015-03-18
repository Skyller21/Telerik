using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredefinedDelegates
{
    class Program
    {
        //Action е void. Няма return.
        //Func приема два параметъра и връща трети
        static void Main(string[] args)
        {
            Func<int, int, string> func = delegate(int num1, int num2)
            {
                Console.WriteLine("Concat");
                string result = string.Format("{0}{1}", num1, num2);
                Console.WriteLine(result);
                return result;
            };

            func += delegate(int num1, int num2)
            {
                Console.WriteLine("Sum");

                string result = (num2 + num1).ToString();
                return result;
            };


            Console.WriteLine(func(13, 11));  
        }
    }
}
