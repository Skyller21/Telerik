namespace Assertions_Homework.Utils
{
    using System;
    using System.Diagnostics;

    public static class Utilities
    {
        internal static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
        {

            Debug.Assert(arr != null, "The array is null");
            Debug.Assert(arr.Length > 0, "The array is empty");

            Debug.Assert(startIndex >= 0 && startIndex <= arr.Length - 1, "The start index is not in the array boundaries");
            Debug.Assert(endIndex >= 0 && endIndex <= arr.Length - 1, "The end index is not in the array boundaries");
            Debug.Assert(startIndex <= endIndex, "The start index greater than the end index");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }
            return minElementIndex;
        }

        internal static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null, "The first number to swap is null");
            Debug.Assert(x != null, "The second number to swap is null");
            
            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
