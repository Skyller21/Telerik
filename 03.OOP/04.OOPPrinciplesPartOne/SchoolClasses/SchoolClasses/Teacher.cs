using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    class Teacher:Person
    {
        public List<Discipline> DisciplinesTeached { get; private set; }

        public Teacher():base()
        {
            
        }
        public Teacher(string firstName,string lastName, List<Discipline> disciplines ):base(firstName,lastName)
        {
            this.DisciplinesTeached = disciplines;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + "; Teaches: " + String.Join(", ", this.DisciplinesTeached.ToList());
        }
    }
}
