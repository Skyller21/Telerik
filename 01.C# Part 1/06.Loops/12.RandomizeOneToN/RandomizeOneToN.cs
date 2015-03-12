using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


static class RandomizeOneToN
{
    static void Main()
    {
        Console.WriteLine("Enter the numbers count");
        int n = int.Parse(Console.ReadLine());

        List<int> myList = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            myList.Add(i);
        }

        Random random = new Random();



        List<int> myListRandomized = myList.OrderBy(x => random.Next()).ToList();

        for (int i = 0; i < myListRandomized.Count; i++)
        {
            Console.Write(myListRandomized[i] + " ");
        }
        Console.WriteLine();

        /*
         If you uncomment all the code from here down you will use Fisher-Yates algorithm
        http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle

        Shuffle(myList, random);

        for (int i = 0; i < myList.Count; i++)
        {
            Console.Write(myList[i]+" ");
        }
        Console.WriteLine();
         */
    }

    /*
     public static void Shuffle<T>(this IList<T> list, Random rnd)
    {
        for (var i = 0; i < list.Count; i++)
            list.Swap(i, rnd.Next(i, list.Count));
    }

    public static void Swap<T>(this IList<T> list, int i, int j)
    {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
     */
}

