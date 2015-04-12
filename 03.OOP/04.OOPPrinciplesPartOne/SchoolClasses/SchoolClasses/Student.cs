using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    class Student : Person
    {
        private int studentNumber;
        public Student(string firstName, string lastName, int studentNumber)
            : base(firstName, lastName)
        {
            
            this.StudentNumber = studentNumber;
        }

        public int StudentNumber
        {
            get { return this.studentNumber; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("#######The student number must be greater than zero.");
                this.studentNumber = value;
            }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + "; Student number: " + this.StudentNumber;
        }
    }
}
