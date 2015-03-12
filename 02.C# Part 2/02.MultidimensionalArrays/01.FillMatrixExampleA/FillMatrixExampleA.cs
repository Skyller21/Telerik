using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FillMatrixExampleA
{
    class FillMatrixExampleA
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the size of the square matrix");
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            int[,] matrix = new int[rows,cols];
            int start = 1;

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    matrix[row, col] = start;
                    start++;
                }
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
