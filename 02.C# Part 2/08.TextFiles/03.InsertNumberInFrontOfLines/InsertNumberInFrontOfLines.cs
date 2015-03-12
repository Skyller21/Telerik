using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class InsertNumberInFrontOfLines
{
    static void Main()
    {
        string file = "../../temp.txt";

        if (CheckAnswer() == "y")
        {
            InsertNumbers(file);
            PrintNewFile("../../new.txt");
        }
        else { Console.WriteLine("Good bye"); }

    }
    static void InsertNumbers(string file)
    {
        using (StreamReader reader = new StreamReader(file))
        {
            using (StreamWriter writer = new StreamWriter("../../new.txt"))
            {
                int check = 1;
                string readIt = reader.ReadLine();
                while (readIt != null)
                {
                    if (check < 10)
                    {
                        writer.Write("0");
                        writer.Write("{0}. ",check);
                        writer.WriteLine(readIt);
                    }
                    else
                    {
                        writer.Write("{0}. ",check);
                        writer.WriteLine(readIt);
                    }

                    check++;
                    readIt = reader.ReadLine();
                }
            }
        } 
    }
    static string CheckAnswer()
    {
        string answer = null;
        do
        {
            Console.WriteLine("Do you want to put numbers in front of the lines? (y/n):");
            answer = Console.ReadLine();
        } while (answer != "y" && answer != "n");
        return answer;
    }

    static void PrintNewFile(string file)
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
}

