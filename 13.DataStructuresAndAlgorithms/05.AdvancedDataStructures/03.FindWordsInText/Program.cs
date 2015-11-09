using System;
using System.Collections.Generic;

namespace _03.FindWordsInText
{
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            // Try it with true or no parameters for case sensitive search.
            var trie = new Trie<int>();

            GenerateTrie("../../Text.txt", trie);

            var wordsList = new List<string>()
            {
                "pesho",
                "gosho",
                "ivan",
                // Change it to test or Test and change the parameter ot the Trie and look what is changing :)
                "Test",
                "batman"
            };

            foreach (var word in wordsList)
            {
                Console.WriteLine("===============");
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                var words = trie.Retrieve(word);
                Console.WriteLine("{0} -> {1} times", word, words.Count());

                stopWatch.Stop();
                Console.WriteLine("Time for search: {0}", stopWatch.Elapsed);
            }
        }

        private static void GenerateTrie(string fileName, Trie<int> trie)
        {
            IEnumerable<Word> allWordsInFile = GetWordsFromFile(fileName);
            foreach (Word wordAndLine in allWordsInFile)
            {
                trie.Add(wordAndLine.WordString, wordAndLine.Line);
            }

        }

        private static IEnumerable<Word> GetWordsFromFile(string file)
        {
            using (StreamReader reader = File.OpenText(file))
            {
                Console.WriteLine("Processing file {0} ...", file);
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                int lineNo = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    lineNo++;
                    IEnumerable<string> words = Regex.Split(line, "\\W+");
                    if (words.Count() != 0)
                    {
                        foreach (string word in words)
                        {
                            yield return new Word { Line = lineNo, WordString = word };
                        }
                    }
                }
                stopWatch.Stop();
                Console.WriteLine("Lines:{0}\tTime for generating:{1}", lineNo, stopWatch.Elapsed);
            }
        }
    }
}
