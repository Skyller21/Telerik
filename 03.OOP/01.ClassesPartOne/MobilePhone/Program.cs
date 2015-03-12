using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    class Program
    {
        static void Main(string[] args)

        {


            GSM gsm = new GSM("", "", "", 3, new Display(5, "b/w"), new Battery(),new List<Call>());
            Battery battery = new Battery("NK5-P", 72, 16);
            Display display = new Display(4.7, "16M");

            //Print the GSM
            Console.WriteLine("\nGSM\n" + new string('-', 40));
            Console.WriteLine(gsm.ToString());

            //Print the static property IPhone4S
            Console.WriteLine("\niPhone static property\n"+new string('-',40));
            Console.WriteLine(GSM.IPhone4S.ToString());

            Console.WriteLine("\nCreate list of phones\n" + new string('-', 40));
            GSMTest.CreateListOfPhones();


            Console.WriteLine("\nTest Call history\n" + new string('-', 40));
            GSMCallHistoryTest.CreateCallHistory();

            
            
        }
    }
}
