using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FourDigitNumber
{
    public static string number;
    static void Main()
    {
        Console.WriteLine("Input four digit number:");
        number = Console.ReadLine();
        Console.WriteLine("The sum of all the digits is: {0}",SumOfDigits(number));
        Console.Write("The reversed number is: ");
        ReverseNumber(number);
        Console.Write("The last digit in front: ");
        LastDigitInFront(number);
        Console.Write("Exchanged second and third digit: ");
        ExchangeDigits(number);
        Console.WriteLine();

        Main();
    }

    //Here are some methods which do the magic :) check this link http://www.introprogramming.info/intro-csharp-book/read-online/glava9-metodi/
    static int SumOfDigits(string num)          
    {                                           
        int numberInt = 0;
        for (int i = 0; i < num.Length; i++)
        {
            numberInt = numberInt + int.Parse(num[i].ToString());
        }
        return numberInt;
    }

    static void ReverseNumber(string num)
    {
        StringBuilder str = new StringBuilder();
        for (int i = num.Length - 1; i >= 0; i--)
        {
            str.Append(num[i]);
        }
        Console.WriteLine(str);
    }

    static void LastDigitInFront(string num)
    {
        StringBuilder str = new StringBuilder();
        str.Append(num[num.Length - 1]);

        for (int i = 0; i < num.Length - 1; i++)
        {
            str.Append(num[i]);
        }
        Console.WriteLine(str);
    }

    static void ExchangeDigits(string num)
    {
        StringBuilder str = new StringBuilder(num);

        str[1] = num[2];
        str[2] = num[1];

        Console.WriteLine(str);
    }
}

