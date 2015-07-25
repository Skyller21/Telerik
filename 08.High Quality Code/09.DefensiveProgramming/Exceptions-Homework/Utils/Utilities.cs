namespace Exceptions_Homework.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Exceptions_Homework.Validators;

    public static class Utilities
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            Validator.IsArrayNullOrEmpty(arr);

            if (startIndex + count > arr.Length)
            {
                throw new ArgumentOutOfRangeException("The count of the elements is outside of the boundaries of the array");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }
            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            Validator.IsStringNull(str, "string to extract ending from");

            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException("The count of text to be extracted is not in the range of the string");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }
            return result.ToString();
        }

        public static void CheckPrime(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("Numbers smaller than 1 cannot be prime numbers");
            }
            bool isPrime = true;
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    Console.WriteLine("The number {0} is not prime!", number);
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.WriteLine("The number {0} is prime number!", number);
            }
        }
    }
}
