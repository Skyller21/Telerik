using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace T4Template
{
    class Program
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            Person person = new Person("Pesho", "Peshev", 25, "Sofia");
            Console.WriteLine(person.FirstName);

            XmlConfigurator.Configure();
            Log.Debug(person.FirstName);
        }
    }
}
