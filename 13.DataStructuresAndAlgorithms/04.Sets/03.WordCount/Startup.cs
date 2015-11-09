using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WordCount
{
    using System.IO;
    using System.Text.RegularExpressions;

    class Startup
    {
        static void Main(string[] args)
        {
            const string path = "../../words.txt";

            var fileText = File.ReadAllText(path);

            var arr = Regex.Split(fileText, "\\W+").Where(i => i != string.Empty);


            var dict = new Dictionary<string, int>();

            foreach (var item in arr)
            {
                if (!dict.ContainsKey(item.ToLower()))
                {
                    dict.Add(item.ToLower(), 1);
                }
                else
                {
                    dict[item.ToLower()]++;
                }
            }


            var filteredSet = dict.OrderBy(i => i.Value);

            foreach (var item in filteredSet)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
