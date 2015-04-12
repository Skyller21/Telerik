using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value)||value.Count()<5)
                {
                    throw new ArgumentNullException("The name cannot be null");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            private set
            {
                Regex reg = new Regex("\\b\\d{10}\\b");
                if (!reg.IsMatch(value))
                {
                    throw new ArgumentNullException("The registration must be exactly 10 digits");
                }
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
            private set
            {
                if (value.Count < 0)
                {
                    throw new ArgumentNullException("The list of furnitures cannot be negative count");
                }
                this.furnitures = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
            this.Furnitures = this.Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model).ToList();

        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            var furnitureFound = this.Furnitures.FirstOrDefault(x => x.Model.ToLower() == model.ToLower());
            return furnitureFound;
        }

        public string Catalog()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("{0} - {1} - {2} {3}",
                                        this.Name,
                                        this.RegistrationNumber,
                                        this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                                        this.Furnitures.Count != 1 ? "furnitures" : "furniture"));
            foreach (var furniture in this.Furnitures)
            {
                sb.AppendLine(furniture.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
