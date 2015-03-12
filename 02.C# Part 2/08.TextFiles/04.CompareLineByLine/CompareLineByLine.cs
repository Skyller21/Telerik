using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CompareLineByLine
{
    static void Main()
    {
        string file1 = "../../temp1.txt";
        string file2 = "../../temp2.txt";
        CompareFiles(file1, file2);
    }

    static void CompareFiles(string file1, string file2)
    {
        int counter = 0;
        using (StreamReader read1 = new StreamReader(file1))
        {
            using (StreamReader read2 = new StreamReader(file2))
            {
                Console.WriteLine("The rows that are the same in both files are printed below:\n\r");
                Console.WriteLine(new string('=',50));
                string row1 = read1.ReadLine();
                string row2 = read2.ReadLine();
                while (row1 != null)
                {
                    if (row1 == row2)          //The comparison is CASE Sensitive
                    {
                        counter++;
                        Console.WriteLine(row1);
                    }
                    row1 = read1.ReadLine();
                    row2 = read2.ReadLine();
                }
            }
        }
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("\n\rThe rows count is: {0}\n\r", counter);

    }
}

