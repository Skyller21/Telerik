namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public abstract class Course
    {
        private string name;
        private string teacherName;

        protected Course(string courseName)
        {
            this.Name = courseName;
            this.Students = new List<string>();
        }

        protected Course(string courseName, string teacherName)
            : this(courseName)
        {
            this.TeacherName = teacherName;
        }

        protected Course(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.ValidateIfNullOrEmpty(value, "course name");
                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                Validator.ValidateIfNullOrEmpty(value, "course name");
                this.teacherName = value;
            }
        }

        public IList<string> Students { get; set; }

        public void AddStudents(params string[] students)
        {
            foreach (var student in students)
            {
                Validator.ValidateIfNullOrEmpty(student, "student");
                this.Students.Add(student);
            }
        }

        public override string ToString()
        {
            string courseType = this.GetType().Name;

            return string.Format("{0} {{ Name = {1}; Teacher = {2}; Students = {3} }}", courseType, this.Name, this.TeacherName, this.GetStudentsAsString());
        }

        private string GetStudentsAsString()
        {
            return string.Format("{{{0}}} ", string.Join(", ", this.Students.OrderBy(s => s)));
        }
    }
}
