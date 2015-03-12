using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CompareTwoArrays
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first array with comma separated values(example: 2,0,5,-1)");
        string arrStr1 = Console.ReadLine();
        Console.WriteLine("Enter the second array with comma separated values(example: 2,0,5,-1)");
        string arrStr2 = Console.ReadLine();

        string[] myArray1 = arrStr1.Split(',');
        string[] myArray2 = arrStr2.Split(',');
        try
        {
            if (myArray1.Length != myArray2.Length)
            {
                throw new ArgumentOutOfRangeException("The arrays are not of the same size!!!");
            }
            for (int i = 0; i < myArray1.Length; i++)
            {
                if (int.Parse(myArray1[i]) > int.Parse(myArray2[i]))
                {
                    Console.WriteLine("{0}>{1}", myArray1[i], myArray2[i]);
                }
                else if (int.Parse(myArray1[i]) < int.Parse(myArray2[i]))
                {
                    Console.WriteLine("{0}<{1}", myArray1[i], myArray2[i]);
                }
                else
                {
                    Console.WriteLine("{0}={1}", myArray1[i], myArray2[i]);
                }
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            throw;
        }
    }
}
