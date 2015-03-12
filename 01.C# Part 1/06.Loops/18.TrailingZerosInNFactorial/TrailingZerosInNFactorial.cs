using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class TrailingZerosInNFactorial
{
    static void Main()
    {
        Console.WriteLine("Enter number to calculate factorial");
        int n = int.Parse(Console.ReadLine());

        int counter = 0;
        
        for (int i = 5; i <= n; i = i*5)            //Check this links and you will understand the logic behind this loop
        {                                           //http://www.purplemath.com/modules/factzero.htm                
            counter = counter + n / i;              //http://puzzles.nigelcoldwell.co.uk/nineteen.htm
        }
        
        Console.WriteLine("There are {0} zeros in {1}!", counter, n);

        //This is the code with calculating factorial, but it is very very slow with big numbers.

        //BigInteger factorial = 1;  

        //for (ulong i = 1; i <= n; i++)
        //{
        //    factorial = factorial * i;
        //}

        //int counter = 0;
        //BigInteger temp = factorial;
        ////while (temp % 10 == 0)
        ////{
        ////    temp = temp / 10;
        ////    counter++;
        ////}
        //Console.WriteLine(factorial);
        //Console.WriteLine(counter);
    }
}
