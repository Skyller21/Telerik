using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class UpcaseTag
{
    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        foreach (Match m in Regex.Matches(text,@"(<upcase>)([\w .]+)(</upcase>)"))
        {
            string replace = m.Groups[2].ToString();
            text = text.Replace(m.ToString(),replace.ToUpper());
        }
       
        Console.WriteLine(text);
    }
}

