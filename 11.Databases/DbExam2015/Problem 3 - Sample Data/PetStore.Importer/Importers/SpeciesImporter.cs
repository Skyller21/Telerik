namespace PetStore.Importer.Importers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Data;

    public class SpeciesImporter : IImporter
    {
        private const int NumberOfSpecies = 100;
        public string Message
        {
            get { return "Importing Species"; }
        }

        public int Order
        {
            get { return 2; }
        }

        public Action<PetStoreEntities, TextWriter> Get
        {
            get
            {


                return (db, tw) =>
                {
                    var speciesSet = new HashSet<string>();
                    var countriesIds = db.Species
                        .Select(d => d.Id)
                        .ToList();

                    try
                    {


                        for (int i = 0; i < countriesIds.Count; i++)
                        {
                            for (int j = 0; j < NumberOfSpecies / countriesIds.Count - 1; j++)
                            {

                                var randomCountryId = countriesIds[countriesIds[i]];

                                var speciesName = RandomGenerator.GetRandomString(5, 30);

                                while (speciesSet.Contains(speciesName.ToLower()))
                                {
                                    speciesName = RandomGenerator.GetRandomString(5, 30);
                                }

                                var newSpecies = new Species()
                                {
                                    Name = speciesName,
                                    Pets = new List<Pet>(),
                                    Products = new List<Product>(),
                                    CountryId = randomCountryId
                                };


                                db.Species.Add(newSpecies);

                                if (i * j % 10 == 0)
                                {
                                    tw.Write(".");
                                }

                                if (i * j % 100 == 0)
                                {
                                    db.SaveChanges();
                                    db.Dispose();
                                    db = new PetStoreEntities();
                                }
                            }
                        }
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                    {
                        var p = ex.EntityValidationErrors.ToList();
                    }


                    db.SaveChanges();
                };
            }
        }
    }
}
