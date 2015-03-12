using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class BracketsAgain
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        string method = "";
        List<string> list = new List<string>();

        List<string> listMethodsIn = new List<string>();
        List<string> tempList = new List<string>();
        Regex regex = new Regex("(static[\\s]+[^\\s]+[\\s]+)([A-Za-z_0-9]+)");
        Regex regexMethods = new Regex("(\\.{0,1}[A-Z_]{1}[A-Za-z_0-9]+)[\\s]*([(]{1})");
        string line = "";

        List<int> count = new List<int>();
        int countTemp = 0;
        for (int i = 0; i < n; i++)
        {
            line = Console.ReadLine();
            Match m = regex.Match(line);
            if (i == n - 1)
            {
                string str = "";
                str = string.Join(", ", tempList.ToArray());
                listMethodsIn.Add(str);
                count.Add(countTemp);
                countTemp = 0;
            }
            if (m.Success)
            {


                count.Add(countTemp);
                countTemp = 0;
                string str = "";
               
                str = string.Join(", ", tempList.ToArray());
                //tempList.Clear();
                listMethodsIn.Add(str);

                method = m.Groups[2].ToString();
                list.Add(method);
                line = Console.ReadLine();
                i++;
                tempList.Clear();

            }

            Match mMethod = regexMethods.Match(line);

            if (regexMethods.Matches(line).Count > 1)
            {
                foreach (var item in regexMethods.Matches(line))
                {
                    if (item.ToString()[0]=='.')
                    {
                        tempList.Add(item.ToString().Substring(1,item.ToString().Length - 2));
                        countTemp++;

                    }
                    else{
                        tempList.Add(item.ToString().Substring(0,item.ToString().Length - 1));
                        countTemp++;
                    }
                    
                }
            }


            else if (mMethod.Success)
            {
                if (mMethod.Groups[0].ToString()[0]=='.')
                {
                    tempList.Add(mMethod.Groups[0].ToString().Substring(1, mMethod.Groups[0].ToString().Length - 2));
                    countTemp++;
                }
                else
                {
                    tempList.Add(mMethod.Groups[0].ToString().Substring(0, mMethod.Groups[0].ToString().Length - 1));
                    countTemp++;
                }
                
            }

        }


        for (int i = 0; i < list.Count; i++)
        {
            if (listMethodsIn[i+1].Length<2)
            {
                Console.WriteLine("{0} -> {1}", list[i], "None");
            }
            else
            {

           
            Console.WriteLine("{0} -> {1} -> {2}", list[i],count[i+1] ,listMethodsIn[i + 1]);
            }
            //Console.WriteLine();
            //foreach (var item in listMethodsIn[i])
            //{
            //    Console.Write(item+" ");
            //}
            //Console.WriteLine();

        }


    }
}
