using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReadNumberMethod
{
    static List<int> listNum;

    static void Main()
    {
        Console.WriteLine("Enter lower boundary for the numbers to be inputed");
        int start = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter upper boundary for numbers to be inputed");
        int end = int.Parse(Console.ReadLine());
        Console.WriteLine();
        ReadNumber(start, end);
        Console.WriteLine();

    }

    static void ReadNumber(int start, int end)
    {
        try
        {
            listNum = new List<int>();
            listNum.Add(start);
            Console.WriteLine("Enter 10 numbers.\n\rEvery number should be bigger than the last inputed number.");

            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine("Enter number {0} ", i);
                listNum.Add(int.Parse(Console.ReadLine()));
                if (listNum[i] < start || listNum[i] > end)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (listNum[i] < listNum[i - 1])
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            Console.Write("The sequence you have entered is: ");
            PrintSequence(listNum);
        }

        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number");
        }
        catch (ArgumentOutOfRangeException aore)
        {
            Console.WriteLine(aore.Message);
            throw aore;
        }

    }

    static void PrintSequence(List<int> list)
    {
        for (int i = 1; i < 11; i++)
        {
            Console.Write("{0} ", list[i]);
        }
    }
}

