using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndWorkers
{
    class ProgramHumans
    {
        static void Main(string[] args)
        {
            Student student = new Student("Batman","Batmanov",5);
           

            Worker worker = new Worker("Darth","Vader",250M);

            Console.WriteLine("Money per hour");
            Console.WriteLine(worker.CalculateMoneyPerHour());

            List<Human> humans = new List<Human>();
            
            humans.Add(worker);
            humans.Add(student);
            foreach (var human in humans)
            {
                human.RepresentSelf();
            }
        }
    }
}
