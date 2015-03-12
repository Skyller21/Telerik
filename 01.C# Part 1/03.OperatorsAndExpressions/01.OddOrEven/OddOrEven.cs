using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OddOrEven
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number to check if it is odd or even:");
        int numberToCheck = int.Parse(Console.ReadLine());

        if (numberToCheck % 2 == 0)                                     //Check if the ramainder is 0. If it is 0 the the number is even.
        {
            Console.WriteLine("The number {0} is even", numberToCheck);
        }
        else
        {
            Console.WriteLine("The number {0} is odd", numberToCheck);
        }
    }
}

