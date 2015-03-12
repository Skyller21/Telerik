using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FillMatrixExampleC
{
    class FillMatrixExampleC
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the size of the square matrix");
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            int[,] matrix = new int[rows, cols];
            int number = 1;
            int startRow = rows - 1;
            int startCol = 0;

            while (number < n * n)
            {

                while (startRow >= 0)
                {
                    int currentRow = startRow;
                    int currentCol = startCol;
                    while (currentRow < rows)
                    {
                        matrix[currentRow, currentCol] = number;
                        number++;
                        currentRow++;
                        currentCol++;
                    }
                    startRow--;
                }

                startRow = 0;
                startCol = 1;
                while (startCol < cols)
                {
                    int currentRow = startRow;
                    int currentCol = startCol;
                    while (currentCol < cols)
                    {
                        matrix[currentRow, currentCol] = number;
                        number++;
                        currentRow++;
                        currentCol++;
                    }
                    startCol++;
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
                    Console.Write(matrix[row, col].ToString().PadLeft(4) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
