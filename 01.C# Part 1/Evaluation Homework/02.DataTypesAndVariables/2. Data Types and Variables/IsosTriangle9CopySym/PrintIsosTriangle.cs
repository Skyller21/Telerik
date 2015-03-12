using System;
using System.Text;


class IsosTriangle9CopySym
{
    static void Main()
    {
        /*  
        Problem 8. Isosceles Triangle
            Write a program that prints an isosceles triangle of 9 copyright symbols ©, something like this:
            Note: The © symbol may be displayed incorrectly at the console so you may need to change the console character encoding to UTF-8 and assign a Unicode-friendly font in the console.
            Note: Under old versions of Windows the © symbol may still be displayed incorrectly, regardless of how much effort you put to fix it.
         */
        char copyRightSym = '\u00a9';
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("    " + copyRightSym + "    \n");
        Console.WriteLine("   " + copyRightSym + " " + copyRightSym + "   "+"\n");
        Console.WriteLine("  " + copyRightSym + "   " + copyRightSym + "  "+"\n");
        Console.WriteLine(" " + copyRightSym + " " + copyRightSym + " " + copyRightSym + " " + copyRightSym + " "+"\n");

        
    }
}

