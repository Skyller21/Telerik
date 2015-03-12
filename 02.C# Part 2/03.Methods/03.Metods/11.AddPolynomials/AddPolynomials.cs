using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.AddPolynomials
{
    class AddPolynomials
    {
        static void Main()
        {

            //The format of the array is x^n+x^n-1+...+x^3+x^2+x^1+x^0

            List<int> numberOne = new List<int> { 2, 2, 3, 4, 5 };
            List<int> numberTwo = new List<int> { 1, 2, 3, 4, 5 };


            int max = Math.Max(numberOne.Count, numberTwo.Count);
            int[] tempArray = new int[max];
            List<int> finalArray = new List<int>(tempArray);

            ExpandLesserList(numberOne, numberTwo);
            Console.WriteLine("The first polynomial is:");
            PrintPoly(numberOne);
            Console.WriteLine("The second polynomial is:");
            PrintPoly(numberTwo);

            finalArray = AddPoly(numberOne, numberTwo, finalArray);
            Console.WriteLine("The final polynomial is:");
            PrintPoly(finalArray);
            Console.WriteLine();
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
