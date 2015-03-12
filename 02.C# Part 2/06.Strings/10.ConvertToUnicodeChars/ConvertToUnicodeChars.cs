using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ConvertToUnicodeChars
{
    static void Main()
    {
        Console.WriteLine("Enter text to convert");
        string str = Console.ReadLine();

        char[] unicodeArray = str.ToCharArray();
        for (int i = 0; i < unicodeArray.Length; i++)
        {
            Console.Write("\\u{0}",((int)unicodeArray[i]).ToString("X4"));
        }
        Console.WriteLine();
        
    }
}

