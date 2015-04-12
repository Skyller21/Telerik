using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Category : ICategory
    {
        private const int CategoryMinLength = 2;
        private const int CategoryMaxLength = 15;
        private string name;
        private ICollection<IProduct> productsList;

        public Category(string name)
        {
            this.Name = name;
            this.ProductsList = new List<IProduct>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                Validator.CheckIfStringLengthIsValid(value, CategoryMaxLength, CategoryMinLength, String.Format(GlobalErrorMessages.InvalidStringLength, this.GetType().Name + " name", CategoryMinLength, CategoryMaxLength));
                this.name = value;
            }
        }

        public ICollection<IProduct> ProductsList
        {
            get { return new List<IProduct>(this.productsList);}
            private set
            {
                this.productsList = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics,"Product cannot be null");
            this.productsList.Add(cosmetics);
            this.productsList =this.ProductsList.OrderBy(x => x.Brand).ThenByDescending(x => x.Price).ToList();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            this.productsList.Remove(cosmetics);
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(String.Format("{0} category - {1} {2} in total", this.Name, ProductsList.Count,
                ProductsList.Count == 1 ? "product" : "products"));
            foreach (var product in this.ProductsList)
            {
                result.AppendLine(product.Print());
            }

            return result.ToString().Trim();
        }
    }
}
