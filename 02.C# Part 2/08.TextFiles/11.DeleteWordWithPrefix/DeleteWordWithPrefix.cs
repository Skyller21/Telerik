using System;
using System.IO;
using System.Text.RegularExpressions;


class DeleteWordWithPrefix
{
    static void Main()
    {
        using (StreamReader fileToRead = new StreamReader("../../test.txt"))
        {
            using (StreamWriter fileToWrite = new StreamWriter("../../new.txt"))
            {
                string line = fileToRead.ReadLine();
                while (line != null)
                {
                    line = Regex.Replace(line, "\\btest[^\\s]*", "",RegexOptions.IgnoreCase);
                    fileToWrite.WriteLine(line);
                    line = fileToRead.ReadLine();
                    
                }
            }
        }
        Console.WriteLine("The file has been created.");
    }

    
}

