using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndWorkers
{
    public class Worker : Human
    {
        private decimal weekSalary;
        public uint WorkHoursPerDay { get; private set; }

        private int workDaysPerWeek;



        public Worker(string firstName, string lastName)
            : base(firstName, lastName)
        {

        }

        public Worker(string firstName, string lastName, decimal weekSalary,uint workHoursPerDay = 8,int workDaysPerWeek = 5)
            : base(firstName, lastName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
            this.WorkDaysPerWeek = workDaysPerWeek;
            this.WeekSalary = weekSalary;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("The salary must be positive number");
                this.weekSalary = value;
            }
        }

        public int WorkDaysPerWeek
        {
            get { return this.workDaysPerWeek; }
            private set
            {
                if(value<=0 || value >7)
                    throw new ArgumentOutOfRangeException("The workdays per week must be in the range [1,7]");
                this.workDaysPerWeek = value;
            }
        }

        public decimal CalculateMoneyPerHour()
        {
            decimal moneyPerHour = this.WeekSalary/this.WorkDaysPerWeek/this.WorkHoursPerDay;
            return moneyPerHour;
        }
    }
}
