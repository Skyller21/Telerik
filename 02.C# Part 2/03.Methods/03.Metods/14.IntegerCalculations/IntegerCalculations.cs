using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.IntegerCalculations
{
    class IntegerCalculations
    {
        static void Main()
        {
            Console.WriteLine("Enter elements. Each at new line. When you are finished press ENTER:");
            List<double> listToCalc = InitializeNumbers();


            Console.WriteLine("Average = {0}", CalculateAverage(listToCalc));

            Console.WriteLine("Minimum = {0}", CalculateMinimum(listToCalc));

            Console.WriteLine("Maximum = {0}", CalculateMaximum(listToCalc));

            Console.WriteLine("Sum = {0}", CalculateSum(listToCalc));

            Console.WriteLine("Product = {0}", CalculateProduct(listToCalc));


        }


        static List<double> InitializeNumbers()
        {
            bool check;
            double average;
            List<double> listAverage = new List<double>();

            do
            {
                check = double.TryParse(Console.ReadLine(), out average);
                listAverage.Add(average);
            }
            while (check);
            listAverage.RemoveAt(listAverage.Count - 1);
            return listAverage;

        }
        static double CalculateAverage(List<double> listAverage)
        {
            double average;
            average = listAverage.Average();
            return average;

        }

        static double CalculateMinimum(List<double> listMinimum)
        {
            double minimum;
            minimum = listMinimum.Min();
            return minimum;
        }

        static double CalculateMaximum(List<double> listMaximum)
        {
            double maximum;
            maximum = listMaximum.Max();
            return maximum;
        }

        static double CalculateProduct(List<double> listMinimum)
        {
            double product = 1;
            foreach (var element in listMinimum)
            {
                product *= element;
            }
            return product;
        }

        static double CalculateSum(List<double> listMinimum)
        {
            double sum = 0;
            foreach (var element in listMinimum)
            {
                sum += element;
            }
            return sum;
        }
    }
}
