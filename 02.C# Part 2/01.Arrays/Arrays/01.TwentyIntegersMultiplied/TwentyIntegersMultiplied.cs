using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TwentyIntegersMultiplied
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the size of the array");

        int size = int.Parse(Console.ReadLine());
        int[] myArray = new int[size];

        for (int i = 0; i < size; i++)
        {
            myArray[i] = i * 5;
            Console.WriteLine("element[{0}] = {1}",i,myArray[i]);
        }
    }
}