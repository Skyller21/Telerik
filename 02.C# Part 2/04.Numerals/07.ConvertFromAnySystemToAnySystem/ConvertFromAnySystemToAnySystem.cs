using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ConvertFromAnySystemToAnySystem
{
    static int s;
    static int d;
    static string number;
    static int revNumber;

    static void Main()
    {
        
        Console.WriteLine("Enter the base of the number to convert. Must be >=2 and <=16");
        s = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter the base of the system to convert to. Must be >=2 and <=16");
        d = int.Parse(Console.ReadLine());
        CheckInput();
        
        

        Console.WriteLine("Enter the number to convert:\nBe careful with the input, because the it is not validated!!!\nIf you wish to convert from based 3 system the input should be only from 0, 1 or 2\nExample: 121(base 3) = 16(base 10) = 10(base 16)");
        number = Console.ReadLine().ToUpper();
        Console.WriteLine(FromSBasedToDec());
        Console.WriteLine(FromDecToDBased());

    }

    static void CheckInput()
    {
        if (s < 2 || s > 16 ||d<2 ||d>16)
        {
            Console.WriteLine("Wrong Input!!!");
            Console.WriteLine();
            Main();
        }
        Console.WriteLine();
    }
 
    static int FromSBasedToDec()
    {
        revNumber = 0;
        List<char> listNum = number.ToList();
        listNum.Reverse();
        for (int i = 0; i < listNum.Count; i++)
        {
            if (listNum[i] < 60)
            {
                revNumber = revNumber + (listNum[i] - 48) * (int)Math.Pow(s, i);
            }
            else
            {
                revNumber = revNumber + (listNum[i] - 55) * (int)Math.Pow(s, i);
            }
        }
        return revNumber;
    }

    static StringBuilder FromDecToDBased()
    {
        StringBuilder finalNum = null;
        List<char> finalList = new List<char>();
        while (revNumber > 0)
        {

            if (revNumber % d < 10)
            {
                finalList.Add((char)(revNumber % d + 48));
            }
            else
            {
                finalList.Add((char)(revNumber % d + 55));
            }
            revNumber = revNumber / d;
        }
        for (int i =finalList.Count()-1; i >=0; i--)
        {
            Console.Write(finalList[i]);
        }
        return finalNum;
    }
}

