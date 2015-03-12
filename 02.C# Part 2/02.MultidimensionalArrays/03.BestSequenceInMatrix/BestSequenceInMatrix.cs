using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BestSequenceInMatrix
{
    class BestSequenceInMatrix
    {

        static int maxCounter;
        static string bestString;
        static string wayFound;
        static void Main(string[] args)
        {
            string[,] matrix = 
            {
              {"ha","ha","ha","ho","xxx","he"},
              {"fo","ha","ha","xxx","he","he"},
              {"xxx","ho","xxx","xx","he","he"},
              {"xxx","xxx","xx","ha","he","he"},
              {"xxx","ho","ha","xx","ha","ho"},
            };

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bestString = String.Empty;
            maxCounter = int.MinValue;
            wayFound = string.Empty;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    CheckMatrix(matrix, row, col);
                }
            }
            Console.WriteLine("THE FOUND WAY OF THE STRING IS:");
            Console.WriteLine(wayFound);
            Console.WriteLine("\nTHE SEQUENCE IS:");
            for (int i = 0; i < maxCounter; i++)
            {
                Console.WriteLine(bestString);
            }

            
        }

        static void CheckMatrix(string[,] matrix, int startRow, int startCol)
        {
            string searchedString = matrix[startRow, startCol];
            int counter = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int currentRow = startRow;
            int currentCol = startCol;

            //Move Down
            string wayTemp = "Vertical";
            while (currentRow < rows && searchedString == matrix[currentRow, currentCol])
            {
                counter++;
                currentRow++;
            }

            FindMax(searchedString, counter,wayTemp);

            //Move Right
            wayTemp = "Horizontal";
            currentRow = startRow;
            currentCol = startCol;
            searchedString = matrix[startRow, startCol];
            counter = 0;
            while (currentCol < cols && searchedString == matrix[currentRow, currentCol])
            {
                counter++;
                currentCol++;
            }

            FindMax(searchedString, counter,wayTemp);

            //Move Diagonal Down
            wayTemp = "Diagonal top left to bottom right";
            currentRow = startRow;
            currentCol = startCol;
            searchedString = matrix[startRow, startCol];
            counter = 0;
            while ((currentRow < rows && currentCol  < cols) && searchedString == matrix[currentRow, currentCol])
            {
                counter++;
                currentRow++;
                currentCol++;
            }

            FindMax(searchedString, counter,wayTemp);

            //Move Diagonal Up
            wayTemp = "Diagonal bottom left to top right";
            currentRow = startRow;
            currentCol = startCol;
            searchedString = matrix[startRow, startCol];
            counter = 0;
            while ((currentRow >=0 && currentCol <rows) && searchedString == matrix[currentRow, currentCol])
            {
                counter++;
                currentRow--;
                currentCol++;
            }

            FindMax(searchedString, counter,wayTemp);

        }

        static void FindMax(string currentString, int counter, string wayTemp)
        {
            if (counter > maxCounter)
            {
                maxCounter = counter;
                bestString = currentString;
                wayFound = wayTemp;

            }
        }

        
    }
}
