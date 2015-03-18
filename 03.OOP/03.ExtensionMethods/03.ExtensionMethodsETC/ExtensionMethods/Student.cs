using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Student
    {
        private string email;

        

        public string Email
        {
            get { return this.email; }
            set
            {
                Regex regex = new Regex(@"[\w\.\-_]{1,}@[A-z0-9\.\-]+\.[A-z\-_]+");

                if (!regex.Match(value).Success)
                {
                    throw new ArgumentException("The EMAIL is not valid");
                }
               this.email = value;

            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string FN { get; set; }
        public string Tel { get; set; }

        public List<int> Marks { get; set; }
        public string Group { get; set; }

        public Student()
        {

        }
        public Student(string firstName, string lastName, string fn, string tel, List<int> marks, string group)
        {
            this.FirstName = firstName;
            this.LastName = LastName;
            this.FN = fn;
            this.Tel = tel;
            this.Marks = marks;
            this.Group = group;

        }

        public override string ToString()
        {
            return String.Format("{0} {1}, FN:{2}, Tel:{3}, Marks:({4}), Group:{5}", 
                this.FirstName, this.LastName, this.FN, this.Tel, String.Join(" ", this.Marks), this.Group);
        }
    }
}
