using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BishopPathFinder
{
    static void Main(string[] args)
    {

        string[] str = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        int rows = int.Parse(str[0]);
        int cols = int.Parse(str[1]);
        int start = 0;

        //int[,] chessboard = new int[,]{
        //{15, 18, 21, 24, 27, 30, 33},
        //{12, 15, 18, 21, 24, 27, 30},
        //{ 9, 12, 15, 18, 21, 24, 27},
        //{ 6,  9, 12, 15, 18, 21, 24},
        //{ 3,  6,  9, 12, 15, 18, 21},
        //{ 0,  3,  6,  9, 12, 15, 18},
        //};

        int[,] chessboard = CreateChessboard(rows, cols);



        int n = int.Parse(Console.ReadLine());
        List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();


        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            list.Add(new KeyValuePair<string, int>(line[0], int.Parse(line[1])));

            //Console.WriteLine(list[i]);
        }



        int startRow = chessboard.GetLength(0) - 1;
        int startCol = 0;

        int currentRow = startRow;
        int currentCol = startCol;


        //int xMove = 0;
        //int yMove = 0;
        long sum = 0;
        for (int i = 0; i < list.Count; i++)
        {
            int xMove = 0;
            int yMove = 0;
            string direction = list[i].Key;
            int points = 0;
            //chessboard[currentRow, currentCol] = 0;
            switch (direction)
            {
                case "UR": xMove--; yMove++;  break;
                case "RU": xMove--; yMove++;  break;
                case "DR": xMove++; yMove++;  break;
                case "RD": xMove++; yMove++;  break;
                case "UL": xMove--; yMove--;  break;
                case "LU": xMove--; yMove--;  break;
                case "DL": xMove++; yMove--;  break;
                case "LD": xMove++; yMove--;  break;
                default: break;
            }

            //if (chessboard[currentRow, currentCol] != -1)
            //{
            //    break;
            //}

            int moves = list[i].Value-1;
            string stop = "";
            for (int move = 0; move < moves; move++)
            {
                //chessboard[currentRow, currentCol] = 0;
                if ((currentCol + yMove < chessboard.GetLength(1) && currentCol + yMove >= 0) &&
                    (currentRow + xMove < chessboard.GetLength(0) && currentRow + xMove >= 0))
                {
                    //sum = sum + chessboard[currentRow, currentCol];
                    
                    currentRow = currentRow + xMove;
                    currentCol = currentCol + yMove;
                    sum += chessboard[currentRow, currentCol];
                    chessboard[currentRow, currentCol] = 0;

                }
                else
                {

                    break;
                    
                }
            }

            //if (stop=="YES")
            //{
            //    break;
            //}
            


        }
        //PrintMatrix(chessboard);
        Console.WriteLine(sum);
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 10)
                {
                    Console.Write(" " + matrix[i, j] + " ");

                }
                else
                {
                    Console.Write(matrix[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }

    static int[,] CreateChessboard(int rows, int cols)
    {
        
        int[,] chessboard = new int[rows, cols];
        int start = 0;
        
        for (int row = rows - 1; row >= 0; row--)
        {
            int temp = start;
            for (int col = 0; col < cols; col++)
            {

                
                chessboard[row, col] = temp;
                temp = temp + 3;

            }
            start += 3;
        }

        return chessboard;


    }

}

