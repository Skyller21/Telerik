using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExchangeVariableValues
{
    static void Main(string[] args)
    {
        int numOne = 5;
        int numTwo = 10;
        int tempValue;

        Console.WriteLine("Number one and number two before exchange values: {0} and {1}", numOne, numTwo);

        tempValue = numOne;
        numOne = numTwo;
        numTwo = tempValue;

        Console.WriteLine("Number one and number two after exchange values: {0} and {1}", numOne, numTwo);
    }
}

