using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.SolveTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class SolveTasks
    {
        static string number;
        static string option;


        static void Main()
        {
            Console.WriteLine("WELCOME USER!\n\n1.Reverse a number.\n2.Average of sequence of integers.\n3.Calculate equation a*x+b=0.\n\nChoose an option:");
            option = Console.ReadLine();
            if (option == "1")
            {
                Console.WriteLine("Your choice is 1. Press ENTER to confirm or ESC to return to main menu.");
                if (ReturnToMain())
                {
                    Main();
                }
                else
                {
                    Console.WriteLine("Enter number to be reversed:");
                    number = Console.ReadLine();
                    Console.WriteLine("The reversed number is: {0}", ReverseNumber(number));
                    Console.WriteLine();

                }
            }
            else if (option == "2")
            {
                Console.WriteLine("Your choice is 2. Press ENTER to confirm or ESC to return to main menu.");
                if (ReturnToMain())
                {
                    Main();
                }
                else
                {
                    Console.WriteLine("Enter numbers separated by SPACES to calculate average:");
                    Console.WriteLine("The average result is: {0}", CalculateAverage());
                    Console.WriteLine();

                }
            }
            else if (option == "3")
            {
                Console.WriteLine("Your choice is 3. Press ENTER to confirm or ESC to return to main menu.");
                if (ReturnToMain())
                {
                    Main();
                }
                else
                {
                    Console.WriteLine("x = -b/a = {0}", SolveEquation());
                }
            }
            else
            {
                Console.WriteLine("Your input is invalid!!!");
                Main();
            }
            Console.WriteLine();
            Main();

        }

        static StringBuilder ReverseNumber(string number)
        {
            if (Convert.ToInt32(number) < 0)
            {
                Console.WriteLine("Invalid input!!!");
                Main();
            }
            string[] newArray = new string[number.Length];
            StringBuilder reversed = new StringBuilder();
            for (int j = 0; j < number.Length; j++)
            {
                newArray[j] = number.Substring(j, 1);
            }
            Array.Reverse(newArray);
            for (int i = 0; i < newArray.Length; i++)
            {
                reversed.Append(newArray[i]);
            }
            return reversed;
        }

        static bool ReturnToMain()
        {
            bool returnMain = false;
            ConsoleKeyInfo press = Console.ReadKey();
            if (press.Key == ConsoleKey.Escape)
            {
                returnMain = true;
            }
            return returnMain;
        }

        static double CalculateAverage()
        {

            string sequence = Console.ReadLine();

            string[] arrayString = sequence.Split(' ');
            if (arrayString.Length == 0)
            {
                Console.WriteLine("Invalid input!!!");
                Main();
            }
            double[] arrayNums = new double[arrayString.Length];

            for (int i = 0; i < arrayString.Length; i++)
            {
                arrayNums[i] = double.Parse(arrayString[i]);
            }
            double average = arrayNums.Sum() / arrayNums.Length;
            return average;
        }

        static double SolveEquation()
        {
            double a;
            double b;
            bool check;
            bool checkSign;
            do
            {
                Console.WriteLine("Enter coefficient 'a' not to be 0:");
                check = double.TryParse(Console.ReadLine(), out a);
                if (a == 0 || check == false)
                {
                    checkSign = true;
                }
                else { checkSign = false; }

            } while (checkSign);

            do
            {
                Console.WriteLine("Enter coefficient 'b':");
                check = double.TryParse(Console.ReadLine(), out b);

            } while (!check);

            double x = -b / a;

            return x;
        }
    }


}
