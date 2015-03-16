namespace Generics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class GenericsProgram
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();

            Point p1 = new Point();
            Point p2 = new Point();
            GenericList<Point> pList = new GenericList<Point>();
            pList.Add(p1);
            pList.Add(p2);

            Console.WriteLine(pList[1]); 
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);


            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);


            

            list.Add(1);

            list.InsertAt(1, -50);

            list.RemoveAt(list.Count - 1);

            Console.WriteLine(list.ToString());

            Console.WriteLine(list.IndexOf(5));

            Console.WriteLine(pList.ToString());

            Console.WriteLine(list.Max());
            Console.WriteLine(list.Min());
            //Console.WriteLine(pList.Max());
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);



        }
    }
}
