using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Tests
{
    [TestClass]
    public class CourseTests
    {
        private const int MinValidStudentId = 10000;
        private const int MaxValidStudentId = 99999;
        private const int MaxStudentsInCourse = 30;
        private const string ValidStudentName = "Pesho";
        private const string ValidCourseName = "New Course";


        [TestMethod]
        public void CourseShoudNotThrowError()
        {
            var course = new Course(ValidCourseName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWithNullName()
        {
            var course = new Course(null);
        }

        [TestMethod]
        public void CourseShoulReturnNameCorrectly()
        {
            var course = new Course(ValidCourseName);
            Assert.AreEqual(ValidCourseName, course.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWithEmptyName()
        {
            var course = new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWithWhitespaceName()
        {
            var course = new Course("   ");
        }


        [TestMethod]
        public void CourseShouldAddStudentCorrectly()
        {
            var course = new Course(ValidCourseName);
            var student = new Student(ValidStudentName, MinValidStudentId+1);
            course.AddStudent(student);

            Assert.AreSame(student, course.Students.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWhenNullStudentAdded()
        {
            var course = new Course(ValidCourseName);
            Student student = null;
            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionWhenExistingStudentAdded()
        {
            var course = new Course(ValidCourseName);
            Student student = new Student(ValidStudentName, MinValidStudentId+1);
            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CourseShouldThrowExceptionWhenMoreThanPossibleStudentsAdded()
        {
            var course = new Course(ValidCourseName);

            for (int i = 0; i <= MaxStudentsInCourse; i++)
            {
                course.AddStudent(new Student(i.ToString(), MinValidStudentId+i));
            }
        }

        [TestMethod]
        public void CourseShouldRemoveStudentCorrectly()
        {
            var course = new Course(ValidCourseName);
            var student = new Student(ValidStudentName, MinValidStudentId+1);
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWhenRemovingNullStudent()
        {
            var course = new Course(ValidCourseName);
            Student student = null;
            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionWhenRemovingUnexistingStudent()
        {
            var course = new Course(ValidCourseName);
            Student student = new Student(ValidStudentName, MinValidStudentId+1);
            course.RemoveStudent(student);
        }
    }
}
