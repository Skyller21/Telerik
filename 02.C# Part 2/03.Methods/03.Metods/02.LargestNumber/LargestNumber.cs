using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LargestNumber
{
    class LargestNumber
    {
        static void Main(string[] args)
        {
            int[] nums = new int[3];
            for (int i = 1; i < 4; i++)
            {
                Console.Write("Enter number {0}: ",i);
                nums[i-1] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The largest number of [{0},{1},{2}] is: {3}",nums[0],nums[1],nums[2],
                                                                            GetMax(GetMax(nums[0], nums[1]), GetMax(nums[1], nums[2])));
            
        }

        static int GetMax(int a, int b)
        {
            if (a >= b)
            {
                return a;
            }
            else
            {
                return b;
            }
        } 
    }
}
