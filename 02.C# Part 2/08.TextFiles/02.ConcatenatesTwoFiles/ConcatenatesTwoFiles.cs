using System;
using System.IO;

class ConcatenatesTwoFiles
{
    static void Main()
    {
        string[] str = { "../../temp1.txt", "../../temp2.txt" };

        if (CheckAnswer() == "y")
        {
            ConcatenateFiles("../../new.txt", str);
            PrintConcatenated("../../new.txt");
        }
        else { Console.WriteLine("Good bye"); }
    }

    static void ConcatenateFiles(string outputFile, params string[] inputFiles)
    {
        using (Stream output = File.OpenWrite(outputFile))
        {
            foreach (string inputFile in inputFiles)
            {
                using (Stream input = File.OpenRead(inputFile))
                {
                    input.CopyTo(output);
                }
            }
        }
    }

    static void PrintConcatenated(string file)
    {
        using (StreamReader streamFile = new StreamReader(file))
        {
            string readIt = streamFile.ReadLine();
            while (readIt != null)
            {
                Console.WriteLine(readIt);
                readIt = streamFile.ReadLine();
            }
        }
    }

    static string CheckAnswer()
    {
        string answer = null;
        do
        {
            Console.WriteLine("Do you want to concatenate the two files? (y/n):");
            answer = Console.ReadLine();
        } while (answer != "y" && answer != "n");
        return answer;
    }
}

