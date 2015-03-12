using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EmployeeData
{
    static void Main(string[] args)
    {
        string firstName = "Master";
        string lastName = "MasterOFF";
        byte age = 27;
        char gender = 'm';
        string idNumber = "6501020304";
        string employeeNumber = "27560000";

        Console.WriteLine("{0}{1} {2}\n\r{3}{4}\n\r{5}{6}\n\r{7}{8}\n\r{9}{10}",
                          "Name: ", firstName, lastName, "Age: ", age, "Gender: ", gender, "ID Number: ", idNumber, "Employee Number: ", employeeNumber);

    }
}

