using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class IncreasingSequence
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the array comma separated(example: 2,3,1,4)");

        string[] myList = Console.ReadLine().Split(',');

        List<int> tempList = new List<int>();
        tempList.Add(int.Parse(myList[0]));

        List<int> finalList = new List<int>();

        for (int i = 1; i < myList.Length; i++)
        {
            if (int.Parse(myList[i - 1]) < int.Parse(myList[i]))
            {
                tempList.Add(int.Parse(myList[i]));

            }
            if (int.Parse(myList[i - 1]) >= int.Parse(myList[i]) | i==myList.Length-1)
            {
                if (tempList.Count > finalList.Count)
                {
                    finalList.Clear();
                    foreach (var item in tempList)
                    {
                        finalList.Add(item);
                    }
                }
                tempList.Clear();
                tempList.Add(int.Parse(myList[i]));
            }
        }

        for (int i = 0; i < finalList.Count; i++)
        {
            Console.WriteLine(finalList[i]);
        }
    }
}
