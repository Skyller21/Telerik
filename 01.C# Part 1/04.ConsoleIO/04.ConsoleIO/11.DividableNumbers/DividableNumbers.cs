using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DividableNumbers
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter start number:");
        int start = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter end number:");
        int end = int.Parse(Console.ReadLine());
        int counter = 0;
        List<int> list = new List<int>();

        Console.WriteLine(new string('-',40));
        for (int i = start; i <= end; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
                list.Add(i);
            }
        }

        Console.WriteLine("There are {0} numbers divisable on 5 in [{1}, {2}]",counter,start,end);
        Console.WriteLine("The numbers are:");

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }

    }
}
