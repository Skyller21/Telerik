namespace _08.MazeModified
{
    using System;

    class Program
    {
        private static string[,] maze;
        static void Main(string[] args)
        {
            maze = new string[,]
            {
                {" ", " ", " ", " ", " ", " "},
                {" ", "x", "x", "x", "x", " "},
                {" ", "*", "x", " ", "x", " "},
                {"x", "x", " ", " ", " ", "e"},
                {" ", "x", " ", "x", "x", " "},
                {" ", " ", " ", "x", " ", "x"},
            };

            var startCell = new Cell<int>(-1, -1);
            FindStartingCell(startCell, maze);

            try
            {
                Console.WriteLine(FindPaths(startCell.Row, startCell.Col, false));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("There is no start position '*' provided in the maze");
            }
        }

        private static bool FindPaths(int startRow, int startCol, bool check)
        {
            if (maze[startRow, startCol] == "e")
            {
                return true;
            }

            // Backtracking
            maze[startRow, startCol] = "o";

            // up

            if (startRow > 0 && maze[startRow - 1, startCol] != "x" && maze[startRow - 1, startCol] != "o")
            {
                check = FindPaths(startRow - 1, startCol, check);
            }

            // right
            if (startCol + 1 < maze.GetLength(1) && maze[startRow, startCol + 1] != "x" && maze[startRow, startCol + 1] != "o")
            {
                check = FindPaths(startRow, startCol + 1, check);
            }

            // down
            if (startRow + 1 < maze.GetLength(0) && maze[startRow + 1, startCol] != "x" && maze[startRow + 1, startCol] != "o")
            {
                check = FindPaths(startRow + 1, startCol, check);
            }

            // left
            if (startCol > 0 && maze[startRow, startCol - 1] != "x" && maze[startRow, startCol - 1] != "o")
            {
                check = FindPaths(startRow, startCol - 1, check);
            }

            // Backtracking
            maze[startRow, startCol] = " ";

            return check;
        }

        private static void PrintMaze(string[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == "o" || maze[i, j] == "e")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (maze[i, j] == "x")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(maze[i, j].ToString().PadLeft(2, ' '));
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void FindStartingCell(Cell<int> startCell, string[,] maze)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (maze[row, col] == "*")
                    {
                        startCell.Row = row;
                        startCell.Col = col;
                    }

                }
            }
        }
    }
}
