using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class ExtractPalindromes
{
    static void Main()
    {
        string text = "In the text the words exe, lamal, ABBA, rotor, level are palindromes.";

        foreach (Match word in Regex.Matches(text,@"\w+"))
        {
            string wordOne = word.ToString();
            char[] tempChar = wordOne.ToCharArray();
            Array.Reverse(tempChar);
            string revWord = new string(tempChar);
            if (wordOne == revWord)
            {
                Console.WriteLine("Is palindrome: {0}",word);
            }
        }
    }
}
