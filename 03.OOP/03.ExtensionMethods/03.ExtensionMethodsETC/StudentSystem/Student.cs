using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentSystem
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private string fn;
        private string tel;
        private string email;
        private List<int> marks;
        private int groupNumber;




        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 2)
                    throw new ArgumentNullException("The name must not be empty and at least 2 characters long");

                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 2)
                    throw new ArgumentNullException("The name must not be empty and at least 2 characters long");

                lastName = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0 || value > 130)
                    throw new ArgumentOutOfRangeException("The age of the student must be between 0 years and 130 years");

                age = value;
            }
        }

        public string Fn
        {
            get { return fn; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("The faculty number of the student cannot be empty");

                fn = value;
            }
        }

        public string Tel
        {
            get { return tel; }
            set
            {
                if (String.IsNullOrEmpty(value) || new Regex("[^+\\d]").Match(value).Success)
                    throw new ArgumentNullException("The telephone must contain only digits and optional + sign");

                tel = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                Regex regex = new Regex(@"[\w\.\-_]{1,}@[A-z0-9\.\-]+\.[A-z\-_]+");

                if (!regex.Match(value).Success)
                    throw new ArgumentException("The EMAIL is not valid");

                this.email = value;

            }
        }

        public List<int> Marks
        {
            get { return marks; }
            private set
            {
                if (value.Any(mark => mark < 2 || mark > 6))
                {
                    throw new ArgumentOutOfRangeException("The mark should be between 2 and 6");
                }
                marks = value;
            }
        }

        public int GroupNumber
        {
            get { return groupNumber; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentNullException("The group number must be greater than 0");
                groupNumber = value;
            }
        }





        public Student()
        {

        }

        public Student(string firstName, string lastName, string fn, string tel, string email, List<int> marks,
            int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Fn = fn;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;

        }

        public override string ToString()
        {
            return String.Format("{0} {1}, FN:{2}, Tel:{3}, Email:{4}, Marks:({5}), Group:{6}",
                this.FirstName, this.LastName, this.Fn, this.Tel, this.Email, String.Join(" ", this.Marks), this.GroupNumber);
        }

        public string PrintMarks()
        {
            return "(" + String.Join(", ", this.Marks) + ")";
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


}
