namespace _01.Students
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            // C#6 synthax
            return $"{this.FirstName} {this.LastName}";
            //return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
