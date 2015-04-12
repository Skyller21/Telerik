using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Shampoo:Product,IShampoo,IProduct
    {
        private decimal price;
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
            
        }

        public override decimal Price
        {
            get { return this.price*this.Milliliters; }
            protected set { this.price = value; }
        }

        public uint Milliliters { get; private set; }

        public Common.UsageType Usage { get; private set; }

        public override string Print()
        {
            //* Quantity: {product quantity} ml (when applicable)
            //* Usage: EveryDay/Medical (when applicable)

            StringBuilder result = new StringBuilder();
            result.AppendLine(base.Print());
            result.AppendLine(String.Format("  * Quantity: {0} ml", this.Milliliters));
            result.AppendLine(String.Format("  * Usage: {0}", this.Usage));
            return result.ToString().Trim();
        }
    }
}
