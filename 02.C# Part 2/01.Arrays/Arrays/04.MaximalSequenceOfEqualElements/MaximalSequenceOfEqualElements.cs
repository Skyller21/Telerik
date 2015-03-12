using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MaximalSequenceOfEqualElements
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the array comma separated(example: 2,3,1,4)");

        int count = 1;
        int temp = 1;
        char symbol = ' ';
        string arrStr = Console.ReadLine();

        List<char> myList = new List<char>();
        List<string> strList = new List<string>();

        for (int i = 0; i < arrStr.Length; i++)
        {
            myList.Add(arrStr[i]);
            myList.Remove(',');
        }

        for (int i = 1; i < myList.Count; i++)
        {
            if (myList[i - 1] == myList[i])
            {
                temp++;
            }
            if (myList[i - 1] != myList[i] | i == myList.Count - 1)
            {
                if (temp > count)
                {
                    count = temp;
                    symbol = myList[i - 1];
                }
                temp = 1;
            }
        }

        for (int i = 0; i < count; i++)
        {
            if (i!=count-1)
            {
                Console.Write(symbol+",");
            }
            else
            {
                Console.WriteLine(symbol);
            }
        }
    }
}
