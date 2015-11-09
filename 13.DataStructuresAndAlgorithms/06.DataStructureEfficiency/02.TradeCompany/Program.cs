namespace _02.TradeCompany
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Wintellect.PowerCollections;

    class Program
    {
        private static readonly int ArticlesCount = 1000000;
        private static readonly decimal MinPrice = 39.99m;
        private static readonly decimal MaxPrice = 59.99m;

        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.Write("Generating articles");
            var articles = ArticlesGenerator();
            Console.WriteLine($"\nTime for generating articles: {stopwatch.Elapsed}");

            stopwatch.Restart();
            var dict = new OrderedMultiDictionary<decimal, Article>(true);
            GenerateDictionaryWithArticles(articles, dict);
            Console.WriteLine($"\nTime for generating dictionary: {stopwatch.Elapsed}");

            stopwatch.Restart();
            var articlesInPriceRange = dict.Range(MinPrice, true, MaxPrice, true);
            Console.WriteLine($"\nArticles in price range [${MinPrice}, ${MaxPrice}]: {articlesInPriceRange.Count}");
            Console.WriteLine($"Time for searching: {stopwatch.Elapsed}");
        }

        private static void GenerateDictionaryWithArticles(IEnumerable<Article> articles, OrderedMultiDictionary<decimal, Article> dict)
        {
            Console.Write("\nMake the dictionary");
            var count = 0;
            foreach (var article in articles)
            {
                dict.Add(article.Price, article);
                count++;
                if (count % 1000 == 0)
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }

        private static IEnumerable<Article> ArticlesGenerator()
        {
            for (int i = 0; i < ArticlesCount; i++)
            {
                var title = RandomGenerator.GetRandomString(5, 15);
                var vendor = RandomGenerator.GetRandomString(5, 15);
                var barcode = RandomGenerator.GetRandomString(10, 10);
                var price = RandomGenerator.GetRandomFloat(0.99, 99.99);

                yield return new Article()
                {
                    Vendor = vendor,
                    Title = title,
                    Barcode = barcode,
                    Price = (decimal)price,
                };

                if (i % 1000 == 0)
                {
                    Console.Write(".");
                }

            }
        }
    }
}
