namespace Methods
{
    using System;

    /// <summary>
    /// Class for creating object of type Student. Contains first name, last name, birth date and some other info.
    /// </summary>
    public class Student
    {
        public Student()
        {
        }

        /// <summary>
        /// Constructor for Student class
        /// </summary>
        /// <param name="firstName">Student's first name</param>
        /// <param name="lastName">Student's last name</param>
        /// <param name="birthday">Student's birth date</param>
        /// <param name="town">Student's home town</param>
        /// <param name="otherInfo">Other unspecified info about the student</param>
        public Student(string firstName, string lastName, DateTime birthday, Town town, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthdayDate = birthday;
            this.Town = town;
            this.OtherInfo = otherInfo;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthdayDate { get; set; }

        public string OtherInfo { get; set; }

        public Town Town { get; set; }

        /// <summary>
        /// Compare two students according their birthdays.
        /// </summary>
        /// <param name="student">The student to be compared to</param>
        /// <returns>Returns true if the current instance of the student is older.</returns>
        public bool IsOlderThan(Student student)
        {
            return this.BirthdayDate.CompareTo(student.BirthdayDate) < 0;
        }
    }
}
