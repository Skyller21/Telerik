using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PersonClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Batman", "Batmanov",28);
            Person person2 = new Person("Superman", "Supermanov", null);
            Console.WriteLine(person1);
            Console.WriteLine(person2);
        }
    }
}
