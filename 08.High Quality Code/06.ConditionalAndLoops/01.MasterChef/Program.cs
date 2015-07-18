namespace _01.MasterChef
{
    using _01.MasterChef.Contracts;
    using _01.MasterChef.Models;


    public class Program
    {
        public static void Main(string[] args)
        {
            Chef chef = new Chef();
            IIngredient[] list = new IIngredient[] { new Carrot(), new Potato() };
            chef.Cook(list);
        }
    }
}
