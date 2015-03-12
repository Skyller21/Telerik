using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CurrentDateAndTime
{
    static void Main(string[] args)
    {
        Console.WriteLine("The date is: {0}\nThe time is: {1}\n",DateTime.Now.ToLongDateString(),DateTime.Now.ToLongTimeString());
    }
}

