namespace Assertions_Homework.SorthingAlgorithms
{
    using System;
    using System.Diagnostics;
    using Utils;

    public static class SortingAlgorithms
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array is null");
            Debug.Assert(arr.Length > 0, "The array is empty");
            Debug.Assert(arr.Length != 1, "The array is already sorted");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = Utilities.FindMinElementIndex(arr, index, arr.Length - 1);
                Utilities.Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }
    }
}
