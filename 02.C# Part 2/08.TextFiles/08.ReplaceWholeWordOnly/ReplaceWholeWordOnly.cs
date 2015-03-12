using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class ReplaceWholeWordOnly
{
    static void Main()
    {
        ReplaceWord("../../start.txt");
    }
    static void ReplaceWord(string fileToRead)
    {
        using (StreamReader file = new StreamReader(fileToRead))
        {
            using (StreamWriter newFile = new StreamWriter("../../finish.txt"))
            {
                string row = file.ReadLine();
                while (row != null)
                {
                    row = Regex.Replace(row,@"\bstart\b", "finish");
                    newFile.WriteLine(row);
                    row = file.ReadLine();
                }
            }
        }
    }
}

