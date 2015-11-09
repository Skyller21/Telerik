using Wintellect.PowerCollections;

namespace _02.FindInCollection
{
    using PetStore.Importer;
    using System;
    using System.Diagnostics;

    class Program
    {
        // Try it with larger values but don't put 50 000 000. Adding is slow :). Search is very very fast always :)
        private const int ProductsCount = 500000;
        private const int ProductsToFindInRange = 10000;

        static void Main(string[] args)
        {
            // Seems legit :D
            var bagOfProducts = new OrderedBag<Product>();

            Console.Write("Adding products");
            for (int i = 0; i < ProductsCount; i++)
            {
                var price = Math.Round(RandomGenerator.GetRandomFloat(0, 100), 2);

                if (i % (ProductsCount / ProductsToFindInRange) == 0)
                {
                    // Ensure to add around needed products in that range. Only for testing. Unit test are bad :DDDDD
                    price = Math.Round(RandomGenerator.GetRandomFloat(200, 250), 2);
                }

                bagOfProducts.Add(new Product(RandomGenerator.GetRandomString(5, 15), price));

                if (i % 10000 == 0)
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine("\nFinding products\n=================");
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var productsInRange = bagOfProducts.Range(new Product("", 200), true, new Product("", 250), true);

            var timeNeeded = stopwatch.Elapsed;
            Console.WriteLine("Time need for finding: {0:F2} ms ", timeNeeded.Milliseconds);
            Console.WriteLine("Found products count: {0}", productsInRange.Count);

            // Print the found products
            //foreach (var product in productsInRange)
            //{
            //    Console.WriteLine("{0}: ${1}", product.Name, product.Price);
            //}
        }
    }
}
