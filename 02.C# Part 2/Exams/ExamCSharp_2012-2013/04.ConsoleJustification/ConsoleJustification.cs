using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.ConsoleJustification
{
    class ConsoleJustification
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int maxLength = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Regex.Split(Console.ReadLine(), "\\s+");

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] != string.Empty)
                    {
                        list.Add(line[j]);
                    }
                }
            }

            List<string> theList = BuildLine(list);

            //foreach (var item in theList)
            //{
            //    Console.WriteLine(item);
            //}


            AddSpaces(theList, maxLength);

        }

        static List<string> BuildLine(List<string> list)
        {
            List<string> theList = new List<string>();
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (str.Length + list[i].Length + 1 <= 20)
                {
                    str.Append(list[i]);
                    str.Append(" ");
                    if (i == list.Count - 1)
                    {
                        theList.Add(list[i].Trim());
                    }
                }
                else if (str.Length + list[i].Length == 20)
                {
                    str.Append(list[i]);
                    if (i == list.Count - 1)
                    {
                        theList.Add(list[i].Trim());
                    }
                }

                else
                {
                    i = i - 1;
                    theList.Add(str.ToString().Trim());
                    str.Clear();
                }


            }
            return theList;
        }

        static void AddSpaces(List<string> theList, int maxLength)
        {
            foreach (var item in theList)
            {
                int spaces = maxLength - item.Length;
                string[] p = item.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int spacesExist = p.Length - 1;
                if (spaces > 0 && spacesExist > 0)
                {
                    int leftSpaces = spaces % spacesExist;
                    int addedSpaces = (spaces / spacesExist)+1;

                    string spaceNew = new string(' ',addedSpaces);
                    string final = string.Join(spaceNew, p);
                    final = final + new string(' ', leftSpaces);
                    Console.WriteLine(final);
                }
                else
                {
                    string s = new string(' ', spaces);
                    Console.WriteLine(item+s);
                }
                
            }
        }
    }
}
