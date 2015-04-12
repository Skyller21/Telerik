using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    public class Discipline
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if(String.IsNullOrEmpty(value)||String.IsNullOrWhiteSpace(value)||value.Length<2)
                    throw  new ArgumentNullException("#######The discipline name cannot be empty and must be at least two characters long");
                this.name = value;
            }
        }

        public int NumberOfLectures
        {
            get { return this.numberOfLectures; }
            private set
            {
                if(value< 0)
                    throw new ArgumentOutOfRangeException("######The number of lectures mustnot be nagative");
                this.numberOfLectures = value;
            }
        }

        public int NumberOfExercices
        {
            get { return numberOfExercises; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("######The number of exercises must not be negative");
                numberOfExercises = value;
            }
        }

        public Discipline(string name, int numOfLectures, int numOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numOfLectures;
            this.NumberOfExercices = numOfExercises;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
