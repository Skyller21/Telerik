using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Relevance
{
    class Relevance
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string[] sentences = new string[n];
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                sentences[i] = Console.ReadLine();
                sentences[i] = Regex.Replace(sentences[i], "[,.)(;! ?-]+", " ");
                sentences[i] = Regex.Replace(sentences[i], "\\s+", " ");
                sentences[i] = Regex.Replace(sentences[i], "\\b" + word + "\\b", word.ToUpper(), RegexOptions.IgnoreCase);
                sentences[i] = sentences[i].Trim();
                int m = Regex.Matches(sentences[i], "\\b"+word.ToUpper()+"\\b",RegexOptions.IgnoreCase).Count;
                
                dict.Add(sentences[i], m);
            }

            var list = dict.OrderByDescending(x => x.Value).ToList();

            foreach (var item in list)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
