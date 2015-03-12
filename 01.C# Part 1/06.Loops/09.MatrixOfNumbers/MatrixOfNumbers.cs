using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatrixOfNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter the side of the matrix");
        int size = int.Parse(Console.ReadLine());

        for (int i = 1; i <= size; i++)
        {
            for (int j = i; j < size+i; j++)
            {
                if (j<10)
                {
                    Console.Write(j.ToString().PadLeft(2) + " ");  //This PadLeft(2) is to align the numbers.
                }                                                  //If you want the numbers to be aligned even if they are bigger than
                else                                               // 100 you should use if->else if-> else if... and so on                 
                {
                    Console.Write(j + " ");
                }
            }
            Console.WriteLine();
        }
    }
}

