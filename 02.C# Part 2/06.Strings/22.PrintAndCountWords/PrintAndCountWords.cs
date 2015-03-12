using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class PrintAndCountWords
{
    static void Main()
    {

        string text = "Telerik’s mission is to make software development easier and more enjoyable. This mission is enjoyable. The easier you make it, the easier it gets!";
        Dictionary<string, int> wordDict = new Dictionary<string, int>();
        string[] words = Regex.Split(text, "\\W+");

        foreach (var word in words)
        {
            if (word != String.Empty)
            {
                if (wordDict.ContainsKey(word))
                {
                    wordDict[word]++;
                }
                else
                {
                    wordDict.Add(word, 1);
                }
            }

        }
        var ordered = wordDict.OrderByDescending(x => x.Value);
        Console.WriteLine("{0,-10}{1,15}", "Word", "Counts");
        Console.WriteLine(new string('=',30));
        foreach (var word in ordered)
        {
            Console.WriteLine("{0,-13}{1,10}", word.Key, word.Value);
            Console.WriteLine(new string('-', 30));
        }

    }
}

