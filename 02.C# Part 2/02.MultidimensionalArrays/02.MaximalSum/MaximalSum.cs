using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MaximalSum
{
    class MaximalSum
    {
        static int squareSize;
        static void Main(string[] args)
        {
            // Read the matrix dimensions
            Console.Write("Number of rows = ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Number of columns = ");
            int cols = int.Parse(Console.ReadLine());

            // Allocate the matrix
            int[,] matrix = new int[rows, cols];

            // Enter the matrix elements
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("matrix[{0},{1}] = ", row, col);
                    int element = int.Parse(Console.ReadLine());
                    matrix[row, col] = element;
                }
            }
            // Print the matrix on the console
            Console.WriteLine();
            Console.WriteLine("The whole matrix is as follows:");
            PrintMatrix(matrix);

            //Find the maximum square
            squareSize = 3;
            int startRow = 0;
            int startCol = 0;
            int maxSum = int.MinValue;


            for (int row = 0; row <= rows-squareSize; row++)
            {
                for (int col = 0; col <= cols-squareSize; col++)
                {
                    if (FindMaxSum(row, col, matrix) > maxSum)
                    {
                        maxSum = FindMaxSum(row, col, matrix);
                        startRow = row;
                        startCol = col;
                    }
                    
                }
            }

            Console.WriteLine("\nThe {0}x{0} square to have maximum sum is:",squareSize);
            PrintSquare(matrix, startRow, startCol);
            Console.WriteLine("\nThe sum of the square is: {0}",maxSum);
        }

        static int FindMaxSum(int startRow, int startCol, int[,] matrix)
        {
            int tempSum = 0;
            
            for (int row = startRow; row < startRow + squareSize; row++)
            {
                for (int col = startCol; col < startCol + squareSize; col++)
                {
                    tempSum += matrix[row, col];
                }
            }
           
            return tempSum;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row, col].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }

        static void PrintSquare(int[,] matrix, int startRow, int startCol)
        {
            for (int row = startRow; row < startRow+3; row++)
            {
                for (int col = startCol; col < startCol+3; col++)
                {
                    Console.Write("{0} ", matrix[row, col].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }
    }
}
