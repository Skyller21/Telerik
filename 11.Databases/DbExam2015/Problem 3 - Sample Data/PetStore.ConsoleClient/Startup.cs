namespace PetStore.ConsoleClient
{
    using System;
    using Importer.Importers;


    public class Startup
    {
        public static void Main()
        {
            //var ctx = new PetStoreEntities();

            //var pets = ctx.Pets.ToList();

            //foreach (var pet in pets)
            //{
            //    Console.WriteLine(pet.Breed);
            //}

            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
