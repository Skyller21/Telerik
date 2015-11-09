using System.Collections.Generic;

namespace _14.Labyrinth
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string[,] labyrinth =
            {
                {"0", "0", "0", "x", "0", "x"},
                {"0", "x", "0", "x", "0", "x"},
                {"0", "*", "x", "0", "x", "0"},
                {"0", "x", "0", "0", "0", "0"},
                {"0", "0", "0", "x", "x", "0"},
                {"0", "0", "0", "x", "0", "x"},
            };

            int[,] values =
            {
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},

            };

            var startCell = new Cell<int>(-1, -1);
            var used = new HashSet<Cell<int>>();

            ProcessInitialLabyrinth(startCell, labyrinth, used);

            try
            {
                BFS(startCell, values, used);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("There is no start position '*' provided in the labyrinth");
            }

            PrintFinalLabyrinth(startCell, values, labyrinth);
        }

        private static void ProcessInitialLabyrinth(Cell<int> startCell, string[,] labyrinth, HashSet<Cell<int>> used)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "*")
                    {
                        startCell.Row = row;
                        startCell.Col = col;
                        used.Add(startCell);
                    }
                    if (labyrinth[row, col] == "x")
                    {
                        used.Add(new Cell<int>(row, col));
                    }
                }
            }
        }

        private static void BFS(Cell<int> startCell, int[,] numbers, HashSet<Cell<int>> used)
        {
            var queue = new Queue<Cell<int>>();

            queue.Enqueue(startCell);
            used.Add(startCell);

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();

                // left -> col--
                if (cell.Col > 0)
                {
                    var newCell = new Cell<int>(cell.Row, cell.Col - 1);
                    if (!used.Contains(newCell))
                    {
                        numbers[newCell.Row, newCell.Col] = numbers[cell.Row, cell.Col] + 1;
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // right -> col++
                if (cell.Col < numbers.GetLength(1) - 1)
                {
                    var newCell = new Cell<int>(cell.Row, cell.Col + 1);
                    if (!used.Contains(newCell))
                    {
                        numbers[newCell.Row, newCell.Col] = numbers[cell.Row, cell.Col] + 1;
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // up -> row--
                if (cell.Row > 0)
                {
                    var newCell = new Cell<int>(cell.Row - 1, cell.Col);
                    if (!used.Contains(newCell))
                    {
                        numbers[newCell.Row, newCell.Col] = numbers[cell.Row, cell.Col] + 1;
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // down -> row++
                if (cell.Row < numbers.GetLength(0) - 1)
                {
                    var newCell = new Cell<int>(cell.Row + 1, cell.Col);
                    if (!used.Contains(newCell))
                    {
                        numbers[newCell.Row, newCell.Col] = numbers[cell.Row, cell.Col] + 1;
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }
            }
        }

        private static void PrintFinalLabyrinth(Cell<int> startCell, int[,] numbers, string[,] labyrinth)
        {
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if (i == startCell.Row && j == startCell.Col || labyrinth[i, j] == "x")
                    {
                    }
                    else if (numbers[i, j] == 0)
                    {
                        labyrinth[i, j] = "u";
                    }
                    else
                    {
                        labyrinth[i, j] = numbers[i, j].ToString();
                    }

                    Console.Write(labyrinth[i, j].ToString().PadLeft(2, ' ') + "  ");
                }

                Console.WriteLine();
            }
        }
    }
}
