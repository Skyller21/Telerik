using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class IntDoubleString
{
    static void Main()
    {
        Console.WriteLine("Please choose a type:\n1 --> int\n2 --> double\n3 --> string");
        string choise = Console.ReadLine();
        int numberInt;
        double numberDouble;
        string str = null;

        switch (choise)
        {
            case "1": Console.WriteLine("Plese enter an integer:");
                numberInt = int.Parse(Console.ReadLine()) + 1;
                Console.WriteLine(numberInt);
                break;
            case "2": Console.WriteLine("Plese enter a double:");
                numberDouble = double.Parse(Console.ReadLine()) + 1;
                Console.WriteLine(numberDouble);
                break;
            case "3": Console.WriteLine("Plese enter a string:");
                str = Console.ReadLine() + "*";
                Console.WriteLine(str);
                break;
            default: Console.WriteLine("Invalid choise"); Main(); break;
        }
    }
}

