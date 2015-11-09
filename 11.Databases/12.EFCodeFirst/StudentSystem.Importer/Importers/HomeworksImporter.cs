namespace StudentSystem.Importer.Importers
{
    using System;
    using System.IO;
    using System.Linq;

    using CompanySampleDataImporter.Data;
    using Data;
    using Models;

    public class HomeworksImporter : IImporter
    {
        //private const int NumberOfHomeworksPerCourse = 10; //5000
        public string Message
        {
            get { return "Importing Employees"; }
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
                    var courses = db.Courses
                        .Select(d => d.Id)
                        .ToList();

                    var students = db.Students
                        .Select(d => d.Id)
                        .ToList();


                    for (int i = 0; i < courses.Count; i++)
                    {
                        var randomHomeworksCount = RandomGenerator.GetRandomNumber(0, 10);


                        db.Homeworks.Add(new Homework()
                        {

                        });

                        if (i % 10 == 0)
                        {
                            tw.Write(".");
                        }

                        if (i % 100 == 0)
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
