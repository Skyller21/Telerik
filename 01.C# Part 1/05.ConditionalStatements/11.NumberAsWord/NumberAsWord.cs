using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NumberAsWord
{
    static void Main()
    {
        Console.WriteLine("Enter a number between 0 and 999");
        int number = int.Parse(Console.ReadLine());
        string text = "Non-valid number";

        List<string> ones = new List<string>() { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        List<string> teens = new List<string>() { "", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        List<string> tens = new List<string>() { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        string hundred = "hundred";

        if (number == 0)
        {
            text = "Zero";
        }
        else if (number < 10)
        {
            text = ToSentenceCase(ones[number]);
        }

        else if (number > 10 & number < 20)
        {
            text = ToSentenceCase(teens[number - 10]);
        }

        else if (number == 10 || (number >= 20 && number < 100))
        {
            text = ToSentenceCase(tens[(number / 10) % 10] + " " + ones[number % 10]);
        }

        else if (number > 99 && number < 1000)
        {
            if (number % 100 >= 10 && number % 100 < 20)
            {
                text = ToSentenceCase(ones[(number / 100) % 10] + " hundred and " + teens[number % 10]);
            }
            else if (number%100==0)
            {
                text = ToSentenceCase(ones[(number / 100) % 10] + " hundred");
            }
            else 
            {
                text = ToSentenceCase(ones[(number / 100) % 10] + " hundred and " + tens[(number / 10) % 10] + " " + ones[number % 10]);
            }
        }
        Console.WriteLine(text+"\n");

        Main();

    }

    static string ToSentenceCase(string str)
    {
        StringBuilder stringNew = new StringBuilder();

        for (int i = 0; i < str.Length; i++)
        {
            if (i == 0)
            {
                stringNew.Append(str[i].ToString().ToUpper());
            }
            else
            {
                stringNew.Append(str[i]);
            }
        }
        return stringNew.ToString();
    }


}
