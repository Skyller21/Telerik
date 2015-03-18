using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division
{
    class DivisionProgram
    {
        static void Main(string[] args)
        {
            IEnumerable<int> list = Enumerable.Range(1, 1000);
            IEnumerable<int> listLambda = list.Where(x => x % 21 == 0);

            IEnumerable<int> listLINQ =
                from num in list
                where num % 21 == 0
                select num;
            //Lambda print
            Console.WriteLine("Lambda executed list\n{0}",String.Join(",", listLambda));

            //LINQ print
            Console.WriteLine("\nLINQ executed list\n{0}",String.Join(",", listLambda));
        }
    }
}
