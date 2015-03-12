using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class DeleteWordsGivenInOtherFile
{
    static void Main()
    {
        try
        {
            StringBuilder word = new StringBuilder();
            List<string> wordList = new List<string>();
            using (StreamReader readFile = new StreamReader("../../word_remove.txt"))
            {
                string line = readFile.ReadLine();

                while (line != null)
                {
                    foreach (Match m in Regex.Matches(line, "\\w+"))
                    {
                        wordList.Add(m.ToString());
                    }
                    line = readFile.ReadLine();
                }

            }

            using (StreamReader readFile = new StreamReader("../../text.txt"))
            {
                using (StreamWriter writeFile = new StreamWriter("../../new.txt"))
                {
                    string line = readFile.ReadLine();
                    while (line != null)
                    {
                        for (int i = 0; i < wordList.Count; i++)
                        {
                            line = Regex.Replace(line, wordList[i],"",RegexOptions.IgnoreCase);
                            
                        }
                        writeFile.WriteLine(line);
                        line = readFile.ReadLine();
                    }
                }
            }
            Console.WriteLine("Words to remove from the text:");
            foreach (var words in wordList)
            {
                Console.WriteLine(words);
            }
            Console.WriteLine();
            Console.WriteLine("The file has been created and the name is new.txt \n\r");

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

