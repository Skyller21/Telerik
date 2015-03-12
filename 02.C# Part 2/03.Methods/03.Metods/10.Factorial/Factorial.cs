using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Factorial
{
    class Factorial
    {
        static string numberOne;
        static int max;
        static int factorial;

        static void Main()
        {
            Console.Write("N! =  ");
            numberOne = Console.ReadLine();
            factorial = int.Parse(numberOne);
            Console.WriteLine(new string('-', 15));
            max = 500;
            int[] oneArray = new int[max];
            int[] twoArray = new int[max];
            int[] finalArray = new int[max];

            if (factorial == 0 || factorial == 1)
            {
                Console.WriteLine("{0}! = {1}", numberOne, 1);
            }
            else
            {


                if (CheckNumberFormat() == true)
                {
                    oneArray = ConvertNumberToArray(numberOne);
                    for (int i = factorial - 1; i >= 1; i--)
                    {
                        twoArray = ConvertNumberToArray(i.ToString());
                        finalArray = MultiplyNumbers(oneArray, twoArray);
                        oneArray = finalArray;
                    }
                    Console.WriteLine("{0}! = {1}", factorial, PrintFactorial(finalArray));
                }
                else
                {
                    Console.WriteLine("Too big...\nTry number less than 100!");
                    Main();
                }
            }
        }

        static bool CheckNumberFormat()
        {
            if (factorial > 100)                //Boundary for the input!!!
            {
                return false;
            }
            return true;
        }

        static int[] ConvertNumberToArray(string numberOne)
        {
            int[] array = new int[max];
            for (int i = numberOne.Length - 1; i >= 0; i--)
            {
                int a = Convert.ToByte(numberOne.Substring(numberOne.Length - 1 - i, 1));
                array[i] = a;
            }
            return array;
        }

        static int[] MultiplyNumbers(int[] oneArray, int[] twoArray)
        {
            int[] finalArray = new int[max];
            int[] finalArray1 = new int[max];

            int[] summedArray = new int[max];
            for (int i = 0; i < max; i++)
            {
                int[] tempArray = new int[max];

                for (int j = 0; j < max; j++)
                {
                    if (j == 0)
                    {
                        finalArray[j] = (oneArray[i] * twoArray[j]) % 10;
                        finalArray1[j] = 0;
                    }

                    else
                    {
                        finalArray[j] = (oneArray[i] * twoArray[j]) % 10;
                        finalArray1[j] = (oneArray[i] * twoArray[j - 1]) / 10;
                    }
                }
                tempArray = AddNumbers(finalArray, finalArray1);
                summedArray = AddNumbers(summedArray, MoveArray(i, tempArray));
            }
            return summedArray;
        }

        static StringBuilder PrintFactorial(int[] finalArray)
        {
            StringBuilder newString = new StringBuilder();
            for (int i = max - 1; i >= 0; i--)
            {
                newString.Append(finalArray[i]);
            }

            for (int i = max - 1; i >= 0; i--)
            {
                if (finalArray[i] == 0)
                {
                    newString = newString.Remove(0, 1);
                }
                else { break; }
            }
            return newString;
        }

        static int[] AddNumbers(int[] oneArray, int[] twoArray)
        {
            int[] array = new int[max];
            for (int i = 0; i <= max - 1; i++)
            {
                if (i == 0)
                {
                    array[i] = (oneArray[i] + twoArray[i]) % 10;
                }
                else
                {
                    array[i] = (oneArray[i] + twoArray[i]) % 10 + (oneArray[i - 1] + twoArray[i - 1]) / 10;
                }
            }
            return array;
        }

        static int[] MoveArray(int move, int[] array)
        {
            int[] localArray = new int[max];
            for (int i = 0; i < array.Length; i++)
            {
                if (i >= move)
                {
                    localArray[i] = array[i - move];
                }
                else
                {
                    localArray[i] = 0;
                }
            }
            return localArray;
        }
    }
}
