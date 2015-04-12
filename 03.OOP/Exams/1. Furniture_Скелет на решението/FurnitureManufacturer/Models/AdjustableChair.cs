using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    class AdjustableChair : Chair, IChair, IAdjustableChair, IFurniture
    {
        public AdjustableChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs, "Adjustable")
        {

        }
        public void SetHeight(decimal height)
        {
            if (height > 0.00m)
            {
                this.Height = height; 
            }
        }
    }
}
