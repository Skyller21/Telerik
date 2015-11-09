using System;
using System.Collections.Generic;

namespace _02.OddNumberOfTimes
{
    class Startup
    {
        static void Main(string[] args)
        {
            string[] arr = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            HashSet<string> oddSet = new HashSet<string>();
            HashSet<string> evenSet = new HashSet<string>();

            foreach (var item in arr)
            {
                if (oddSet.Add(item))
                {
                    evenSet.Remove(item);
                }
                else
                {
                    oddSet.Remove(item);
                    evenSet.Add(item);
                }
            }

            Console.WriteLine(string.Join(", ", oddSet));
        }
    }
}
