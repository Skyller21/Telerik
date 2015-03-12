using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FillMatrixExampleD
{
    class FillMatrixExampleD
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the size of the square matrix");
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            int[,] matrix = new int[rows, cols];
            int number = 1;
            int upBoundary = 0;
            int leftBoundary = 0;

            int downBoundary = n - 1;
            int rightBoundary = n - 1;

            int currentRow = 0;
            int currentCol = 0;



            while (number <= n * n)
            {
                //Move Down
                while (currentRow <= downBoundary)                        //While we get out of the matrix
                {
                    matrix[currentRow, currentCol] = number;
                    number++;
                    currentRow++;
                }

                currentRow = downBoundary;                                //We are out of the matrix so we set the current row to the boundary value
                leftBoundary++;                                           //We have already been to the whole column so we change the boundary
                currentCol++;                                             //We begin to move on the right so we get the next column

                //Move Rigth
                while (currentCol <= rightBoundary)                        //While we get out of the matrix
                {
                    matrix[currentRow, currentCol] = number;
                    number++;
                    currentCol++;
                }


                currentCol = rightBoundary;                                //We are out of the matrix so we set the current col to the boundary value 
                downBoundary--;                                            //We have already been to the whole row so we change the boundary
                currentRow--;                                              //We begin to move up so we get the next row

                //Move Up
                while (currentRow >= upBoundary)                            //While we get out of the matrix
                {
                    matrix[currentRow, currentCol] = number;
                    number++;
                    currentRow--;
                }

                currentRow = upBoundary;                                    //We are out of the matrix so we set the current row to the boundary value
                rightBoundary--;                                            //We have already been to the whole column so we change the boundary
                currentCol--;                                               //We begin to move on the left so we get the next column

                //Move Left
                while (currentCol >= leftBoundary)                          //While we get out of the matrix
                {
                    matrix[currentRow, currentCol] = number;
                    number++;
                    currentCol--;
                }

                currentCol = leftBoundary;                                   //We are out of the matrix so we set the current col to the boundary value
                upBoundary++;                                                //We have already been to the whole row so we change the boundary
                currentRow++;                                                //We begin to move down so we get the next row
                
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
