using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class ReplaceForbiddenWords
{
    static void Main()
    {
        string str = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

        string[] forbiddenWords = { "Microsoft", "PHP", "CLR" };

        foreach (Match m in Regex.Matches(str,forbiddenWords[0]+"|"+forbiddenWords[1]+"|"+forbiddenWords[2]))
        {
            str = str.Replace(m.ToString(), new string('*', m.ToString().Length));
        }

        Console.WriteLine(str);
    }
}

