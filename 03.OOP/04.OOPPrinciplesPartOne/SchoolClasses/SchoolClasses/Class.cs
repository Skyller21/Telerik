using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    class Class
    {

        private string classIdentifier;
        public List<Student> Students { get; private set; }
        public List<Teacher> Teachers { get; private set; }

        public string ClassIdentifier
        {
            get { return classIdentifier; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("#######The class identifier must not be null or empty");
                classIdentifier = value;
            }
        }

        public Class()
        {
            
        }
        public Class(string identifier)
        {
            this.ClassIdentifier = identifier;
            this.Teachers = new List<Teacher>();
            this.Students = new List<Student>();
        }
        public Class(string identifier, List<Teacher> teachers, List<Student> students ):this(identifier)
        {
            this.Teachers = teachers;
            this.Students = students;
        }
    }
}
