using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student("Ivan", "Ivanov", "Ivanov", "8707070707", null, null, null, null, Specialty.Other, Faculty.Other, University.Other);
            Student st2 = new Student("Petar", "Petrov", "Petrov", "8808080808", null, null, null, null, Specialty.Other, Faculty.Other, University.Other);

            object st3 = st1.Clone();                               //Deep copy
            Console.WriteLine(st1.CompareTo(st2));

            Console.WriteLine(st1.CompareTo(st3 as Student));
            Console.WriteLine(st1==st3);

            Console.WriteLine(st1);
            Console.WriteLine(st2);
            
        }
    }
}
