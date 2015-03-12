using System;
using System.IO;
using System.Text.RegularExpressions;

class RemoveTagsFromXmlFile
{
    static void Main()
    {
        using (StreamReader fileToRead = new StreamReader("../../xml_start.txt"))
        {
            using (StreamWriter fileToWrite = new StreamWriter("../../xml_final.txt"))
            {
                string line = fileToRead.ReadLine();

                while (line != null)
                {
                    foreach (Match m in Regex.Matches(line, "(>)(.*?)(<)"))
                    {
                        if (m.Groups[2].ToString()!="")
                        {
                            fileToWrite.Write(m.Groups[2].ToString());
                        }
                        
                    }
                    
                    line = fileToRead.ReadLine();
                }

            }
        }
        Console.WriteLine("The file has been created");
    }
}

