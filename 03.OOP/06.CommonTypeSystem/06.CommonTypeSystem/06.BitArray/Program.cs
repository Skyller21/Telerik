using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BitArray
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong num = 801123;
            Console.WriteLine(num);
            var arr = new BitArray(801123);
            Console.WriteLine(arr);
            Console.WriteLine(arr[5]);
            arr[5] = 0;
            Console.WriteLine(arr[5]);
            Console.WriteLine(BitArray.ToNumber(arr));
        }
    }
}
