using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1
            StringBuilder text = new StringBuilder("Hello There, User!");

            int startIndex = 6;
            StringBuilder substringSB = text.Substring(startIndex, text.Length - startIndex);
            Console.WriteLine(substringSB);

            //Task 2
            IEnumerable<int> list = new List<int>() { 1, 2, 3, 4 };

            int sum = list.Sum();
            Console.WriteLine("Sum = {0}", sum);

            int min = list.Min();
            Console.WriteLine("Min = {0}", min);

            int max = list.Max();
            Console.WriteLine("Max = {0}", max);

            double average = list.Average();
            Console.WriteLine("Average = {0}", average);


            Console.WriteLine(list.ToStringT());


            //Students

            List<Student> students = GetStudents();


            //Task 3
            var studentsNames =
                from st in students
                where st.FirstName.CompareTo(st.LastName) < 0
                select st;

            Console.WriteLine("\nStudents with first name before last name (Alphabetically)");
            foreach (var st in studentsNames)
            {
                Console.WriteLine(st);
            }

            //Task 4
            var studentsBetween18And24 =
                from st in students
                where st.Age < 24 & st.Age > 18
                select st;

            Console.WriteLine("\nStudents bewtween 18 and 24");
            foreach (var st in studentsBetween18And24)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName);
            }

            //Task 5 Lambda

            var studentsOrderByName = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);

            Console.WriteLine("\nStudents ordered by first name the by last name LAMBDA");
            foreach (var st in studentsOrderByName)
            {
                Console.WriteLine(st);
            }

            //Task 5 LINQ

            studentsOrderByName =
                from st in students
                orderby st.FirstName descending,
                        st.LastName descending
                select st;

            Console.WriteLine("\nStudents ordered by first name the by last name LINQ");
            foreach (var st in studentsOrderByName)
            {
                Console.WriteLine(st);
            }
        }

        private static List<Student> GetStudents()
        {

            return new List<Student>()
            {
                new Student{
                    FirstName = "Joro",
                    LastName = "Jorev",
                    Age = 21,
                    FN = "122231",
                    Tel = "+359888888888",
                    Email = "jorev.jorko@abv.bg",
                    Marks = new List<int>(){5,5,4,6},
                    Group = "B"
                },

                    new Student{
                    FirstName = "Darth",
                    LastName = "Vader",
                    Age = 50,
                    FN = "122236",
                    Tel = "+359777777777",
                    Email = "dark.force@force.com",
                    Marks = new List<int>(){3,3,3,5},
                    Group = "A"
                    },

                    new Student{
                    FirstName = "Marge",
                    LastName = "Simpson",
                    Age = 42,
                    FN = "122250",
                    Tel = "+359666666666",
                    Email = "simpsons@yahoo.com",
                    Marks = new List<int>(){6,6,6,6},
                    Group = "C"
                    },

                    new Student{
                    FirstName = "Super",
                    LastName = "Mario",
                    Age = 45,
                    FN = "122210",
                    Tel = "+359999999999",
                    Email = "mario@bros.com",
                    Marks = new List<int>(){3,5,4,6},
                    Group = "B"
                    },

                    new Student{
                    FirstName = "Zlatka",
                    LastName = "Tupata",
                    Age = 31,
                    FN = "122200",
                    Tel = "+359777777666",
                    Email = "zltaka@prosta.com",
                    Marks = new List<int>(){3,5,4,6},
                    Group = "D"
                    }


            };
        }


    }
}
