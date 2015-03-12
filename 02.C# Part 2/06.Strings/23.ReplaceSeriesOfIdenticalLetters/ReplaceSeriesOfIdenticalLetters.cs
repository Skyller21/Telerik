using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class ReplaceSeriesOfIdenticalLetters
{
    static void Main()
    {
        string text = "aaaaabbbbbcdddeeeedssaa";

        
        List<char> charArr = new List<char>();
        int j = 0;
        charArr.Add(text[0]);
        for (int i = 1; i < text.Length; i++)
        {
            if (text[i] != text[j])
            {
                charArr.Add(text[i]);
                j=i;
            }
        }

        foreach (var item in charArr)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }
}

