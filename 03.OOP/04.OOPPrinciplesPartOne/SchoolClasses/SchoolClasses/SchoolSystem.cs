using System.Runtime.InteropServices;

namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class SchoolSystem
    {
        static void Main(string[] args)
        {

            //Create disciplines
            Discipline math;
            Discipline physics;
            Discipline literature;
            Discipline chemistry;
            Discipline biology;
            Discipline history;
            Discipline sport;
            Discipline(out math, out physics, out literature, out chemistry, out biology, out history, out sport);

           List<Person> list = new List<Person>();
            

            //Create teachers
            Teacher teacherBio;
            Teacher teacherSport;
            Teacher teacherMath;
            Teacher teacherLiterature;
            Teacher teacherHistory;
            CreateTeacherProfiles(out teacherBio, out teacherSport, out teacherMath, out teacherLiterature, out teacherHistory);

            list.Add(teacherBio);
            list.Add(new Student("aa","aa",2));

            teacherBio.DisciplinesTeached.Add(biology);
            teacherBio.DisciplinesTeached.Add(chemistry);
            teacherLiterature.DisciplinesTeached.Add(literature);
            teacherHistory.DisciplinesTeached.Add(history);
            teacherMath.DisciplinesTeached.Add(math);
            teacherMath.DisciplinesTeached.Add(physics);

            //Create Classes
            Class classA = new Class("A");
            Class classB = new Class("B");

            CreateClasses(out classA, out classB);

            classA.Teachers.AddRange(new List<Teacher>{teacherBio,teacherHistory,teacherMath});


            //Print 
            Console.WriteLine("Class \"A\" Students\n------------------");
            foreach (var student in classA.Students)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine("\nClass \"A\" Teachers\n------------------");
            foreach (var teacher in classA.Teachers)
            {
                Console.WriteLine(teacher.ToString());
            }

            
        }

        private static void CreateTeacherProfiles(out Teacher teacherBio, out Teacher teacherSport, out Teacher teacherMath,
            out Teacher teacherLiterature, out Teacher teacherHistory)
        {
            //Teachers
            teacherBio = new Teacher("Ivan", "Ivanov", new List<Discipline>());
            teacherSport = new Teacher("Plamen", "Cekov", new List<Discipline>());
            teacherMath = new Teacher("Minko", "Petrov", new List<Discipline>());
            teacherLiterature = new Teacher("Ivanka", "Peicheva", new List<Discipline>());
            teacherHistory = new Teacher("Genadi", "Panayotov", new List<Discipline>());
        }

        public static void Discipline(out Discipline math, out Discipline physics, out Discipline literature,
            out Discipline chemistry, out Discipline biology, out Discipline history, out Discipline sport)
        {
            //Disciplines
            math = new Discipline("Mathematics", 10, 20);
            physics = new Discipline("Physics", 8, 15);
            literature = new Discipline("Literature", 10, 20);
            chemistry = new Discipline("Chemistry", 6, 12);
            biology = new Discipline("Biology", 6, 12);
            history = new Discipline("History", 8, 16);
            sport = new Discipline("Sport", 0, 20);
        }

        public static void CreateClasses(out Class classA, out Class classB)
        {
            classA = new Class("A");
            classB = new Class("B");

            classA.Students.AddRange(new List<Student>
            {
                new Student("Ivo", "Kenov", 4),
                new Student("Denitsa", "Pavlova", 1),
                new Student("Haralampi", "Ivanov", 2),
                new Student("Petar", "Nikov", 6),
                new Student("Marto", "Stefanov", 5),
                new Student("Ivelina", "Pandeva", 3),
            });


            classB.Students.AddRange(new List<Student>
            {
                new Student("Pesho", "Genov", 4),
                new Student("Alex", "Marinov", 1),
                new Student("Georgi", "Georgiev", 2),
                new Student("Maria", "Petrova", 6),
                new Student("Liuba", "Stefanova", 5),
                new Student("Krasimira", "Indjova", 3),
            });
        }
    }
}
