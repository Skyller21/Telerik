namespace _02.FindInCollection
{
    using System;

    public class Product : IComparable
    {
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }


        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("The product is null!!!");
            }

            var otherProduct = obj as Product;

            return this.Price.CompareTo(otherProduct.Price);
        }
    }
}
