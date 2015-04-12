namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Student:Person,IPerson
    {
        public Student(string name, string email, int studentId)
            :base(name, email)
        {
            
        }
        public int StudentId { get; set; }

        

    }
}
