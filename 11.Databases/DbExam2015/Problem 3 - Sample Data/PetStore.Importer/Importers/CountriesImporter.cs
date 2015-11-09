namespace PetStore.Importer.Importers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Data;

    public class CountriesImporter : IImporter
    {
        private const int NumberOfCountries = 20;
        public string Message
        {
            get { return "Importing Countries"; }
        }

        public int Order
        {
            get
            {
                return 1;
            }
        }

        public Action<PetStoreEntities, TextWriter> Get
        {
            get
            {
                return (db, tw) =>
                {
                    var countriesSet = new HashSet<string>();
                    for (int i = 0; i < NumberOfCountries; i++)
                    {
                        var countryName = RandomGenerator.GetRandomString(5, 30);

                        // This while loop ensures the unique country name
                        while (countriesSet.Contains(countryName.ToLower()))
                        {
                            countryName = RandomGenerator.GetRandomString(5, 30);
                        }

                        var newCountry = new Country()
                             {
                                 Name = countryName
                             };

                        countriesSet.Add(newCountry.Name.ToLower());
                        db.Countries.Add(newCountry);

                        if (i % 10 == 0)
                        {
                            tw.Write(".");
                        }

                        if (i % 100 == 0)
                        {
                            db.SaveChanges();
                            db.Dispose();
                            db = new PetStoreEntities();
                        }
                    }

                    db.SaveChanges();
                };
            }
        }
    }
}
