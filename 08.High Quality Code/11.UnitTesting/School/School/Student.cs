using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student
    {
        private const int MinStudentId = 10000;
        private const int MaxStudentId = 99999;
        private string name;
        private int studentId;

        public Student(string name, int studentId)
        {
            this.Name = name;
            this.StudentId = studentId;
        }
        
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name cannot be null or whitespace");
                }
                this.name = value;
            }
        }

        public int StudentId
        {
            get { return this.studentId; }
            private set
            {
                if (value < MinStudentId || value > MaxStudentId)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The student id must be in range [{0};{1}]", MinStudentId, MaxStudentId));
                }
                this.studentId = value;
            }
        }

        public void JoinCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("The course cannot be null");
            }

            course.AddStudent(this);
        }

        public void LeaveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("The course cannot be null");
            }

            course.RemoveStudent(this);
        }
    }
}
