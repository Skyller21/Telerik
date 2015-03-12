using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CalculateSquareRootOfNumber
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter a number");
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            double sqrtNumber = Math.Sqrt(number);
            Console.WriteLine("The square root of the number is: {0}",sqrtNumber);
        }

        catch (FormatException)
        {
            Console.WriteLine("Invalid number");

        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid number");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good Bye");
        }
    }
}

