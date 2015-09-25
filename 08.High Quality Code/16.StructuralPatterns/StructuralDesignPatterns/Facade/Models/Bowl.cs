using Facade.Contracts;

namespace Facade.Models
{
    using System;
    using Facade.Contracts;

    public class Bowl : ITableware
    {
        public void Add(IIngredient ingredient)
        {
            Console.WriteLine("Adding {0}", ingredient.GetType().Name);
        }
    }
}
