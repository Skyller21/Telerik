using System;
using System.IO;


class ReadFileAndPrintsOddLines 
{
    static void Main()
    {
        using (StreamReader file = new StreamReader("../../temp.txt"))        //NOTE: The files for each exercise is in the folder of the exercise!!!
        {
            int check = 1;
            string readIt = file.ReadLine();
            while (readIt != null)
            {
                if (check % 2 != 0)
                {
                    Console.WriteLine(readIt);
                }
                readIt = file.ReadLine();
                check++;
            }
        }
    }
}

