namespace _01.MasterChef.Models
{
    using System;
    using _01.MasterChef.Contracts;

    public class Bowl : ITableware
    {
        public void Add(IIngredient ingredient)
        {
            Console.WriteLine("Adding {0}", ingredient.GetType().Name);
        }
    }
}
