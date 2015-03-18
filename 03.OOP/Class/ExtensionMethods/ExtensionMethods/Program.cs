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

            //Extension methods
            int num = 2;
            Console.WriteLine(num.Pow(2));

            string[] abc = { "asas", "asas", "aaakkkvkv" };
            Console.WriteLine(abc.ToString("-"));

            //Anonymous Types
            //Read only. Just for information.
            var obj = new
            {
                X = 4,
                Name = "Stamat",
                Id = 4
            };

            //obj.Id = 5; //Error	1	Property or indexer 'AnonymousType#1.Id' cannot be assigned to -- it is read only
            Console.WriteLine(obj.Id);
            var student = new Student { Id = 5, Name = "Ivan" };

            student.Id = 5;

            var manyAnonynous = new[]{
                new{X = 4,Name = "Stamat",Id = 4},
                new{X = 4,Name = "Pesho",Id = 4},
                new{X = 4,Name = "Ivan",Id = 4},
            };

            foreach (var item in manyAnonynous)
            {
                Console.WriteLine(item.ToString());
            }

            var one = new{X = 4,Name = "Stamat",Id = 4};
            var two = new { X = 4, Name = "Stamat", Id = 4 };

            Console.WriteLine(one==two);//false
            Console.WriteLine(one.Equals(two));//true

        }
    }
}
