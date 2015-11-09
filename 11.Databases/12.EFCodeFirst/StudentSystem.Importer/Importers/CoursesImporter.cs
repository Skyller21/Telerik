namespace StudentSystem.Importer.Importers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Data;
    using Models;

    public class CoursesImporter : IImporter
    {
        private const int NumberOfCourses = 5; //100
        public string Message
        {
            get { return "Importing Departments"; }
        }

        public int Order
        {
            get
            {
                return 2;
            }
        }

        public Action<StudentSystemContext, TextWriter> Get
        {
            get
            {
                return (db, tw) =>
                {
                    for (int i = 0; i < NumberOfCourses; i++)
                    {
                        var course = new Course()
                        {
                            Name = RandomGenerator.GetRandomString(2, 50),
                            Description = RandomGenerator.GetRandomString(0, 100),
                            Materials = RandomGenerator.GetRandomString(0, 200),
                            Students = new List<Student>(),
                            Homeworks = new List<Homework>()
                        };

                        var numberOfStudentsInCourse = RandomGenerator.GetRandomNumber(10, 20);

                        var students = db.Students.ToList();

                        for (int j = 0; j < numberOfStudentsInCourse; j++)
                        {
                            var index = RandomGenerator.GetRandomNumber(0, numberOfStudentsInCourse - 1);
                            course.Students.Add(students[index]);

                            var currentStudent = db.Students.FirstOrDefault(s => s.Id == students[index].Id);

                            currentStudent.Courses.Add(course);

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
                };
            }
        }
    }
}
