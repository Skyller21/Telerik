using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanCreator
{
    public class Human
    {
        private string name;
        private Gender gender;
        private int age;

        public Human()
        {
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < 1 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("The age must be in range [0,120]");
                }
                this.age = value;
            }
        }

        public Gender Gender { get; private set; }
        public static Human MakeHuman(int age)
        {
            Human newHuman = new Human();
            newHuman.Age = age;
            if (age % 2 == 0)
            {
                newHuman.Name = "Alpha Male";
                newHuman.Gender = Gender.AlphaMale;
            }
            else
            {
                newHuman.Name = "The Chick";
                newHuman.Gender = Gender.UltraBabe;
            }
            return newHuman;
        }
    }
}
