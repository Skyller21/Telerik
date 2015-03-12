using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ModifiedExercise14
{
    static void Main()
    {
        double[] newArray = { -1, 3, 1, 2, 14.3, 7, 30, -3.1 }; //Modify the array type and change the type of the elements if you want to check.
        Console.WriteLine("The array is:");
        foreach (var element in newArray)
        {
            Console.Write("{0}; ", element);
        }
        Console.WriteLine("\n\rThe results are.");
        CalculateMin(newArray);
        CalculateMax(newArray);
        CalculateAverage(newArray);
        CalculateSum(newArray);
        CalculateProduct(newArray);

    }
    static void CalculateMin<T>(T[] newArray)
    {
        dynamic minNum = newArray[0];
        for (int i = 0; i < newArray.Length; i++)
        {
            if (newArray[i] <= minNum)
            {
                minNum = newArray[i];
            }
        }

        Console.WriteLine("The minimum value of the given array is: {0}", minNum);
    }

    static void CalculateMax<T>(T[] newArray)
    {
        dynamic maxNum = newArray[0];
        for (int i = 0; i < newArray.Length; i++)
        {

            if (newArray[i] >= maxNum)
            {
                maxNum = newArray[i];
            }
        }

        Console.WriteLine("The maximum value of the given array is: {0}", maxNum);
    }


    static void CalculateAverage<T>(T[] newArray)
    {
        dynamic averageSum = 0;

        for (int i = 0; i < newArray.Length; i++)
        {
            averageSum += newArray[i];
        }
        averageSum = (double)averageSum / newArray.Length;
        Console.WriteLine("The average value of the given array is: {0}", averageSum);
    }

    static void CalculateSum<T>(T[] newArray)
    {
        dynamic sum = 0;

        for (int i = 0; i < newArray.Length; i++)
        {
            sum += newArray[i];
        }

        Console.WriteLine("The sum of the given array is: {0}", sum);
    }

    static void CalculateProduct<T>(T[] newArray)
    {
        dynamic productRes = 1;
        for (int i = 0; i < newArray.Length; i++)
        {
            productRes = productRes * newArray[i];
        }

        Console.WriteLine("The product of the numbers given as array is: {0}", productRes);
    }

}

