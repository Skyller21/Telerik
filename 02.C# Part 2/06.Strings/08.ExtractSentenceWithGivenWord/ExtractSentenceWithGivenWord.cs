using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class ExtractSentenceWithGivenWord
{
    static void Main()
    {
        Console.WriteLine("Input a word to find");
        string word = Console.ReadLine();
        string str = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        foreach (Match m in Regex.Matches(str,"([A-Z]+|\"[A-Z]+)([A-Za-z,;><'\"\\s\\d]+)([.?!]\"|[.?!])"))
        {
            if (Regex.Match(m.ToString(),"\\b"+word+"\\b").Length>0)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
}

