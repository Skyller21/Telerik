using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛамбдаЕьпрессионс
{
    class Student
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public string LastName { get; set; }

        public GenderType Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public IEnumerable<Grade> Grade { get; set; }
        public int Age
        {
            get
            {
                return (DateTime.Now - BirthDate).Days /365;
            }
        }

        public override string ToString()
        {
            return "Names: " + this.FirstName +" " +this.LastName + " "+this.Age +" "+ this.Gender;
        }
    }
}
