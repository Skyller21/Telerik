namespace _01.MasterChef.Models
{
    using System;
    using _01.MasterChef.Contracts;

    public class Chef
    {
        private ITableware bowl;
        private IIngredient[] ingredients;

        public void Cook(params IIngredient[] ingredients)
        {
            this.ingredients = ingredients;
            this.bowl = this.GetBowl();
            this.ProccessIngredients(this.bowl, this.ingredients);
            Console.WriteLine("COOKING TIME...");
        }

        private void ProccessIngredients(ITableware bowlToUse, params IIngredient[] ingredientsToUse)
        {
            foreach (var ingredient in ingredientsToUse)
            {
                this.Peel(ingredient);
                this.Cut(ingredient);
                bowlToUse.Add(ingredient);
            }
        }

        private ITableware GetBowl()
        {
            return new Bowl();
        }


        private void Cut(IIngredient ingredient)
        {
            Console.WriteLine("Cutting {0}", ingredient.GetType().Name);
        }
        
        private void Peel(IIngredient ingredient)
        {
            Console.WriteLine("Peeling {0}", ingredient.GetType().Name);
        }

       
    }
}
