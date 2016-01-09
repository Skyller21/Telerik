using System;
using System.Linq;

namespace Portals
{
    class Program
    {
        private static Cell[,] maze;
        private static Cell startCell;
        private static int sum;
        private static int maxSum = int.MinValue;

        static void Main(string[] args)
        {
            ProcessInput();

            sum = 0;
            maxSum = 0;

            maze[startCell.Y, startCell.X].IsVisited = true;

            BFS(startCell);

            Console.WriteLine(maxSum);

        }

        private static void BFS(Cell cell)
        {
            //if (cell.IsVisited)
            //{
            //    return;
            //}
            if (cell.IsInactive)
            {
                return;
            }

            if (sum > maxSum)
            {
                maxSum = sum;
            }

            if (cell.IsInactive)
            {

                var right = cell.X + cell.Value;
                if (right < maze.GetLength(1) && !maze[cell.Y, right].IsVisited && maze[cell.Y, right].Value != -1)
                {
                    Console.WriteLine(cell.Value);

                    sum += cell.Value;
                    maze[cell.Y, right].IsVisited = true;
                    cell.IsInactive = true;

                    BFS(maze[cell.Y, right]);
                    maze[cell.Y, right].IsVisited = false;
                }

                var left = cell.X - cell.Value;
                if (left >= 0 && !maze[cell.Y, left].IsVisited && maze[cell.Y, left].Value != -1)
                {
                    Console.WriteLine(cell.Value);

                    sum += cell.Value;
                    maze[cell.Y, left].IsVisited = true;
                    cell.IsInactive = true;

                    BFS(maze[cell.Y, left]);
                    maze[cell.Y, left].IsVisited = false;

                }

                var up = cell.Y - cell.Value;
                if (up >= 0 && !maze[up, cell.X].IsVisited && maze[up, cell.X].Value != -1)
                {
                    Console.WriteLine(cell.Value);

                    sum += cell.Value;
                    maze[up, cell.X].IsVisited = true;
                    cell.IsInactive = true;

                    BFS(maze[up, cell.X]);
                    maze[up, cell.X].IsVisited = false;

                }

                var down = cell.Y + cell.Value;
                if (down < maze.GetLength(0) && !maze[down, cell.X].IsVisited && maze[down, cell.X].Value != -1)
                {
                    Console.WriteLine(cell.Value);

                    sum += cell.Value;
                    maze[down, cell.X].IsVisited = true;
                    cell.IsInactive = true;

                    BFS(maze[down, cell.X]);
                    maze[down, cell.X].IsVisited = false;
                }
            }


            cell.IsInactive = true;
            

        }

        private static void PrintMaze()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j].IsVisited + "    ");
                }
                Console.WriteLine();
            }
        }

        private static void ProcessInput()
        {
            var startData =
                Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var dimensionData = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensionData[0];
            var cols = dimensionData[1];

            maze = new Cell[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < line.Length; j++)
                {
                    var value = 0;
                    if (line[j] == "#")
                    {
                        value = -1;
                    }
                    else
                    {
                        value = int.Parse(line[j]);
                    }
                    var cell = new Cell(i, j, value);

                    maze[i, j] = cell;
                }
            }

            startCell = new Cell(startData[0], startData[1], maze[startData[0], startData[1]].Value);
        }
    }

    class Cell
    {
        public Cell(int y, int x, int value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
            this.IsVisited = false;
            this.IsInactive = false;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public bool IsVisited { get; set; }

        public bool IsInactive { get; set; }

        public int Value { get; set; }

    }
}
