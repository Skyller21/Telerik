using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CompareFloats
{
    static void Main(string[] args)
    {
        double eps = 0.000001;   //Epsilon - precision to compare numbers

        Console.WriteLine("Input first floating point number");
        double firstNum = double.Parse(Console.ReadLine());

        Console.WriteLine("Input second floating point number");
        double secondNum = double.Parse(Console.ReadLine());

        bool checkEps = true;

        if (Math.Abs(firstNum - secondNum) <= eps) 
        {
            checkEps = true;
        }
        else
        {
            checkEps = false;
        }

        Console.WriteLine("The two numbers are equal: {0}",checkEps.ToString().ToLower());
    }
}

