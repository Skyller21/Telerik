using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReadMatrixAndFindMaxSquare
{
    static void Main()
    {
        string file = "../../matrix.txt";
        int[,] matrix = ReadMatrix(file);
        PrintMatrix(matrix);
        CreateFile(CalculateMaxSquare(matrix));
        Console.WriteLine();
        Console.WriteLine("The file is created and the result is: {0}", CalculateMaxSquare(matrix));
        Console.WriteLine();
    }

    static int[,] ReadMatrix(string file)
    {
        using (StreamReader readIt = new StreamReader(file))
        {
            int size = int.Parse(readIt.ReadLine());
            int[,] matrix = new int[size, size];
            string symbol = null;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    symbol = (readIt.Read() - 48).ToString();
                    matrix[row, col] = int.Parse(symbol);
                    symbol = readIt.Read().ToString();
                }
                symbol = readIt.ReadLine();
            }
            return matrix;
        }
    }

    static int CalculateMaxSquare(int[,] matrix)
    {
        int max = 0;
        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1] > max)
                {
                    max = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                }
            }
        }
        return max;
    }

    static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine("The matrix is:");
        Console.WriteLine(new string('=',20));
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0} ", matrix[i, j]);
            }
            Console.WriteLine();
        }

    }

    static void CreateFile(int max)
    {
        using (StreamWriter writeFile = new StreamWriter("../../result.txt"))
        {
            writeFile.WriteLine(max);
        }
    }
}

