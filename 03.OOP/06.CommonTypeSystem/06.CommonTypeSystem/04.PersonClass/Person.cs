using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PersonClass
{
    class Person
    {
        public Person(string firstName, string lastName, int? age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int? Age { get; private set; }


        public override string ToString()
        {
            return String.Format("{0} {1}, Age: {2}", this.FirstName, this.LastName, this.Age != null? this.Age.ToString()+" years old":"Not specified");
        }
    }
}
