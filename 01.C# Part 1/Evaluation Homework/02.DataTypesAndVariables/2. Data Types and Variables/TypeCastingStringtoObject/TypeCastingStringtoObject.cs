using System;

class TypeCastingStringtoObject
{
    static void Main()
    {
        /*
         Problem 6. Strings and Objects
            Declare two string variables and assign them with Hello and World.
            Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval between).
            Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).
         */
        string someWord1 = "Hello";
        string someWord2 = "World";
        object greeting = someWord1 + " " + someWord2;
        Console.WriteLine(greeting);
        string str = (string) greeting;
        Console.WriteLine(str);
    }
}

