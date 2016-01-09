using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path
{
    class Program
    {
        static int n;
        static int m;
        static void Main(string[] args)
        {

        }

        class Startup()
        {
            
        }

        static void ReadInput()
        {
            int[] mn = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            m = mn[0];
            n = mn[1];
        }

        static void Solve()
        {

            int fromToM1 = Dijkstra(s, m1, m2, e);
            int fromToM2;

            int m1M2;

            int m1ToTo;
            int m2ToTo;

                int min = Math.Min()

        }
    }
}
