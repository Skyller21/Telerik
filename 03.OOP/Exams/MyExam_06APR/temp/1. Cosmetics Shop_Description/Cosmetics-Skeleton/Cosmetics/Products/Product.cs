using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private string name;
        private string brand;


        protected Product(string name, string brand, decimal price, Common.GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }
        public string Name
        {
            get { return this.name; }
            protected set
            {
                Validator.CheckIfStringLengthIsValid(value, NameMaxLength, NameMinLength, String.Format(GlobalErrorMessages.InvalidStringLength, this.GetType().BaseType.Name + " name", NameMinLength, NameMaxLength));
                this.name = value;
            }
        }

        public string Brand
        {
            get { return this.brand; }
            protected set
            {
                Validator.CheckIfStringLengthIsValid(value, BrandMaxLength, BrandMinLength, String.Format(GlobalErrorMessages.InvalidStringLength, this.GetType().BaseType.Name + " brand", BrandMinLength, BrandMaxLength));
                                                                                                                    
                this.brand = value;
            }
        }

        public virtual decimal Price { get; protected set; }

        public Common.GenderType Gender { get; protected set; }

        public virtual string Print()
        {
            //- {product brand} – {product name}:
            //* Price: ${product price}
            //* For gender: Men/Women/Unisex

            StringBuilder result = new StringBuilder();
            result.AppendLine(String.Format("- {0} - {1}:", this.Brand, this.Name));
            result.AppendLine(String.Format("  * Price: ${0}", this.Price));
            result.AppendLine(String.Format("  * For gender: {0}", this.Gender));
            return result.ToString().Trim();
        }
    }
}
