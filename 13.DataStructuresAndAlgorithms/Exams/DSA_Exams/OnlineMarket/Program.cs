namespace OnlineMarket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<string, SortedSet<Product>> productByType;
        private static SortedDictionary<double, SortedSet<Product>> productByPrice;


        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            productByType = new Dictionary<string, SortedSet<Product>>();
            productByPrice = new SortedDictionary<double, SortedSet<Product>>();

            while (line != "end")
            {
                var data = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = data[0];

                if (command == "add")
                {
                    Add(data);
                }
                else if (command == "filter")
                {
                    if (data[2] == "type")
                    {
                        IEnumerable<Product> filtered = FilterByType(data[3]);
                        if (filtered != null)
                        {
                            Console.WriteLine("Ok: {0}", string.Join(", ", filtered));
                        }
                        else
                        {
                            Console.WriteLine("Error: Type {0} does not exists", data[3]);

                        }
                    }

                    if (data[2] == "price")
                    {
                        if (data.Length == 5)
                        {

                            if (data[3] == "from")
                            {
                                IEnumerable<Product> fromPrice = FromPrice(double.Parse(data[4]));
                                Console.WriteLine("Ok: {0}", string.Join(", ", fromPrice));

                            }
                            else
                            {
                                IEnumerable<Product> toPrice = ToPrice(double.Parse(data[4]));
                                Console.WriteLine("Ok: {0}", string.Join(", ", toPrice));
                            }
                        }
                        else
                        {
                            IEnumerable<Product> fromToPrice = FromToPrice(double.Parse(data[4]), double.Parse(data[6]));
                            Console.WriteLine("Ok: {0}", string.Join(", ", fromToPrice));
                        }
                    }
                }

                line = Console.ReadLine();
            }
        }

        private static IEnumerable<Product> FromToPrice(double from, double to)
        {
            var pairs = productByPrice.Where(p => p.Key >= from && p.Key <= to);

            var filtered = new SortedSet<Product>();

            foreach (var keyValuePair in pairs)
            {
                foreach (var item in keyValuePair.Value)
                {
                    filtered.Add(item);
                }
            }

            return filtered.Take(10);
        }

        private static IEnumerable<Product> ToPrice(double price)
        {
            var pairs = productByPrice.Where(p => p.Key <= price);

            var filtered = new SortedSet<Product>();

            foreach (var keyValuePair in pairs)
            {
                foreach (var item in keyValuePair.Value)
                {
                    filtered.Add(item);
                }
            }

            return filtered.Take(10);

        }

        private static IEnumerable<Product> FromPrice(double price)
        {
            var pairs = productByPrice.Where(p => p.Key >= price);

            var filtered = new SortedSet<Product>();

            foreach (var keyValuePair in pairs)
            {
                foreach (var item in keyValuePair.Value)
                {
                    filtered.Add(item);
                }
            }

            return filtered.Take(10);
        }

        private static IEnumerable<Product> FilterByType(string type)
        {
            if (productByType.ContainsKey(type))
            {
                return productByType[type].Take(10);
            }

            return null;
        }

        private static void Add(string[] data)
        {
            var name = data[1];
            var price = double.Parse(data[2]);
            var type = data[3];
            var product = new Product(name, price, type);

            if (!productByPrice.ContainsKey(price))
            {
                productByPrice.Add(price, new SortedSet<Product>());
            }





            if (!productByType.ContainsKey(type))
            {
                productByType.Add(type, new SortedSet<Product>());
            }

            if (productByType[type].All(p => p.Name != product.Name))
            {

                productByPrice[price].Add(product);

                productByType[type].Add(product);

                Console.WriteLine("Ok: Product {0} added successfully", product.Name);
            }
            else
            {
                Console.WriteLine("Error: Product {0} already exists", product.Name);

            }
        }
    }

    class Product : IComparable<Product>
    {
        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }

        public int CompareTo(Product other)
        {
            if (this.Price.CompareTo(other.Price) == 0)
            {
                if (this.Name.CompareTo(other.Name) == 0)
                {
                    return this.Type.CompareTo(other.Type);
                }

                return this.Name.CompareTo(other.Name);
            }

            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }
    }
}
