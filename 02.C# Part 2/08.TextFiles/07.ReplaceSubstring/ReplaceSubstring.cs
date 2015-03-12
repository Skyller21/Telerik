using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReplaceSubstring
{
    static void Main()
    {
        ReplaceSub("../../start.txt");
    }
    static void ReplaceSub(string fileToRead)
    {
        using (StreamReader file = new StreamReader(fileToRead))
        {
            using (StreamWriter newFile = new StreamWriter("../../finish.txt"))
            {
                string row = file.ReadLine();
                while (row != null)
                {
                    row = row.Replace("start", "finish");
                    newFile.WriteLine(row);
                    row = file.ReadLine();
                }
            }
        }
    }
}

