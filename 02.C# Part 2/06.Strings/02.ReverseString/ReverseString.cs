using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReverseString
{
    static void Main()
    {
        Console.WriteLine("Enter a string to reverse");
        string str = Console.ReadLine();
        char[] revString = str.ToCharArray();
        Array.Reverse(revString);
        revString.ToString();
        Console.WriteLine(revString);
    }
}

