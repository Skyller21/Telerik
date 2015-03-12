using System;

class DeclareEmployeeData
{
    static void Main()
    {
        /*
         Problem 10. Employee Data
            A marketing company wants to keep record of its employees. Each record would have the following characteristics:
                First name
                Last name
                Age (0...100)
                Gender (m or f)
                Personal ID number (e.g. 8306112507)
            Unique employee number (27560000…27569999)
            Declare the variables needed to keep the information for a single employee using appropriate primitive data types. 
            Use descriptive names. Print the data at the console.
         */
        string firstName = "Teodor";
        string lastName = "Nikolov";
        byte? age = null;           
        char gender = 'm';
        string id = "12345A";
        int uniqueNumber = 27560006;

        age = 23;

        Console.WriteLine("Employee: " + firstName + " " + lastName +
            "\nAge: " + age + "\nGender: " + gender + "\nID: " + id + 
            "\nUnique Employee Number: " + uniqueNumber);

    }
}

