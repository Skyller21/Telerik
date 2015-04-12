using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentClass
{
    public class Student : IComparable<Student>, ICloneable
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string address;
        private string phone;
        private string email;
        private string course;


        public Student(string firstName, string middleName, string lastName, string ssn, string adress, string phone, string email, string course,
            Specialty specialty, Faculty faculty, University university)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.Address = adress;
            this.Phone = phone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.Faculty = faculty;
            this.University = university;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set { this.firstName = value; }
        }
        public string MiddleName
        {
            get { return this.middleName; }
            set { this.middleName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set { this.lastName = value; }
        }
        public string Ssn
        {
            get { return this.ssn; }
            private set { this.ssn = value; }
        }
        public string Address
        {
            get { return this.address; }
            private set { this.address = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            private set { this.phone = value; }
        }

        public string Email
        {
            get { return this.email; }
            private set { this.email = value; }
        }

        public string Course
        {
            get { return this.course; }
            private set { this.course = value; }
        }

        public Specialty Specialty { get; private set; }
        public Faculty Faculty { get; private set; }
        public University University { get; private set; }




        public override bool Equals(object obj)
        {
            if (!this.FirstName.Equals(((Student)obj).FirstName)) return false;
            if (!this.MiddleName.Equals(((Student)obj).MiddleName)) return false;
            if (!this.LastName.Equals(((Student)obj).LastName)) return false;
            if (!this.Ssn.Equals(((Student)obj).Ssn)) return false;
            return true;
        }


        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() + this.Ssn.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}, SSN: {3}", this.FirstName, this.MiddleName, this.LastName, this.Ssn);
        }

        public static bool operator ==(Student st1, Student st2)
        {
            return st1.Equals(st2);
        }

        public static bool operator !=(Student st1, Student st2)
        {
            return !(st1.Equals(st2));
        }



        public object Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.Ssn, this.Address,
                this.Phone, this.Email, this.Course, this.Specialty, this.Faculty, this.University);
        }

        public int CompareTo(Student other)
        {
            if (Student.Equals(this, other)) return 0;

            Student[] students = { this, other };

            var st = students.OrderBy(x => x.FirstName)
                 .ThenBy(x => x.MiddleName)
                 .ThenBy(x => x.LastName)
                 .ThenBy(x => x.Ssn)
                 .First();

            return Student.Equals(st, this) ? -1 : 1;
        }
    }
}