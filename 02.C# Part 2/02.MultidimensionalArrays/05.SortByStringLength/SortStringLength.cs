using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _05.SortByStringLength
{
    public static class MyExtensionMethods
    {
        public static string[] SortStringArrayByLength(this string[] str)
        {
            str = str.OrderBy(x=>x.Length).ThenBy(x=>x).ToArray();

            return str;
        }
    }
    class SortStringLength
    {
        static void Main(string[] args)
        {
            string[] strArray = { "Hey", "Joe", "where", "you", "goin'", "with", "that", "gun", "of", "your", "hand" };

            
            strArray = strArray.SortStringArrayByLength();

            for (int i = 0; i < strArray.Length; i++)
            {
                Console.WriteLine(strArray[i]);
            }
        }
    }
}
