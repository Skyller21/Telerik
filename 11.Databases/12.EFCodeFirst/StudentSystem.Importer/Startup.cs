namespace StudentSystem.Importer
{
    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            SampleDataImporter.Create(Console.Out).Import();

            //var date =RandomGenerator.GetRandomDate();
        }
    }
}
