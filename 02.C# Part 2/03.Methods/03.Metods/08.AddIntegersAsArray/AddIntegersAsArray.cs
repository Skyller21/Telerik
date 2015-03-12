using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.AddIntegersAsArray
{
    class AddIntegersAsArray
    {
        static string numberOne;
        static string numberTwo;
        static int[] oneArray;
        static int[] twoArray;

        static int max;

        static void Main()
        {
            Console.Write("A =  ");
            numberOne = Console.ReadLine();
            Console.Write("B =  ");
            numberTwo = Console.ReadLine();
            Console.WriteLine(new string('-', 50));
            max = Math.Max(numberOne.Length, numberTwo.Length);
            oneArray = new int[max + 1];
            twoArray = new int[max + 1];
            int[] finalArray = new int[max + 1];

            if (CheckNumberFormat() == true)
            {
                ConvertNumberToArray();
                finalArray = AddNumbers(oneArray, twoArray);
                Console.Write("SUM = ");
                PrintSum(finalArray);
            }
            else
            {
                Console.WriteLine("Out of range exeption!");
            }
        }

        static bool CheckNumberFormat()
        {
            if (max > 10000)
            {
                return false;
            }
            return true;
        }

        static void ConvertNumberToArray()
        {
            for (int i = numberOne.Length - 1; i >= 0; i--)
            {
                int a = Convert.ToByte(numberOne.Substring(numberOne.Length - 1 - i, 1));
                oneArray[i] = a;
            }
            for (int j = numberTwo.Length - 1; j >= 0; j--)
            {
                int a = Convert.ToByte(numberTwo.Substring(numberTwo.Length - 1 - j, 1));
                twoArray[j] = a;
            }
        }

        static int[] AddNumbers(int[] oneArray, int[] twoArray)
        {
            int max = Math.Max(numberOne.Length, numberTwo.Length);
            int[] finalArray = new int[max + 1];
            for (int i = 0; i <= max; i++)
            {
                if (i == 0)
                {
                    finalArray[i] = (oneArray[i] + twoArray[i]) % 10;
                }
                else
                {
                    finalArray[i] = (oneArray[i] + twoArray[i]) % 10 + (oneArray[i - 1] + twoArray[i - 1]) / 10;
                }

            }
            return finalArray;
        }

        static void PrintSum(int[] finalArray)
        {
            for (int i = (max + 1) - 1; i >= 0; i--)
            {
                if (i == (max + 1) - 1 && finalArray[max] == 0)
                {
                    continue;
                }
                else
                {
                    Console.Write(finalArray[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
