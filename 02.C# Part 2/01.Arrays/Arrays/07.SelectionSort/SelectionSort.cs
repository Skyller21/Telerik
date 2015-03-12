using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SelectionSort
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the size of the array");
        int size = int.Parse(Console.ReadLine());
        int temp = 0;

        List<int> myList = new List<int>();
        Console.WriteLine("Enter the {0} elements of the array", size);

        for (int i = 0; i < size; i++)
        {
            myList.Add(int.Parse(Console.ReadLine()));
        }
        

        for (int i = 0; i < myList.Count; i++)
        {
            temp = myList[i];
            for (int j = i; j < myList.Count; j++)
            {
                if (myList[j]<temp)
                {
                    temp = myList[j];
                    myList[j] = myList[i];
                    myList[i] = temp;
                }
            }
        }
        for (int i = 0; i < myList.Count; i++)
        {
            Console.Write(myList[i]+" ");
        }
        Console.WriteLine();
    }
}
