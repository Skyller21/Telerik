using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture:IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;
        private string material;

        public Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;;
            this.Height = height;
        }
        public string Model
        {
            get { return this.model; }
            set
            {
                if (String.IsNullOrEmpty(value)|| value.Length<3)
                {
                    throw new ArgumentOutOfRangeException("The model cannot be less than 3 symbols long");
                }
                this.model = value;
            }
        }

        public string Material
        {
            get { return this.material; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The material type cannot be null");
                }
                this.material = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentOutOfRangeException("The price must be positive number!");
                }
                this.price = value;
            }
        }

        public decimal Height
        {
            get { return this.height; }
            set
            {
                if (value<=0.00m)
                {
                    throw new ArgumentOutOfRangeException("The height of the furniture mjust be positive number!");
                }
                this.height = value;
            }

        }

        public override string ToString()
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var mat = textInfo.ToTitleCase(this.Material);
           
            return String.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name,
                this.Model, mat, this.Price, this.Height);
        }
    }
}
