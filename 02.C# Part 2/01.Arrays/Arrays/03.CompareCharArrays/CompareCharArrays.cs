using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CompareCharArrays
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first char array with comma separated values(example: a,c,f,p)");
        string arrStr1 = Console.ReadLine();
        Console.WriteLine("Enter the second char array with comma separated values(example: v,e,n,p)");
        string arrStr2 = Console.ReadLine();


        List<char> myList1 = new List<char>();
        List<char> myList2 = new List<char>();

        for (int i = 0; i < arrStr1.Length; i++)
        {
            myList1.Add(arrStr1[i]);
            myList2.Add(arrStr2[i]);
            myList1.Remove(',');
            myList2.Remove(',');
        }

        
        try
        {
            if (myList1.Count != myList2.Count)
            {
                throw new ArgumentOutOfRangeException("The arrays are not of the same size!!!");
            }
            for (int i = 0; i < myList1.Count; i++)
            {
                if (myList1[i] > myList2[i])
                {
                    Console.WriteLine("{0}>{1}", myList1[i], myList2[i]);
                }
                else if (myList1[i] < myList2[i])
                {
                    Console.WriteLine("{0}<{1}", myList1[i], myList2[i]);
                }
                else
                {
                    Console.WriteLine("{0}={1}", myList1[i], myList2[i]);
                }
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            throw;
        }
    }
}

