using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    
    class ConvertibleChair : Chair, IChair, IConvertibleChair, IFurniture
    {
        private readonly decimal InitialHeight;
         public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs, "Convertible")
         {
             InitialHeight = this.Height;
         }
        public bool IsConverted { get; private set; }

        public void Convert()
        {
            
            if (this.IsConverted == true)
            {
                this.IsConverted = false;
                this.Height = this.InitialHeight;
            }
            else
            {
                this.IsConverted = true;
                
                this.Height = 0.10m;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append(String.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal"));
            return sb.ToString().Trim();

        }
    }
}
