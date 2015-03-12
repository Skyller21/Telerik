using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BinarySearch
{
    static void Main(string[] args)
    {
        int[] array = { -1, 0, 2, 3, 4, 5, 8, 9, 10, 11 };

        int[] sortedArray = array.OrderBy(x => x).ToArray();

        binarySearch(sortedArray, 10, 0, sortedArray.Length - 1);


    }

    static void binarySearch(int[] array, int element, int maxIndex, int minIndex)
    {
        int indexTemp = (maxIndex + minIndex) / 2;
        if (array[indexTemp] == element)
        {
            if (maxIndex < minIndex)
            {
                Console.WriteLine("No found");
                return;
            }
            else
            {
                Console.WriteLine("element[{0}] = {1}",indexTemp,element);
                return;
            }

        }
        else
        {
            if (element < array[indexTemp])
            {
                minIndex = 0;
                maxIndex = indexTemp;

                binarySearch(array, element, maxIndex, minIndex);
            }
            else if (element > array[indexTemp])
            {
                minIndex = indexTemp+1;
                maxIndex = array.Length - 1;
                binarySearch(array, element, maxIndex, minIndex);
            }

        }
    }
}
