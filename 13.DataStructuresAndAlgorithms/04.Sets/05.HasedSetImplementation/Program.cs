using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HasedSetImplementation
{
    using HashSetImplementation;

    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashedSet<int>();

            for (int i = 0; i < 50; i+=2)
            {
                set.Add(i);
            }

            foreach (var i in set)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Count is: {0}",set.Count);
        }
    }
}
