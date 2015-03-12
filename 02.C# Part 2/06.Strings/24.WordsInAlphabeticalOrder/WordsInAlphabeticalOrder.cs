using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class WordsInAlphabeticalOrder
{
    static void Main()
    {
        string words = "Baseball Football Cricket Rugby Basketball Swimming Golf Volleyball Windsurfing Racing";

        string[] wordArray = words.Split(' ');
        var sortedList = wordArray.OrderBy(x => x);

        foreach (var item in sortedList)
        {
            Console.WriteLine(item);
        }
    }
}

