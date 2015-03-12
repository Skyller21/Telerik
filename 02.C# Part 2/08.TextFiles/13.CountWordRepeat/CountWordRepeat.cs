using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class CountWordRepeat
{
    static void Main()
    {
        try
        {
            StringBuilder word = new StringBuilder();
            Dictionary<string, int> wordList = new Dictionary<string, int>();
            using (StreamReader readFile = new StreamReader("../../words.txt"))
            {
                string line = readFile.ReadLine();

                while (line != null)
                {
                    foreach (Match m in Regex.Matches(line, "\\w+"))
                    {
                        wordList.Add(m.ToString(), 1);
                    }
                    line = readFile.ReadLine();
                }

            }
            foreach (var w in wordList.Keys.ToList())
            {
                using (StreamReader readFile = new StreamReader("../../test.txt"))
                {
                    string row = readFile.ReadLine();
                    while (row != null)
                    {
                        foreach (Match m in Regex.Matches(row, "\\b" + w + "\\b"))
                        {
                            wordList[m.ToString()] = wordList[m.ToString()] + 1;
                            
                            
                        }

                        row = readFile.ReadLine();
                    }
                }
            }

            using (StreamWriter newFile = new StreamWriter("../../result.txt"))
            {
                var list = wordList.Keys.ToList();
                list.Sort();

                foreach (var w in list)
                {
                    newFile.WriteLine(w+" - "+ wordList[w]);
                }
            }

            Console.WriteLine("The file has been created.\n\rNOTE: The search for the words is case sensitive.");
        }
        catch (FileNotFoundException exept)
        {
            Console.WriteLine(exept.Message);
        }

        catch (DirectoryNotFoundException exept)
        {
            Console.WriteLine(exept.Message);
        }

        catch (IOException exept)
        {
            Console.WriteLine(exept.Message);
        }

        catch (UnauthorizedAccessException exept)
        {
            Console.WriteLine(exept.Message);
        }
    }
}

