using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class HexToDecimal
{
    static void Main()
    {
        List<char> myList = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        Console.WriteLine("Enter the number in hexadecimal");
        string hex = Console.ReadLine();
        ulong result = 0;
        int power = hex.Length - 1;

        //Use this link or check google https://www.wisc-online.com/learn/formal-science/mathematics/tmh6207/an-algorithm-for-converting-a-hexadecimal-number-to-a-decimal-number

        for (int i = 0; i < hex.Length; i++)
        {
            for (int j = 0; j < myList.Count; j++)
            {
                if (hex[i].ToString().ToUpper() == myList[j].ToString())
                {
                    result = result + (ulong)j*(ulong)Math.Pow(16, power);
                }
            }
            power--;
        }
        Console.WriteLine("The number in hexadecimal representation is: {0}\nThe number in     decimal representation is: {1}",hex,result);
    }
}

