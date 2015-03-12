using System;

class SwapTwoVariables
{
    static void Main()
    {
        /*
         Problem 9. Exchange Variable Values
            Declare two integer variables a and b and assign them with 5 and 10 and after that exchange their values by using some programming logic.
            Print the variable values before and after the exchange.
         */
        int a = 5;
        int b = 10;
        int swap;

        Console.WriteLine("         a = {0}\n         b = {1}\n",a,b);

        swap = a;
        a = b;
        b = swap;

        Console.WriteLine("SWAP     a = " + a + "\n         b = " + b);

    }
}

