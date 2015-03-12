using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.EnglishDigit
{
    class EnglishDigit
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input an integer");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-',40));
            Console.WriteLine("The last digit of the number {0} is: {1}",num,PrintLastDigit(num));

        }

        static string PrintLastDigit(int num)
        {
            int lastDigit = num % 10;

            switch (lastDigit)
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
                default: return null;
                    
            }
        }
    }
}
