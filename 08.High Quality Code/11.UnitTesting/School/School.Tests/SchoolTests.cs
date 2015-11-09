using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Tests
{
    [TestClass]
    public class SchoolTests
    {
        private const string ValidSchoolName = "New School";
        private const string ValidCourseName = "New Course";

        [TestMethod]
        public void SchoolShouldNotThrowException()
        {
            var school = new School(ValidSchoolName);
        }

        [TestMethod]
        public void SchoolShouldReturnNameCorrectly()
        {
            var school = new School(ValidSchoolName);
            Assert.AreEqual(ValidSchoolName, school.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNameIsNull()
        {
            var school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNameIsEmpty()
        {
            var school = new School(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNameIsWhitespace()
        {
            var school = new School("   ");
        }

        [TestMethod]
        public void SchoolShouldAddCourseCorrectly()
        {
            var school = new School(ValidSchoolName);
            var course = new Course(ValidCourseName);
            school.AddCourse(course);
            Assert.AreSame(course, school.Courses.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNullCourseAdded()
        {
            var school = new School(ValidSchoolName);
            Course course = null;
            school.AddCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenExistingCourseAdded()
        {
            var school = new School(ValidSchoolName);
            var course = new Course(ValidCourseName);
            school.AddCourse(course);
            school.AddCourse(course);
        }



        [TestMethod]
        public void SchoolShouldRemoveCourseCorrectly()
        {
            var school = new School(ValidSchoolName);
            var course = new Course(ValidCourseName);
            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.IsTrue(school.Courses.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenRemovingNullCourse()
        {
            var school = new School(ValidSchoolName);
            Course course = null;
            school.RemoveCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenRemovingNotExistingCourse()
        {
            var school = new School(ValidSchoolName);
            var course = new Course(ValidCourseName);
            school.RemoveCourse(course);
        }
    }
}
