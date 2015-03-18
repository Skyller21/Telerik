using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛамбдаЕьпрессионс;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
           List<Student> students =  GetStudents();





           //Lambda expressions
           var list = students.OrderBy(st => st.FirstName).ThenBy(st => st.LastName).ToList();


           foreach (var item in list)
           {

               Console.WriteLine(item);
               
           }
           Console.WriteLine();

           var foundStudents = students.FindAll(st => st.Gender == GenderType.male)
               .FindAll(st=>st.Age>20);



           var maleStudents = new List<Student>();
           foreach (var item in students)
           {
               if (item.Gender == GenderType.male)
               {
                   maleStudents.Add(item);
               }
           }


           foreach (var item in foundStudents)
           {
               Console.WriteLine(item.ToString());
           }
           foreach (var item in maleStudents)
           {
               Console.WriteLine(item.ToString());   
           }
        }

        private static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>(){
                new Student{
                    Id = 1,
                    FirstName = "Pesho",
                    LastName = "Peshev",
                    BirthDate = new DateTime(1985,5,5),
                    Gender = GenderType.male,
                    Grade = new List<Grade> { new Grade(5), new Grade(3), new Grade(4)}
                },
                new Student{
                    Id = 2,
                    FirstName = "Maria",
                    LastName = "Gosheva",
                    BirthDate = new DateTime(1989,9,9),
                    Gender = GenderType.female,
                    Grade = new List<Grade> { new Grade(4), new Grade(2), new Grade(6)}
                },
                new Student{
                    Id = 3,
                    FirstName = "Maria",
                    LastName = "Ivanova",
                    BirthDate = new DateTime(1990,4,9),
                    Gender = GenderType.female,
                    Grade = new List<Grade> { new Grade(6), new Grade(6), new Grade(6)}
                },
                new Student{
                    Id = 4,
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    BirthDate = new DateTime(1990,3,9),
                    Gender = GenderType.male,
                    Grade = new List<Grade> { new Grade(4), new Grade(6), new Grade(5)}
                }
            };

            return students;
        }
    }
}
