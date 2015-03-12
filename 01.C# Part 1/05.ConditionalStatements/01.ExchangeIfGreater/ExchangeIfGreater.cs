using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ExchangeIfGreater
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input first integer to compare:");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.WriteLine("Input second integer to compare:");
        double secondNumber = double.Parse(Console.ReadLine());

        double tempNumber;

        if (firstNumber <= secondNumber)
        {
            Console.WriteLine("\nRESULT");
            Console.WriteLine(firstNumber + " " + secondNumber);
        }
        else
        {
            tempNumber = secondNumber;
            secondNumber = firstNumber;
            firstNumber = tempNumber;
            Console.WriteLine("\nRESULT");
            Console.WriteLine(firstNumber + " " + secondNumber);
        }
    }
}
