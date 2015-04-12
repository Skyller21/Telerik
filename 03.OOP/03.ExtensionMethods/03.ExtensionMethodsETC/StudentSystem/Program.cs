using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Joro", "Jorev", "10205", "+359288888888", "jorev.jorko@abv.bg", new List<int> { 5, 5, 4, 6 }, 1),
                new Student("Darth", "Vader", "10806", "++359777777777", "dark.force@force.com", new List<int> {3, 3, 3, 5 }, 3),
                new Student("Marge", "Simpson", "08404", "+359666666666", "simpsons@yahoo.com", new List<int> { 6, 6, 6, 6 }, 2),
                new Student("Super", "Mario", "07103", "+359999999999", "mario@bros.com", new List<int> { 3, 5, 4, 6 }, 2),
                new Student("Zlatka", "Tupata", "05803", "+359777777666", "zlatka@prosta.com", new List<int> { 2, 2, 3, 3 }, 4),
                new Student("Kifloch","Silikonova","02406","+359200000000","kifla@begai.bg",new List<int>{6, 6, 6, 6},1)
            };

            //Task 9
            GetGroup(students, 2);


            OrderByFirstName(students);

            //Task 10
            //The same as the above using extension methods
            //IEnumerable<Student> group2Lambda = students.Where(x=>x.Group==2);
            //group2Lambda.ForEach();

            //IEnumerable<Student> orderByNameLambda = students.OrderBy(x=>x.FirstName);
            //orderByNameLambda.ForEach();

            //Task 11
            GetMail(students, "abv.bg");

            //Task 12
            GetTownSofia(students);

            //Task 13
            GetExellentScore(students);

            //Task 14
            GetMarks(students, 2, 2);

            //Task 15
            GetGraduatedInYearMarks(students, "2006");

            //Task 16
            GetDepartment(students, "Mathematics");

            //Task 17

            string[] arr = { "Mincho", "Joro", "Genoveva", "Ilian", "Joe", "Branimira" };
            GetLongestString(arr);

            //Task 18
            GroupByGroups(students);

            //Task 19
            GroupByGroupsLambda(students);
        }

        public static void GetLongestString(string[] arr)
        {
            Console.WriteLine("\nLongest string\n-----------------");
            var sortedArr =
                from str in arr
                orderby str.Length descending
                select str;

            Console.WriteLine("The longest string is: {0}", sortedArr.First());
        }

        public static void GroupByGroupsLambda(List<Student> students)
        {
            var groupList = students.OrderBy(x => x.GroupNumber).GroupBy(x => x.GroupNumber, (num, st) => new { Group = num, Students = st.ToArray() });

            Console.WriteLine("\nGrouped by groups LAMBDA\n-----------------");

            foreach (var group in groupList)
            {
                Console.WriteLine("Group {0}: ", group.Group);
                foreach (var item in group.Students)
                {
                    Console.WriteLine(item.FirstName + " " + item.LastName);
                }
            }
        }
        public static void GroupByGroups(List<Student> students)
        {
            var groupList =
                from student in students
                orderby student.GroupNumber
                group student by student.GroupNumber
                    into groups
                    select new { Group = groups.Key, Student = groups.ToArray() };

            Console.WriteLine("\nGrouped by groups\n-----------------");

            foreach (var group in groupList)
            {
                Console.WriteLine("Group {0}: ", group.Group);
                group.Student.ForEach();
            }

        }


        public static void GetDepartment(List<Student> students, string dept)
        {
            Group group1 = new Group(1, "Mathematics");
            Group group2 = new Group(2, "Literature");
            Group group3 = new Group(3, "Computer Science");

            List<Group> groups = new List<Group> { group1, group2, group3 };
            var departmentList =
                from groupItem in groups
                where groupItem.Department == dept
                join st in students on groupItem.GroupNumber equals st.GroupNumber
                select new { Name = st.FirstName + " " + st.LastName, Department = dept };



            Console.WriteLine("\nDepartment Mathematics\n-----------------");
            departmentList.ForEach();
        }
        public static void GetMarks(List<Student> students, int mark, int count)
        {
            var lowScore = students.Where(x => x.Marks.Count(y => y == mark) == count).Select(x => new { Name = x.FirstName + " " + x.LastName });

            Console.WriteLine("\nExactly two marks ({0})\n-----------------", mark);
            lowScore.ForEach();
        }
        public static void GetGraduatedInYearMarks(List<Student> students, string year)
        {
            var yearGraduated06 =
                from student in students
                where student.Fn.EndsWith(year.Substring(year.Length - 2))
                select new { Name = student.FirstName + " " + student.LastName, FN = student.Fn, Marks = student.PrintMarks() };

            Console.WriteLine("\nGraduated in 2006\n-----------------");
            yearGraduated06.ForEach();
        }

        public static void GetExellentScore(List<Student> students)
        {
            var exellentScore =
                from student in students
                where student.Marks.Contains(6)
                select new { Name = student.FirstName + " " + student.LastName, Marks = student.PrintMarks() };

            Console.WriteLine("\nAt least one exellent mark(6)\n-----------------");
            exellentScore.ForEach();
        }



        public static void GetTownSofia(List<Student> students)
        {
            var townSofia =
                from student in students
                where student.Tel.Substring(0, 5) == "+3592" || student.Tel.StartsWith("02")
                select student;

            Console.WriteLine("\nTown Sofia by phone code\n-----------------");
            townSofia.ForEach();
        }

        public static void GetMail(List<Student> students, string mail)
        {
            var studentsAbvMail =
                from student in students
                where student.Email.Contains(mail)
                select student;

            Console.WriteLine("\nMail in abv.bg\n-----------------");
            studentsAbvMail.ForEach();
        }

        public static void OrderByFirstName(List<Student> students)
        {
            var orderByNameList =
                from student in students
                orderby student.FirstName
                select student;
            Console.WriteLine("\nOrdered by first name\n-----------------");
            orderByNameList.ForEach();
        }

        public static void GetGroup(List<Student> students, int searchedGroup)
        {
            var group =
                from student in students
                where student.GroupNumber == searchedGroup
                select student;
            Console.WriteLine("Group {0} students\n-----------------", searchedGroup);
            group.ForEach();
        }
    }
}
