namespace Methods
{
    using System;
    using System.Linq;

    public class Methods
    {
       public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(DigitToText(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            FormatNumber(1.3, FormatOption.FloatingPoint);
            FormatNumber(0.25, FormatOption.Percent);
            FormatNumber(2.30, FormatOption.AlignRight);

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine(CheckAlignmentOfLine(3, -1, 3, 2.5));

            Student studentOne = new Student()
            {
                FirstName = "Peter",
                LastName = "Ivanov",
                BirthdayDate = new DateTime(1980, 05, 01),
                Town = Town.Burgas,
                OtherInfo = "N/A"
            };

            Student studentTwo = new Student()
            {
                FirstName = "Stella",
                LastName = "Markova",
                BirthdayDate = new DateTime(1993, 11, 03),
                Town = Town.Plovdiv,
                OtherInfo = "N/A"
            };

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                studentOne.FirstName,
                studentTwo.FirstName,
                studentOne.IsOlderThan(studentTwo));
        }

       internal static double CalcTriangleArea(double sideA, double sideB, double sideC)
       {
           if (sideA < 0 || sideB < 0 || sideC < 0)
           {
               throw new ArgumentOutOfRangeException("The sides of the triangle must be positive.");
           }

           double semiPerimeter = (sideA + sideB + sideC) / 2;
           double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
           return area;
       }

       internal static string DigitToText(int digit)
       {
           switch (digit)
           {
               case 0: return "zero";
               case 1: return "one";
               case 2: return "two";
               case 3: return "three";
               case 4: return "four";
               case 5: return "five";
               case 6: return "six";
               case 7: return "seven";
               case 8: return "eight";
               case 9: return "nine";
               default: throw new ArgumentOutOfRangeException("The supplied data is not a digit. Please input a digit [0-9]");
           }
       }

       internal static int FindMax(params int[] elements)
       {
           if (elements == null || elements.Length == 0)
           {
               throw new ArgumentNullException("There are no elements supplied to find the maximum value.");
           }

           var maxElement = elements.Max();

           return maxElement;
       }

       internal static void FormatNumber(double number, FormatOption formatOption)
       {
           switch (formatOption)
           {
               case FormatOption.FloatingPoint:
                   Console.WriteLine("{0:F2}", number);
                   break;
               case FormatOption.Percent:
                   if (number < 0)
                   {
                       throw new ArgumentOutOfRangeException("The number must be greater or equal to 0 to convert to %.");
                   }

                   Console.WriteLine("{0:P0}", number);
                   break;
               case FormatOption.AlignRight:
                   Console.WriteLine("{0,8}", number);
                   break;
               default: throw new ArgumentException("Invalid formatting option");
           }
       }

       internal static double CalcDistance(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
       {
           double distance = Math.Sqrt((secondPointX - firstPointX) * (secondPointX - firstPointX) + (secondPointY - firstPointY) * (secondPointY - firstPointY));
           return distance;
       }

       internal static string CheckAlignmentOfLine(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
       {
           if (firstPointX.Equals(secondPointX) && firstPointY.Equals(secondPointY))
           {
               throw new ArgumentNullException("The points are on the same position. Hence there is no line.");
           }

           if (firstPointX.Equals(secondPointX))
           {
               return "The line is vertical";
           }
           else if (firstPointY.Equals(secondPointY))
           {
               return "The line is horizontal";
           }
           else
           {
               return "The line is tilted at a degree different than 0 and 90";
           }
       }
    }
}
