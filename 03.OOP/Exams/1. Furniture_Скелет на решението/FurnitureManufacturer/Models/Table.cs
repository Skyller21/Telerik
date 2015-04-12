using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    class Table : Furniture, ITable
    {
        private decimal width;
        private decimal length;
        public Table(string model, string material, decimal price, decimal height, decimal lenght, decimal width)
            : base(model, material, price, height)
        {
            this.Length = lenght;
            this.Width = width;
        }
        public decimal Length
        {
            get { return this.length; }
            private set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentNullException("The length must be positive");
                }
                this.length = value;
            }
        }

        public decimal Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentNullException("The width must be positive");
                }
                this.width = value;
            }
        }

        public decimal Area
        {
            get { return this.Length * this.Width; }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append(String.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area));
            return sb.ToString().Trim();
        }
    }
}
