using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Chair : Furniture, IChair
    {

        private int numberOfLegs;
        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs, string type = "Normal")
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
           
        }

        public int NumberOfLegs
        {
            get { return this.numberOfLegs; }
            private set
            {
                if (value == 0)
                {
                    throw new ArgumentNullException("The number of legs cannot be null");
                }
                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append(String.Format(", Legs: {0}", this.NumberOfLegs));
            return sb.ToString().Trim();
        }
    }
}
