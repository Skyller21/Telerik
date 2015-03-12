using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PrimeNumberCheck
{
    //The prime numbers definition http://bg.wikipedia.org/wiki/%D0%9F%D1%80%D0%BE%D1%81%D1%82%D0%BE_%D1%87%D0%B8%D1%81%D0%BB%D0%BE
    static void Main(string[] args)
    {
        Console.WriteLine("Enter an integer between 1 and 100:");
        int numberToCheck = int.Parse(Console.ReadLine());
        bool prime = true;

        for (int i = 2; i < 10; i++)
        {
            if (numberToCheck % i == 0 && numberToCheck != i || numberToCheck <=1)
            {
                prime = false;
            }
        }
        Console.WriteLine("Is {0} prime: {1}",numberToCheck, prime);
    }
}
