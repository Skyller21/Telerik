using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03.Patterns
{
    class Patterns
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                string[] line = (Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
            }
            int counter = 0;
            BigInteger sum = long.MinValue;

            for (int i = 0; i <= n - 3; i++)
            {
                for (int j = 0; j <= n - 5; j++)
                {
                    if (CheckPattern(i, j, matrix))
                    {
                        counter++;
                        BigInteger tempSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j + 2] + matrix[i + 2, j + 2] + matrix[i + 2, j + 3] + matrix[i + 2, j + 4];
                        if (tempSum > sum)
                        {
                            sum = tempSum;
                        }
                    }
                    
                }
            }

            if (counter>0)
            {
                Console.WriteLine("YES {0}",sum);
            }
            else
            {
                Console.WriteLine("NO {0}",CalculateDiagonal(matrix));
            }



        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static bool CheckPattern(int row, int col, int[,] matrix)
        {
            bool check = true;
            int num = matrix[row, col];
            if (matrix[row, col + 1] != num + 1)
            {
                check = false;
                return check;
            }
            if (matrix[row, col + 2] != num + 2)
            {
                check = false;
                return check;
            }
            if (matrix[row + 1, col + 2] != num + 3)
            {
                check = false;
                return check;
            }
            if (matrix[row + 2, col + 2] != num + 4)
            {
                check = false;
                return check;
            }
            if (matrix[row + 2, col + 3] != num + 5)
            {
                check = false;
                return check;
            }
            if (matrix[row + 2, col + 4] != num + 6)
            {
                check = false;
                return check;
            }
            return check;
        }

        static BigInteger CalculateDiagonal(int[,] matrix)
        {
            BigInteger sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }
            return sum;
        }
    }
}
