using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberToSquare = -20;
            double seconds = 0.1;
            
            Action<int> action = SquareNum;
            Timer timer = new Timer(action, numberToSquare, seconds);
            
            timer.SquareNum();
        }

        public static void SquareNum(int number)
        {
            Console.WriteLine("{0}^2 = {1}",number,number*number);
        }
    }
}
