using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    public abstract class Person
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return this.firstName; }
            protected set
            {
                if (value.Length < 2)
                    throw new ArgumentOutOfRangeException("The name must be at least two characters long");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            protected set
            {
                if (value.Length < 2)
                    throw new ArgumentOutOfRangeException("The name must be at least two characters long");
                this.lastName = value;
            }
        }

        public Person()
        {
        }

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
