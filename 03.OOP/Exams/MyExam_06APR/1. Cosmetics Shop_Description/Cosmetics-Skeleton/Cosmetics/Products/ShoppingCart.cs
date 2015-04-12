using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    class ShoppingCart:IShoppingCart
    {
        private ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.ProductList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList
        {
            get { return new List<IProduct>(productList); }
            set { productList = value; }
        }

        public void AddProduct(IProduct product)
        {
            this.productList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.productList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.ProductList.Any(x => x.Name == product.Name);
        }

        public decimal TotalPrice()
        {
            decimal sum = this.ProductList.Sum(product => product.Price);
            return sum;
        }
    }
}
