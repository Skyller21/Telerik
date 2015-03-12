using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class SubstringCount
{
    static void Main()
    {
        Console.WriteLine("Enter the text");
        string text = Console.ReadLine();
        int count = 0;

        //regex style
        string pattern = @"in";
        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
        MatchCollection match = rgx.Matches(text);
        

        Console.WriteLine("REGEX: The string \"in\"(case insensitive) is in the text: {0} times", match.Count);

        //loop style
        int index = text.ToLower().IndexOf("in", 0);
        for (int i = index; i < text.Length;i=index)
			{
                if (index >= 0)
                {
                    count++;
                }
                else
                {
                    break;
                }
                index = text.ToLower().IndexOf("in", i + 1);
                
			}
        Console.WriteLine("LOOP: The string \"in\"(case insensitive) is in the text: {0} times", count);
    }
}

