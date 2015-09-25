using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlCreationClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();

            SeedStudents(students);

            var xmlDoc = CreateXmlDocument(students);

            Console.WriteLine(xmlDoc);
        }

        private static XDocument CreateXmlDocument(List<Student> students, string path = null)
        {
            XNamespace ns = "urn:students";
            if (path == null)
            {
                path = "../../../";
            }

            XDeclaration declaration = new XDeclaration("1.0", "utf-8", null);
            
            XDocument xml = new XDocument();

            xml.Declaration = declaration;
            xml.Add(new XProcessingInstruction(
                "xml-stylesheet",
                "type='text/xsl' href='students.xslt'"));


            var root = new XElement("students");
            xml.Add(root);

            root.SetAttributeValue(XNamespace.Xmlns + "student", ns);

            foreach (var student in students)
            {
                var studentElement = new XElement("student");

                studentElement.Add(new XAttribute("faculty-number", student.FacultyNumber));
                studentElement.Add(new XElement("name", student.Name));
                studentElement.Add(new XElement("gender", student.Gender));
                studentElement.Add(new XElement("birthday", student.Birthday.ToShortDateString()));
                studentElement.Add(new XElement("phone", student.Phone));
                studentElement.Add(new XElement("email", student.Email));
                studentElement.Add(new XElement("course", student.Course));
                studentElement.Add(new XElement("specialty", student.Specialty));

                var exams = new XElement("taken-exams");

                foreach (var exam in student.Exams)
                {
                    var examElement = new XElement("exam");
                    examElement.Add(new XElement("name", exam.Name));
                    examElement.Add(new XElement("tutor", exam.Tutor));
                    examElement.Add(new XElement("grade", exam.Score));
                    exams.Add(examElement);
                }

                studentElement.Add(exams);
                root.Add(studentElement);
            }

            xml.Save(path + "students.xml");
            return xml;
        }

        private static void SeedStudents(List<Student> students)
        {
            var st1 = new Student()
            {
                Name = "Ivan Ivanoff",
                Gender = Gender.Male,
                Birthday = new DateTime(1990, 05, 05),
                Phone = "0888888888",
                Email = "ivan@abv.bg",
                Course = Course.ComputerScience,
                Specialty = Specialty.SoftwareEngineer,
                FacultyNumber = "00121",
                Exams = new List<Exam>()
                {
                    new Exam()
                    {
                        Name = "JS Exam",
                        Tutor = "Doncho Minkov",
                        Score = 6
                    }
                }
            };
            var st2 = new Student()
            {
                Name = "Pesho Peshev",
                Gender = Gender.Male,
                Birthday = new DateTime(1992, 02, 13),
                Phone = "0777777777",
                Email = "pesho@gmail.com",
                Course = Course.Mathematics,
                Specialty = Specialty.Mathematician,
                FacultyNumber = "00123",
                Exams = new List<Exam>()
                {
                    new Exam()
                    {
                        Name = "Discreet Mathematics",
                        Tutor = "Batman",
                        Score = 6
                    },
                    new Exam()
                    {
                        Name = "Linear Algebra",
                        Tutor = "Superman",
                        Score = 5
                    }
                }
            };

            var st3 = new Student()
            {
                Name = "Minka Minkova",
                Gender = Gender.Female,
                Birthday = new DateTime(1991, 10, 18),
                Phone = "0666666666",
                Email = "minka@gmail.com",
                Course = Course.ComputerScience,
                Specialty = Specialty.SystemAdministrator,
                FacultyNumber = "00125",
                Exams = new List<Exam>()
                {
                    new Exam()
                    {
                        Name = "Linux Adminitsration",
                        Tutor = "Wonder Woman",
                        Score = 6
                    },
                    new Exam()
                    {
                        Name = "Windows Adminitsration",
                        Tutor = "Bill Gates",
                        Score = 6
                    }
                }
            };

            students.AddRange(new List<Student> { st1, st2, st3 });
        }
    }
}
