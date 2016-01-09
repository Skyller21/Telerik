namespace Euler
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        private static int n = 8;
        private static int sum = 0;
        /* Матрица на съседство на графа */

        private static int[,] A;
        //static int[,] A = {
        //    { 0, 1, 0, 0, 0, 0, 0, 1 },
        //    { 1, 0, 1, 1, 1, 0, 0, 0 },
        //    { 0, 1, 0, 1, 0, 1, 1, 0 },
        //    { 0, 1, 1, 0, 0, 0, 0, 0 },
        //    { 0, 1, 0, 0, 0, 1, 0, 0 },
        //    { 0, 0, 1, 0, 1, 0, 0, 0 },
        //    { 0, 0, 1, 0, 0, 0, 0, 1 },
        //    { 1, 0, 0, 0, 0, 0, 1, 0 } };


        static void Main()
        {

            string path = @"10
2
1 2 3
1 8 3
2 5 3
2 3 3
2 4 3
3 4 3
3 6 3
3 7 3
5 6 3
7 8 3";


            StringReader read = new StringReader(path);

            Console.SetIn(read);

            var players = int.Parse(Console.ReadLine());

            A = new int[players, players];

            var startPlayer = int.Parse(Console.ReadLine());


            for (int i = 0; i < 10; i++)
            {
                var vertex = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                A[vertex[0] - 1, vertex[1] - 1] = vertex[2];
                A[vertex[1] - 1, vertex[0] - 1] = vertex[2];
            }




            for (int i = 0; i < players; i++)
            {
                for (int j = 0; j < players; j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }

            if (IsEulerGraph())
            {
                FindEuler(0);
            }
            else
            {
                Console.WriteLine("Графът не е Ойлеров!");
            }
        }

        static bool IsEulerGraph()
        {
            for (int i = 0; i < n; i++)
            {
                int din = 0;
                int dout = 0;

                for (int j = 0; j < n; j++)
                {
                    if (A[i, j] != 0) din++;
                    if (A[j, i] != 0) dout++;
                }
                if (din != dout || din % 2 != 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void FindEuler(int i)
        {
            Stack<int> cStack = new Stack<int>();
            Stack<int> stack = new Stack<int>();

            stack.Push(i);
            while (stack.Count > 0)
            {
                int j;
                i = stack.Peek();
                for (j = 0; j < n; j++)
                {
                    if (A[i, j] != 0)
                    {
                        sum += A[i, j];
                        A[i, j] = 0;
                        A[j, i] = 0;

                        break;
                    }
                }
                if (j < n)
                {
                    stack.Push(j);

                }
                else
                {
                    cStack.Push(stack.Pop());
                }
            }
            Console.Write("Ойлеровият цикъл е: ");
            for (int k = cStack.Count; k > 0; k--)
            {
                Console.Write("{0} ", cStack.Pop() + 1);

            }
            Console.WriteLine(sum);
            Console.WriteLine();
        }
    }
}
