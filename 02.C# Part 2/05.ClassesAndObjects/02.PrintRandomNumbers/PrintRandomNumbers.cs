using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PrintRandomNumbers
{
    static void Main()
    {
        Random generate = new Random();
        for (int i = 1; i < 11; i++)
        {
            int randomNum = generate.Next(100,201);
            Console.WriteLine("Random {0} = {1}",i,randomNum);
        }
    }
}

