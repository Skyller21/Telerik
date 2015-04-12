using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Cube
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int p = n - 1;
            Console.WriteLine(new string(' ',p) +new string(':',n));
            
            for (int i = 0; i < n-2; i++)
            {
                p--;
                Console.WriteLine(new string(' ',p)+":"+new string('/',n-2)+":"+new string('X',i)+":");
            }

            Console.WriteLine(new string(':',n)+new string('X',n-2)+":");


             
            for (int i = n-3; i >= 0; i--)
            {
                
                Console.WriteLine(":" + new string(' ', n - 2) + ":" + new string('X', i) + ":");
            }

            Console.WriteLine(new string(':',n));
        }
    }
}
