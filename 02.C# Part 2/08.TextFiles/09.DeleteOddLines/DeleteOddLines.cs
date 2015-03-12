using System;
using System.IO;


class DeleteOddLines
{
    static void Main()
    {
        Console.WriteLine("The file has been modified.\n\rNOTE: Everytime you run the program again you will modify the file.");
        Console.WriteLine("After some time(depending on file size) the file will be emtpy");
        Console.WriteLine("To avoid it you can delete the file \"test.txt\" from the directory\n\rand rename the \"backup.txt\" to \"test.txt\".\n\rThen you can run the program again");
        using (StreamReader file = new StreamReader("../../test.txt"))
        {
            using (StreamWriter file1 = new StreamWriter("../../temp.txt"))
            {
                int check = 1;
                string readIt = file.ReadLine();
                while (readIt != null)
                {
                    if (check % 2 == 0)
                    {
                        file1.WriteLine(readIt);
                    }
                    readIt = file.ReadLine();
                    check++;
                }
            }
        }
        File.Replace("../../temp.txt", "../../test.txt", "../../backup.txt");
    }
}

