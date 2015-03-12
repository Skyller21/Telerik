using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaximumSumSequence
{
    static void Main(string[] args)
    {
        int[] arr = { 10, 10, -10, 5, 6, -1, 0, 0, -8, 8 };
        int startIndex = 0;
        int endIndex = 0;
        int sum = arr[0];
        int temp = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            temp = arr[i];
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (temp >= sum)
                {
                    startIndex = i;
                    sum = temp;
                    endIndex = j - 1;
                }
                temp = temp + arr[j];
            }
        }
        Console.WriteLine(sum);
        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
}
