using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class School
    {

        private ICollection<Course> courses;
        private string name;

        public School(string name)
        {
            this.Name = name;
            this.courses = new List<Course>();
        }

        public ICollection<Course> Courses
        {
            get
            {
                return new List<Course>(this.courses);
            }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The school name cannot be null or whitespace");
                }
                this.name = value;
            }
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("The course cannot be null");
            }

            if (this.courses.Any(c => c.Name == course.Name))
            {
                throw new InvalidOperationException("There is already a course with the same name");
            }

            this.courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("The course cannot be null");
            }

            if (this.courses.All(c => c.Name != course.Name))
            {
                throw new InvalidOperationException("There is no such course");
            }

            this.courses.Remove(course);
        }
    }
}
