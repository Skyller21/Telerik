using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TheCatAteIt
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        string condition = "";

        List<int> numsList = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        string str1 = "0123456789";



        SortedSet<int> hashNums = new SortedSet<int>();

        for (int i = 0; i < n; i++)
        {
            string[] lineList = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            condition = lineList[2];
            string num = "";
            if (condition == "before")
            {
                int indexFirst = Array.IndexOf(numsList.ToArray(), int.Parse(lineList[0]));
                int indexSecond = Array.IndexOf(numsList.ToArray(), int.Parse(lineList[3]));
                //if (!(hashNums.Contains(int.Parse(lineList[0])) && hashNums.Contains(int.Parse(lineList[3]))))
                //{


                    if (indexFirst > indexSecond)
                    {
                        numsList =  Swap(numsList, indexFirst, indexSecond);
                    }
                //}
                hashNums.Add(int.Parse(lineList[0]));
                hashNums.Add(int.Parse(lineList[3]));
            }
            else
            {
                int indexFirst = Array.IndexOf(numsList, int.Parse(lineList[3]));
                int indexSecond = Array.IndexOf(numsList, int.Parse(lineList[0]));
                //if (!(hashNums.Contains(int.Parse(lineList[0])) && hashNums.Contains(int.Parse(lineList[3]))))
                //{
                    if (indexFirst > indexSecond)
                    {
                        numsList = Swap(numsList, indexFirst, indexSecond);
                    }
                //}

                hashNums.Add(int.Parse(lineList[3]));
                hashNums.Add(int.Parse(lineList[0]));
            }


        }



        for (int i = 0; i < numsList.Length; i++)
        {
            if (hashNums.Contains(numsList[i]))
            {
                Console.Write(numsList[i]);
            }

        }
        //Console.WriteLine();



        //StringBuilder str = new StringBuilder();
        //foreach (var item in hashNums)
        //{
        //    str.Append(item);
        //}

        //StringBuilder test = new StringBuilder();
        //for (int i = 0; i < str.Length; i++)
        //{
        //    if (!test.ToString().Contains(str[i]))
        //    {
        //        test.Append(str[i]);
        //    }
        //}

        //Console.WriteLine(test);
    }

    static int[] Swap(int[] arr, int index1, int index2)
    {
        int temp = 0;
        temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;

        return arr;
    }
}
