using System;

namespace _03.MultiKeyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new BiDictionary<int, int, string>();

            Console.WriteLine(dict.Add(1, 2, "Pesho"));
            Console.WriteLine(dict.Add(1, 3, "Gosho"));
            Console.WriteLine(dict.Add(1, 1, "Ivan"));
            Console.WriteLine(dict.Add(1, 1, "Proba za smiana na Ivan"));
            Console.WriteLine(dict.Add(1, 2, "Proba za smiana na Pesho"));

            Console.WriteLine("====================");
            foreach (var item in dict)
            {
                foreach (var innerItem in item.Value)
                {
                    Console.WriteLine(dict[item.Key][innerItem.Key]);
                }
            }
        }
    }
}
