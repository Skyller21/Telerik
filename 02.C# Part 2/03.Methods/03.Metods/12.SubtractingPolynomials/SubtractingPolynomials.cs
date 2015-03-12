using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.SubtractingPolynomials
{
    class SubtractingPolynomials
    {

        static void Main()
        {

            List<int> numberOne = new List<int> { 1, 2, 3, 4, 5 };
            List<int> numberTwo = new List<int> { 1, 7, 2, -5, 0 };


            int max = Math.Max(numberOne.Count, numberTwo.Count);
            int[] tempArray = new int[max];
            List<int> finalArray = new List<int>(tempArray);
            int[] multipliedArray = new int[tempArray.Length * 2];
            List<int> multipliedList = multipliedArray.ToList();


            ExpandLesserList(numberOne, numberTwo);
            Console.WriteLine("The first polynomial is:");
            PrintPoly(numberOne);
            Console.WriteLine("The second polynomial is:");
            PrintPoly(numberTwo);
            Console.WriteLine();

            finalArray = AddPoly(numberOne, numberTwo, finalArray);
            Console.WriteLine("The final polynomial after SUMMATION is:");
            PrintPoly(finalArray);
            Console.WriteLine();


            finalArray = SubtractPoly(numberOne, numberTwo, finalArray);
            Console.WriteLine("The final polynomial after SUBTRACTION is:");
            PrintPoly(finalArray);
            Console.WriteLine();

            multipliedList = MultiplyPoly(numberOne, numberTwo, multipliedList);
            Console.WriteLine("The final polynomial after MULTIPLICATION is:");
            PrintPoly(multipliedList);
        }

        static void ExpandLesserList(List<int> oneArray, List<int> twoArray)
        {
            if (oneArray.Count < twoArray.Count)
            {
                for (int i = oneArray.Count; i < twoArray.Count; i++)
                {
                    oneArray.Insert(0, 0);
                }
            }
            else
            {
                for (int i = twoArray.Count; i < oneArray.Count; i++)
                {
                    twoArray.Insert(0, 0);
                }
            }
        }

        static List<int> AddPoly(List<int> oneArray, List<int> twoArray, List<int> finalArray)
        {
            for (int i = 0; i < finalArray.Count; i++)
            {
                finalArray[i] = (oneArray[i] + twoArray[i]);
            }
            return finalArray;
        }

        static List<int> SubtractPoly(List<int> oneArray, List<int> twoArray, List<int> finalArray)
        {
            for (int i = 0; i < finalArray.Count; i++)
            {
                finalArray[i] = (oneArray[i] - twoArray[i]);
            }
            return finalArray;
        }

        static List<int> MultiplyPoly(List<int> oneArray, List<int> twoArray, List<int> finalArray)
        {
            //int temp = 0;

            for (int j = 0; j < finalArray.Count / 2; j++)
            {
                for (int i = 0; i < finalArray.Count / 2; i++)
                {
                    finalArray[i + j] = finalArray[i + j] + oneArray[j] * twoArray[i];
                }
            }
            return finalArray;

        }

        static void PrintPoly(List<int> finalArray)
        {
            for (int i = 0; i < finalArray.Count; i++)
            {
                if (i == finalArray.Count - 1)
                {
                    Console.Write("{0}", finalArray[i]);
                }
                else if (finalArray[i] == 0)
                {
                    Console.Write("");
                }
                else
                {
                    Console.Write("{0}x^{1} + ", finalArray[i], finalArray.Count - 1 - i);
                }
            }
            Console.WriteLine();
        }

    }
}
