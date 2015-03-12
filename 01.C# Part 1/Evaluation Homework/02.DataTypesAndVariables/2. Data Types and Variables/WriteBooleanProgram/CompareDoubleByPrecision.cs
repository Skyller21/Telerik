using System;

class CompareDoubleByPrecision
{
    static void Main()
    {
        /*
         Problem 13.* Comparing Floats
            Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.
            Note: Two floating-point numbers a and b cannot be compared directly by a == b because of the nature of the floating-point arithmetic. 
            Therefore, we assume two numbers are equal if they are more closely to each other than a fixed constant eps.
         */
        double eps = 0.000001;
        double a = 5.3;
        double b = 6.01;
        double c = 4.999999;
        double d = 4.999998;

        Boolean CompareAB = (Math.Abs(a - b) < eps);
        Console.WriteLine(CompareAB);   // False

        Boolean CompareCD = (Math.Abs(c - d) < eps);
        Console.WriteLine(CompareCD);   // True
    }
}
