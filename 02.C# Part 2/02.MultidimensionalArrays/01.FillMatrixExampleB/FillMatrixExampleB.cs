using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FillMatrixExampleB
{
    class FillMatrixExampleB
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the size of the square matrix");
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            int[,] matrix = new int[rows, cols];
            int number = 1;
            int currentRow = 0;
            int currentCol = 0;

            while (number < n * n)
            {
                while (currentRow < rows)
                {
                    matrix[currentRow, currentCol] = number;
                    number++;
                    currentRow++;
                }
                currentRow = rows - 1;
                currentCol++;

                if (currentCol>=cols)
                {
                    break;
                }

                while (currentRow >= 0)
                {
                    matrix[currentRow, currentCol] = number;
                    number++;
                    currentRow--;
                }
                currentRow = 0;
                currentCol++;
                
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col].ToString().PadLeft(4) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
