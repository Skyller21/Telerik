using System;
using System.Collections.Generic;

namespace _10.Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            const int start = 5;
            const int end = 16;

            var set = ShortestSequenceOfOperations(end, start);

            Console.WriteLine(string.Join(", ", set));
        }

        private static SortedSet<int> ShortestSequenceOfOperations(int end, int start)
        {
            var set = new SortedSet<int>();
            set.Add(start);
            set.Add(end);

            while (end > start)
            {
                if ((end / 2 >= start) && (end % 2 == 0))
                {
                    end = end / 2;
                    set.Add(end);


                }

                else if ((end / 2 >= start) && (end % 2 == 1))
                {
                    end--;
                    set.Add(end);

                    end = end / 2;
                    set.Add(end);
                }

                else if (end - 2 >= start)
                {
                    end -= 2;
                    set.Add(end);
                }
                else
                {
                    end--;
                    set.Add(end);
                }
            }

            return set;
        }
    }
}
