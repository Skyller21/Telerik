using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        private const int MaxStudentsInCourse = 30;
        private ICollection<Student> students;
        private string name;

        public Course(string name)
        {
            this.students = new List<Student>();
            this.Name = name;
        }

        public ICollection<Student> Students
        {
            get { return new List<Student>(this.students); }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name cannot be empty or null");
                }
                this.name = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student cannot be null");
            }

            if (this.students.Count > MaxStudentsInCourse - 1)
            {
                throw new ArgumentOutOfRangeException("The course is alreay full");
            }

            if (this.students.Any(s => s.StudentId == student.StudentId))
            {
                throw new InvalidOperationException("There is already a student with the same ID`");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student cannot be null");
            }

            if (this.students.All(s => s.StudentId != student.StudentId))
            {
                throw new InvalidOperationException("There is no such student");
            }

            this.students.Remove(student);
        }
    }
}
