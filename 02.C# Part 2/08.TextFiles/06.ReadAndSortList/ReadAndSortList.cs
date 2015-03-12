using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReadAndSortList
{
    static void Main()
    {
        string unsortedNames = "../../list.txt";
        List<string> unsortedList = ReadList(unsortedNames);
        Console.WriteLine("The unsorted list of names is:");
        PrintNames(unsortedList);
        WriteFile(SortedNames(unsortedList));
        Console.WriteLine("\n\rThe file is written.\n\r\n\rThe sorted list of names is:");
        PrintNames(SortedNames(unsortedList));
        Console.WriteLine();

    }

    static List<string> ReadList(string file)
    {
        List<string> nameList = new List<string>();
        using (StreamReader readFile = new StreamReader(file))
        {
            string row = readFile.ReadLine();
            while (row != null)
            {
                nameList.Add(row);
                row = readFile.ReadLine();
            }
        }
        return nameList;
    }

    static List<string> SortedNames(List<string> nameList)
    {
        nameList.Sort();
        return nameList;
    }

    static void WriteFile(List<string> names)
    {
        using (StreamWriter write = new StreamWriter("../../sorted_names.txt"))
        {
            foreach (var name in names)
            {
                write.WriteLine(name);
            }
        }
    }

    static void PrintNames(List<string> names)
    {
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}

