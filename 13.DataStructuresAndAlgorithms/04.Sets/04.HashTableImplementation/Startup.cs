namespace _04.HashTableImplementation
{
    using System;
    using System.Text;

    class Startup
    {
        static void Main(string[] args)
        {
            var table = new HashTable<int, string>();

            var rand = new Random();

            for (int i = 0; i < 150; i++)
            {
                var randString = new StringBuilder();

                for (int j = 0; j < rand.Next(5, 16); j++)
                {
                    randString.Append((char)(rand.Next(65, 91)));
                }
                table.Add(i*table.Count + table.Count, randString.ToString());
            }

            System.Console.WriteLine(table);
            System.Console.WriteLine(table.Count);
        }
    }
}
