using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GreatestCommonDivisor
{
    static void Main()
    {
        Console.WriteLine("Enter the first number");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second number");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("The GDC of {0} and {1} is: {2}",a,b,FindGCD(a, b));
    }

    //Euclidean algorithm http://en.wikipedia.org/wiki/Euclidean_algorithm

    static int FindGCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (a != b)
        {
            if (a > b)
            {
                a = a - b;
                b = b;
                return FindGCD(a, b);  //Recursion. Check google or http://www.introprogramming.info/intro-csharp-book/read-online/glava10-rekursia/
            }
            else
            {
                b = b - a;
                a = a;
                return FindGCD(a, b);  //Recursion. Check google or http://www.introprogramming.info/intro-csharp-book/read-online/glava10-rekursia/
            }
        }
        return a;
    }
}

