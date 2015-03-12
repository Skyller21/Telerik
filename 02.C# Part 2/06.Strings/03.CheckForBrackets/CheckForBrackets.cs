using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CheckForBrackets
{
    static void Main()
    {
        Console.WriteLine("Enter mathematical expression");
        string mathExpression = Console.ReadLine();
        int countOpen = 0;
        int countClose = 0;
        char[] mathArray = mathExpression.ToCharArray();

        foreach (var element in mathArray)
        {
           if(element==40)
           {
               countOpen++;
           }
           else if(element==41)
           {
               countClose++;
           }
        }
        Console.WriteLine( );
        
        if (countOpen != countClose)
        {
            Console.WriteLine("The brackets are incorrectly putted");
        }
        else
        {
            Console.WriteLine("The brackets are correctly putted");
        }
    }
}

