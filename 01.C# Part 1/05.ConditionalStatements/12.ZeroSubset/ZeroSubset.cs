using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ZeroSubset
{
    static void Main()
    {
        Console.WriteLine("Enter the length of the list");
        int listLength = int.Parse(Console.ReadLine());

        List<int> initialList = new List<int>();                //Create new list

        Console.WriteLine("Enter list elements");
        for (int i = 0; i < listLength; i++)                    //Fill the list with elements
        {
            initialList.Add(int.Parse(Console.ReadLine()));
        }

        GetAllPermutations(initialList);                        //Invoke the method to get all permutations

        Main();
    }

    static void GetAllPermutations(List<int> myList)            //Method to get all permutations in given list
    {
        double length = Math.Pow(2,myList.Count);               //All possible permutations in list are 2^n ('n' is the list length) 
        int sum = 0;                                            
        List<int> tempList = new List<int>();                   //Create temporary list to see if the sum is zero
        int countSubsets = 0;

        for (int i = 1; i <= length; i++)
        {
            sum = 0;
            string binNumber = Convert.ToString(i, 2).PadLeft(myList.Count, '0');   //Convert i-th member of the permutation to binary number
                                                                                    //The binary number helps us to make the combinations    
            for (int j = 0; j < binNumber.Length; j++)                              //because 1 in binary is 00001, 2 is 00010, 3 is 00011     
            {                                                                       //... 15 is 01111 and so on. The 1 in the binary number will represent the             
                if (binNumber[j] == '1')                                            //element to be included in the temporary list.        
                {
                    sum = sum + myList[j];                                          //If the element in the binary is '1' we include it and 
                    tempList.Add(myList[j]);                                        //add it to the sum. 
                }
            }
            if (sum == 0)                                                           //If the sum is zero we increase the countSubsets variable with 1
            {                                                                           
                countSubsets++;
                for (int k = 0; k < tempList.Count; k++)
                {
                    Console.Write(tempList[k] + " ");                               //We print the list on the console
                }
                Console.WriteLine();
            }
            
            tempList.Clear();
            
        }
        if (countSubsets == 0)                                                      //If the variable countSubsets is still 0(zero) we print 
        {                                                                           //"No zero subset" on the console.    
            Console.WriteLine("No zero subset");
        }
    }

}
