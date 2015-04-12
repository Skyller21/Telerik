using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem
{
    public class Group
    {
        private int groupNumber;
        private string department;
        

        public int GroupNumber
        {
            get { return groupNumber; }
            private set
            {
            if(value<=0)
                throw new ArgumentNullException("The group number must be greater than 0");
                groupNumber = value;
            }


        }

        public string Department
        {
            get { return department; }
            private set
            {
                if(String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("The deparment name must not be empty");
                department = value;
            }
        }

        public Group()
        {
            
        }
        public Group(int groupNumber, string department)
        {
            this.GroupNumber = groupNumber;
            this.Department = department;
        }
    }
}
