namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Person : IPerson
    {
        public string Email { get;  set; }
        public string Name { get;  set; }
        
        public Person(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
        public void Walk()
        {
            Console.WriteLine(this.Name+" is walking");
        }



    }
}
