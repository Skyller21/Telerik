namespace StudentSystem.Importer.Importers

{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Data;


    public class ManagersImporter : IImporter
    {
        public string Message
        {
            get { return "Importing Managers"; }
        }

        public int Order
        {
            get { return 3; }
        }

        public Action<StudentSystemContext, TextWriter> Get
        {
            get
            {
                return (db, tw) =>
                {
                    var levels = new[] { 5, 5, 10, 10, 10, 15, 15, 15, 15 };

                    var allEmployeeIds = db.Emploees
                        .OrderBy(e => Guid.NewGuid()) // RANDOM ORDER !!!
                        .Select(e => e.Id)
                        .ToList();

                    var currentPersantage = 0;
                    List<int> previousManagers = null;

                    for (var i = 0; i < levels.Length; i++)
                    {
                        var level = levels[i];
                        var skip = (int)((currentPersantage * allEmployeeIds.Count) / 100.0);
                        var take = (int)((level * allEmployeeIds.Count) / 100.0);

                        var currrentEmployeeIDs =
                            allEmployeeIds
                                .Skip(skip)
                                .Take(take)
                                .ToList();
                        // !!! If using DB = Order before Skip and Take !!!

                        var emploees =
                            db.Emploees
                                .Where(e => currrentEmployeeIDs.Contains(e.Id))
                                .ToList();

                        foreach (var employee in emploees)
                        {
                            employee.ManagerId =
                                previousManagers == null
                                    ? null
                                    : (int?)previousManagers[RandomGenerator.GetRandomNumber(0, previousManagers.Count - 1)];
                        }


                        tw.Write(".");
                        db.SaveChanges();
                        db.Dispose();
                        db = new StudentSystemContext();

                        previousManagers = currrentEmployeeIDs;

                        currentPersantage += level;
                    }

                   // db.SaveChanges();
                };
            }
        }
    }
}
