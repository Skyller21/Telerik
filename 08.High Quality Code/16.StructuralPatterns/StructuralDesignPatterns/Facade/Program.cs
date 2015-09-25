using Facade.Contracts;
using Facade.Models;

namespace Facade
{
    using Facade.Contracts;
    using Facade.Models;


    public class Program
    {
        public static void Main(string[] args)
        {
            Chef chef = new Chef();
            IIngredient[] list = { new Carrot(), new Potato() };
            chef.Cook(list);
        }
    }
}
