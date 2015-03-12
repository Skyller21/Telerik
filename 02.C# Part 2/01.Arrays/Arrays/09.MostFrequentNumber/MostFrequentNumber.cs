using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MostFrequentNumber
{
    static void Main(string[] args)
    {
        int[] arr = { 1,1,1,1,1,2,3,1,4,1,-1,0,-1,-1,-1,2,-1,4,-1,3,-1,5,-1,-1 };
        int counter = 1;
        int index = 0;
        Console.WriteLine(frequentNum(arr, index, counter));

        //int count = 1;
        //int tempNum;
        //int best = 1;
        //int freqNum = arr[0];

        //for (int i = 0; i < arr.Length; i++)
        //{
        //    tempNum = arr[i];
        //    count = 1;

        //    for (int j = i + 1; j < arr.Length; j++)
        //    {
        //        if (arr[j] == tempNum)
        //        {
        //            count++;
        //        }
        //    }
        //    if (count > best)
        //    {
        //        best = count;
        //        freqNum = arr[i];
        //    }
        //}
        //Console.WriteLine("The most frequent number is {0}: {1} times", freqNum, best);
    }
    static string frequentNum(int[] array, int index, int counter)
    {
        
        int tempCounter = 1;
        
        if (index >= array.Length)
        {
            return "The number " + index + " is the most frequent number in the array: " + counter + " times";
        }
        else
        {
            int temp = array[index];

            for (int i = index + 1; i < array.Length; i++)
            {
                if (temp == array[i])
                {
                    tempCounter++;
                }
            }

            if (tempCounter > counter)
            {
                counter = tempCounter;
                int tempIndex = temp;
            }
            return frequentNum(array, index + 1, counter);
        }
    }
}
