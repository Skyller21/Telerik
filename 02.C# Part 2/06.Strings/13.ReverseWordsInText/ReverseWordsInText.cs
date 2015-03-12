using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReverseWordsInText
{
    static void Main()
    {
        string str = "C# is not C++, not PHP and not Delphi!";
        string[] tempStr = str.Split(' ');
        Array.Reverse(tempStr);
        string[] splitStr = str.Split(new char[] { ',', ' ','.','!','?' },StringSplitOptions.RemoveEmptyEntries);
        StringBuilder finStr = new StringBuilder();
        for (int i = splitStr.Length - 1; i >= 0; i--)
        {
            if (tempStr[i].Contains(",") || tempStr[i].Contains("!") || tempStr[i].Contains(".") || tempStr[i].Contains("?"))
            {
                finStr.Append(splitStr[i]);
                finStr.Append(tempStr[i].Substring(tempStr[i].Length - 1, 1));
                finStr.Append(" ");
            }
            else
            {
                finStr.Append(splitStr[i]);
                finStr.Append(" ");
            }
        }
        Console.WriteLine(finStr);
        Console.WriteLine();
    }
}

