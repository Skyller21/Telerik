namespace Passwords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Passwords
    {

        private static List<char> data;
        private static int n;
        private static int[] numbers = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        private static SortedSet<string> passes;
        private static int k;
        private static StringBuilder str;



        public static void Main()
        {

            passes = new SortedSet<string>();

            str = new StringBuilder();

            n = int.Parse(Console.ReadLine());

            data = new List<char>();

            data.Add('=');
            data.AddRange(Console.ReadLine().ToCharArray().ToList());



            k = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Count(); i++)
            {
                FindCombo(i, 0, 0);
                str.Clear();
            }

            Console.WriteLine(passes.ToArray()[k - 1]);
        }

        private static void FindCombo(int start, int level, int dataIndex)
        {
            if (level == n)
            {
                if (str.Length == n)
                {
                    passes.Add(str.ToString());
                }
                return;
            }

            if (data[dataIndex] == '=')
            {
                str.Append(start);
                FindCombo(start, level + 1, dataIndex + 1);
                str.Remove(str.Length - 1, 1);

            }

            if (data[dataIndex] == '>')
            {
                var el = numbers.ToList().IndexOf(start);

                for (int i = el + 1; i < numbers.Length; i++)
                {
                    str.Append(numbers[i]);
                    FindCombo(numbers[i], level + 1, dataIndex + 1);
                    str.Remove(str.Length - 1, 1);
                }
            }

            if (data[dataIndex] == '<')
            {
                var el = numbers.ToList().IndexOf(start);

                for (int i = el - 1; i >= 0; i--)
                {
                    str.Append(numbers[i]);
                    FindCombo(numbers[i], level + 1, dataIndex + 1);
                    str.Remove(str.Length - 1, 1);
                }
            }

            return;

        }
    }



}