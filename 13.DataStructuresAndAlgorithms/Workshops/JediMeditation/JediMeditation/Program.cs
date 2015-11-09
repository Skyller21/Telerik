namespace JediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {

            //string input = @"7
            //p4 p2 p3 m1 k2 p1 k1";

            //var reader = new StringReader(input);

            //Console.SetIn(reader);

            var count = int.Parse(Console.ReadLine());

            var jedi = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var masters = new Queue<string>();
            var knights = new Queue<string>();
            var padawans = new Queue<string>();


            foreach (var j in jedi)
            {
                if (j[0] == 'm')
                {
                    masters.Enqueue(j);
                }
                else if (j[0] == 'k')
                {
                    knights.Enqueue(j);
                }
                else if (j[0] == 'p')
                {
                    padawans.Enqueue(j);
                }
            }

            var str = new StringBuilder();

            foreach (var master in masters)
            {
                str.Append(master);
                str.Append(" ");
            }

            foreach (var knight in knights)
            {
                str.Append(knight);
                str.Append(" ");
            }

            foreach (var padawan in padawans)
            {
                str.Append(padawan);
                str.Append(" ");
            }

            Console.WriteLine(str);
        }
    }
}