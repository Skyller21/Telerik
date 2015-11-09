namespace StudentSystem.Importer.Importers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Data;
    using Models;


    public class StudentsImporter : IImporter
    {
        private const int StudentsToImport = 200;

        public string Message
        {
            get { return "Importing reports"; }
        }

        public int Order
        {
            get { return 1; }
        }


        public Action<StudentSystemContext, TextWriter> Get
        {
            get
            {
                return (db, tw) =>
                {
                    for (int i = 0; i < StudentsToImport; i++)
                    {
                        var numberOfCourses = RandomGenerator.GetRandomNumber(2, 5);
                        var numberOfHomeworks = RandomGenerator.GetRandomNumber(0, 15);
                        var studentToAdd = new Student()
                        {
                            FirstName = RandomGenerator.GetRandomString(2, 50),
                            LastName = RandomGenerator.GetRandomString(2, 50),
                            Number = RandomGenerator.GetRandomString(10, 10),
                            Courses = new List<Course>(),
                            Homeworks = new List<Homework>()
                        };



                        

                        for (int j = 0; j < numberOfHomeworks; j++)
                        {

                            var homework = new Homework()
                            {
                                Content = RandomGenerator.GetRandomString(2, 200),
                                TimeSent = RandomGenerator.GetRandomDate(before: new DateTime(2016, 01, 01), after: new DateTime(2015, 01, 01))
                            };


                            studentToAdd.Homeworks.Add(homework);
                        }
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
                    db.Dispose();
                };
            }
        }
    }
}
