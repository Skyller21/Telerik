using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    class GSMCallHistoryTest
    {
        
        public static void CreateCallHistory()
        {
            GSM testgsm = new GSM();

            Call callOne = new Call(new DateTime(2015, 02, 03), new DateTime(2015, 02, 03, 14, 05, 25), "private number", 23);
            Call callTwo = new Call(new DateTime(2015, 02, 03), new DateTime(2015, 02, 03, 17, 14, 38), "private number", 701);
            Call callThree = new Call(new DateTime(2015, 02, 04), new DateTime(2015, 02, 03, 10, 02, 45), "private number", 411);

            //Add few calls
            Console.WriteLine("Added few calls");
            testgsm.CallHistory.Add(callOne);
            testgsm.CallHistory.Add(callTwo);
            testgsm.CallHistory.Add(callThree);



            Console.WriteLine("Info"+new string('-',40));
            Console.WriteLine("Initial number of calls: {0}",testgsm.CallHistory.Count);
            Console.WriteLine("Price of the calls: " + testgsm.CalculateCallPrice());
            Console.WriteLine("Longest call: {0}", testgsm.FindLongestCall().Duration);

            Console.WriteLine("\nAdd a new call");
            testgsm.AddCall(new Call(new DateTime(2015, 02, 04), new DateTime(2015, 02, 03, 10, 33, 45), "private number", 806));
            Console.WriteLine("Info" + new string('-', 40));
            Console.WriteLine("Number of calls: {0}", testgsm.CallHistory.Count);
            Console.WriteLine("Price of the calls: " + testgsm.CalculateCallPrice());
            Console.WriteLine("Longest call: {0}", testgsm.FindLongestCall().Duration);

            //Delete longest call
            testgsm.DeleteCall(testgsm.CallHistory.IndexOf(testgsm.FindLongestCall()));
            Console.WriteLine("\nDelete longest call");
            Console.WriteLine("Info" + new string('-', 40));
            Console.WriteLine("Number of calls: {0}", testgsm.CallHistory.Count);
            Console.WriteLine("Price of the calls: " + testgsm.CalculateCallPrice());
            Console.WriteLine("Longest call: {0}", testgsm.FindLongestCall().Duration);

            Console.WriteLine("\nDelete all call history");
            testgsm.DeleteAllHistory();
            Console.WriteLine("Info" + new string('-', 40));
            Console.WriteLine("Number of calls: {0}", testgsm.CallHistory.Count);


            Console.WriteLine(testgsm.CallHistory.Count);

        }
    }
}
