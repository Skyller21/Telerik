using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    class Toothpaste:Product,IToothpaste,IProduct
    {
        private const int IngredientMinLength = 3;
        private const int IngredientMaxLength = 13;
        private string ingredients;
        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
            : base(name, brand, price, gender)
        {
            this.Ingredients = ingredients;
        }
        public string Ingredients
        {
            get { return this.ingredients; }
            private set
            {
                var ingredientsList = value.Split(new string[]{", "},StringSplitOptions.RemoveEmptyEntries);
                foreach (var curIngredient in ingredientsList)
                {
                    Validator.CheckIfStringLengthIsValid(curIngredient, IngredientMaxLength, IngredientMinLength, String.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", IngredientMinLength, IngredientMaxLength));
                }           

                this.ingredients = value;
            }
        }

        public override string Print()
        {
            //* Ingredients: {product ingredients, separated by “, “} (when applicable)
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.Print());
            result.AppendLine(String.Format("  * Ingredients: {0}", String.Join(", ", this.Ingredients)));

            return result.ToString().Trim();
        }
    }
}
