using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SequenceOfSum
{
    static void Main(string[] args)
    {
        int[] arr = { 4, 3, 1, 4, 2, 5, 8 };
        Console.WriteLine("Enter the sum to search");
        int sum = int.Parse(Console.ReadLine());

        searchSum(arr, 0, sum);
    }

    static void searchSum(int[] array, int index, int sum)
    {
        int tempSum = array[index];
        string str = tempSum.ToString();
        if (index >= array.Length - 1)
        {
            return;
        }
        else
        {
            for (int i = index + 1; i < array.Length; i++)
            {
                if (index == array.Length - 2)
                {
                    tempSum += array[i];
                    str += ", " + array[i].ToString();
                }
                if (tempSum < sum)
                {
                    str += ", " + array[i].ToString();
                }
                else if (tempSum > sum)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(str);
                }
                tempSum += array[i];
            }
            searchSum(array, index + 1, sum);
        }
    }
}
