namespace StudentSystem.Importer.Importers

{
    using System;
    using System.IO;
    using System.Linq;
    using Data;

    public class ProjectsImporter : IImporter
    {
        private const int NumberOfProjects = 1000; //1000
        public string Message
        {
            get { return "Importing projects"; }
        }

        public int Order
        {
            get { return 4; }
        }

        public Action<StudentSystemContext, TextWriter> Get
        {
            get
            {
                return (db, tw) =>
                {
                    var allEmployeesIds =
                        db.Emploees
                            .OrderBy(e => Guid.NewGuid()) // RANDOM ORDER !!!
                            .Select(e => e.Id)
                            .ToList();

                    var currentEmployeeIndex = 0;
                    for (int i = 0; i < NumberOfProjects; i++)
                    {
                        var currentProject = new Project
                        {
                            Name = RandomGenerator.GetRandomString(5, 50)
                        };

                        var numberOfEmployeesPerProject = RandomGenerator.GetRandomNumber(2, 8);

                        for (int j = 0; j < numberOfEmployeesPerProject; j++)
                        {
                            if (currentEmployeeIndex >= allEmployeesIds.Count)
                            {
                                break;
                            }

                            var currenEmployyId = allEmployeesIds[currentEmployeeIndex];

                            var startDate = RandomGenerator.GetRandomDate(before: DateTime.Now.AddDays(-100));

                            currentProject.ProjectsEmploees.Add(
                                new ProjectsEmploee
                                {
                                    EmploeeId = currenEmployyId,
                                    StartingDate = startDate,
                                    EndingDate = RandomGenerator.GetRandomDate(after: startDate)
                                });

                            currentEmployeeIndex++;
                        }

                        db.Projects.Add(currentProject);

                        if (i % 10 == 0)
                        {
                            tw.Write(".");
                        }

                        if (i% 100 == 0)
                        {
                            db.SaveChanges();
                            db.Dispose();
                            db = new StudentSystemContext();
                        }
                    }

                    db.SaveChanges();
                };
            }
        }
    }
}
