using System;

class AssignNullValues
{
    static void Main()
    {
        /*
         Problem 12. Null Values Arithmetic
            Create a program that assigns null values to an integer and to a double variable.
            Try to print these variables at the console.
            Try to add some number or the null literal to these variables and print the result.
         */
        int? someInteger = null;
        double? someDouble = null;

        Console.WriteLine("This is the interger with null value --> " + someInteger);
        Console.WriteLine("This is the double with null value --> " + someDouble);

        Console.WriteLine("This is the interger with null value --> " + someInteger.GetValueOrDefault());
        Console.WriteLine("This is the double with null value --> " + someDouble.GetValueOrDefault());

        someInteger = 5;
        someDouble = 2.5;

        Console.WriteLine("This is the interger with value --> " + someInteger);
        Console.WriteLine("This is the double with value --> " + someDouble);
    }
}

