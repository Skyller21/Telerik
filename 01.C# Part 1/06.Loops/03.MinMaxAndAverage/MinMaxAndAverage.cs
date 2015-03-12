using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MinMaxAndAverage
{
    static void Main()
    {
        Console.WriteLine("Enter list length");
        int numbersCount = int.Parse(Console.ReadLine());

        List<int> myList = new List<int>();

        Console.WriteLine("\nEnter the numbers in the list");           
        for (int i = 0; i < numbersCount; i++)                       //Fill the list with elements
        {
            myList.Add(int.Parse(Console.ReadLine()));
        }

        Console.WriteLine("\n--------------");                      //Invoke the methods and pass them parameters to work with
        FindMax(myList);
        FindMin(myList);
        FindAverage(myList);

    }

    static void FindMax(List<int> list)                             //Method for finding max value
    {
        int max = list[0];
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i]>max)
            {
                max = list[i];
            }
        }
        Console.WriteLine("Maximum number is: {0}",max);
    }

    static void FindMin(List<int> list)                             //Method for finding min value
    {
        int min = list[0];
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] < min)
            {
                min = list[i];
            }
        }
        Console.WriteLine("Minimum number is: {0}", min);
    }

    static void FindAverage(List<int> list)                         //Method for finding average value
    {
        double average;
        double sum = 0;
        for (int i = 0; i < list.Count; i++)
        {
            sum = sum + list[i];
        }
        average = sum / list.Count;

        Console.WriteLine("Average number is: {0:F2}", average);
    }
}

