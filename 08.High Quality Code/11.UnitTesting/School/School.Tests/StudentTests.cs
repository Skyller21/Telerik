using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Tests
{
    [TestClass]
    public class StudentTests
    {
        private const int MinValidId = 10000;
        private const int MaxValidId = 99999;
        private const string ValidName = "Pesho";

        [TestMethod]
        public void ValidStudentShouldNotThrowAnException()
        {
            var student = new Student(ValidName, 12000);
        }

        [TestMethod]
        public void StudentShouldReturnExpectedName()
        {
            var student = new Student(ValidName, MinValidId + 1);

            Assert.AreEqual(ValidName, student.Name);
        }

        [TestMethod]
        public void StudentShouldReturnExpectedId()
        {
            var student = new Student(ValidName, MinValidId + 1);

            Assert.AreEqual(MinValidId+1, student.StudentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowNullReferenceExceptionForNullName()
        {
            var student = new Student(null, MinValidId + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowNullReferenceExceptionForEmptyName()
        {
            var student = new Student(string.Empty, MinValidId + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowNullReferenceExceptionForWhitespaceName()
        {
            var student = new Student("   ", MinValidId + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentShouldThrowArgumentExceptionForInvalidId_Low()
        {
            var student = new Student(ValidName, MinValidId - 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentShouldThrowArgumentExceptionForInvalidId_High()
        {
            var student = new Student(ValidName, MaxValidId + 1);
        }

        [TestMethod]
        public void StudentShouldNotThrowExceptionWhenJoinsCourse()
        {
            var student = new Student(ValidName, MinValidId + 1);
            var course = new Course("New Course");
            student.JoinCourse(course);
        }

        [TestMethod]
        public void StudentShouldNotThrowExceptionWhenLeavesCourse()
        {
            var student = new Student(ValidName, MinValidId + 1);
            var course = new Course("New Course");
            student.JoinCourse(course);
            student.LeaveCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowExceptionWhenAttendingNullCourse()
        {
            var student = new Student(ValidName, MinValidId + 1);
            Course course = null;
            student.JoinCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowExceptionWhenLeavingNullCourse()
        {
            var student = new Student(ValidName, MinValidId + 1);
            Course course = null;
            student.LeaveCourse(course);
        }
    }
}
