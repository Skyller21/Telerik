namespace Assertions_Homework.SearchingAlgorithms
{
    using System;
    using System.Diagnostics;

    public static class SearchingAlgorithms
    {
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array is null");
            Debug.Assert(arr.Length > 0, "The array is empty");

            Debug.Assert(value != null, "The searched value is null");

            Debug.Assert(startIndex >= 0 && startIndex <= arr.Length - 1, "The start index is not in the array boundaries");
            Debug.Assert(endIndex >= 0 && endIndex <= arr.Length - 1, "The end index is not in the array boundaries");
            Debug.Assert(startIndex <= endIndex, "The start index greater than the end index");
            
            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
        }
}
