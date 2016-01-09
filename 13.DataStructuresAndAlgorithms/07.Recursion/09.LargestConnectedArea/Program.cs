namespace _09.LargestConnectedArea
{
    using System;

    class Program
    {
        private static string[,] maze;
        private static int counter = 0;

        static void Main(string[] args)
        {
            maze = new string[,]
            {
                {"x", " ", " ", "x", " ", " "},
                {" ", "x", "x", " ", "x", " "},
                {" ", " ", "x", " ", "x", " "},
                {" ", "x", " ", " ", " ", " "},
                {" ", "x", " ", "x", "x", " "},
                {" ", " ", " ", "x", " ", "x"},
            };

            var maxConnected = new string[maze.GetLength(0), maze.GetLength(1)];

            var currentMax = 0;

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    counter = 0;

                    FindPaths(i, j);
                    if (counter >= currentMax)
                    {
                        currentMax = counter;
                        maxConnected = (string[,])maze.Clone();
                    }
                    ResetMaze(maze);
                }
            }

            Console.WriteLine($"Max area = {currentMax}\n============");

            PrintMaze(maxConnected);
        }

        private static void FindPaths(int startRow, int startCol)
        {
            if (startRow < 0 || startCol < 0 ||
                startRow >= maze.GetLength(0) || startCol >= maze.GetLength(1))
            {
                return;
            }

            if (maze[startRow, startCol] == "x" || maze[startRow, startCol] == "o")
            {
                return;
            }

            counter++;

            // Make the cell already unpassable
            maze[startRow, startCol] = "o";

            // up
            FindPaths(startRow - 1, startCol);

            // right
            FindPaths(startRow, startCol + 1);

            // down
            FindPaths(startRow + 1, startCol);

            // left
            FindPaths(startRow, startCol - 1);
        }

        private static void PrintMaze(string[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == "o")
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

        private static void ResetMaze(string[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == "o")
                    {
                        maze[i, j] = " ";
                    }
                }
            }
        }

    }
}
