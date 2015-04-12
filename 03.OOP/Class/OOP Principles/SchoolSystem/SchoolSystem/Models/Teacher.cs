using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models
{
    public class Teacher : Person, IPerson
    {
        public string Subject { get; set; }

        public Teacher(string name, string email, string subject)
            :base (name, email)
        {
                
        }
    }
}
