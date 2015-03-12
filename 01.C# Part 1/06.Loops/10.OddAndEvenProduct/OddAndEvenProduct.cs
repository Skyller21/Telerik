using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OddAndEvenProduct
{
    static void Main()
    {
        Console.WriteLine("Enter the number of elements");
        int n = int.Parse(Console.ReadLine());
        List<int> myList = new List<int>();

        int productOdd = 1;
        int productEven = 1;

        Console.WriteLine("Enter the elements of the list");
        for (int i = 0; i < n; i++)
        {
            myList.Add(int.Parse(Console.ReadLine()));
        }

        for (int i = 0; i < myList.Count; i++)
        {
            if (i % 2 != 0)
            {
                productEven = productEven*myList[i];
            }
            else
            {
                productOdd = productOdd*myList[i];
            }
        }

        if (productEven == productOdd)
        {
            Console.WriteLine("\n------------\nYes\nProduct = {0}",productEven);
        }
        else
        {
            Console.WriteLine("\n------------\nNo\nProduct odd = {0}\nProduct even = {1}",productOdd,productEven);
        }
    }
}

