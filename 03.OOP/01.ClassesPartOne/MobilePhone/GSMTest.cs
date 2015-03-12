using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class GSMTest
    {
        

        public static void CreateListOfPhones()
        {
            List<GSM> phoneList = new List<GSM>();

            GSM gsmOne = new GSM("Nokia", "с фенерче", "Майор Костов", 50, new Display(2.0, "b/w"), new Battery(),new List<Call>());
            GSM gsmTwo = new GSM("айфон", "новия", "чорбаджия", 1500, new Display(), new Battery(), new List<Call>());
            GSM gsmThree = new GSM("LG", "с капаче", "Батман", 200, new Display(), new Battery(), new List<Call>());

            phoneList.Add(gsmOne);
            phoneList.Add(gsmTwo);
            phoneList.Add(gsmThree);

            foreach (var phone in phoneList)
            {
                Console.WriteLine(phone.ToString());
                Console.WriteLine(new string('-', 40));
            }

            

        }
    }
}

