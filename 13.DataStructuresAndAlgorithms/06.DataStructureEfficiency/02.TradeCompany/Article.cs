namespace _02.TradeCompany
{
    using System;

    public class Article : IComparable
    {
        // each described by barcode, vendor, title and price.

        public string Vendor { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Barcode { get; set; }

        public override string ToString()
        {
            return $"Article: {this.Title}, {this.Price:F2}";
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            var otherArticle = obj as Article;

            return this.Price.CompareTo(otherArticle.Price);
        }
    }
}
