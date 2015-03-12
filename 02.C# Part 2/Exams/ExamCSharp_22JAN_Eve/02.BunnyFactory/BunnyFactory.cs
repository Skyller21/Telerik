using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.BunnyFactory
{
    class BunnyFactory
    {
        static void Main(string[] args)
        {
            List<int> cages = new List<int>();

            string line = Console.ReadLine();
            while (line!="END")
            {
                cages.Add(int.Parse(line));
                line = Console.ReadLine();
            }
            
            
            int cycle = 1;

            if (cages.Count == 1)
            {
                Console.WriteLine(cages[0]);
            }

            else
            {

                while (true)
                {

                    if (cycle > cages.Count)
                    {
                        for (int i = 0; i < cages.Count; i++)
                        {
                            if (i != cages.Count - 1)
                            {
                                Console.Write(cages[i] + " ");
                            }
                            else
                            {
                                Console.WriteLine(cages[i]);
                            }

                        }
                        break;
                    }


                    int s = CalculateS(cycle, cages);
                    if (cycle + s > cages.Count - 1)
                    {
                        for (int i = 0; i < cages.Count; i++)
                        {
                            if (i != cages.Count - 1)
                            {
                                Console.Write(cages[i] + " ");
                            }
                            else
                            {
                                Console.WriteLine(cages[i]);
                            }

                        }
                        break;
                    }

                    int sum = Sum(s, cages, cycle);
                    BigInteger product = Product(s, cages, cycle);

                    //Make the new cages
                    string newCages = sum.ToString() + product.ToString() + ReturnUnusedCells(cycle, cages, s);

                    //Remove 1 and 0 from the new cages
                    newCages = Regex.Replace(newCages, "1|0", "");

                    //Clear old cages
                    cages.Clear();

                    //Fill the cages again
                    FillCages(cages, newCages);


                    //Cycle inreases
                    cycle++;


                }
            }
        }


        static int CalculateS(int cycle, List<int> cages)
        {
            int s = 0;
            for (int j = 0; j < cycle; j++)
            {
                s += cages[j];
            }
            return s;
        }
        static int Sum(int s, List<int> cages, int cycle)
        {
            int sum = 0;
            for (int i = cycle; i <s+cycle ; i++)
            {
                sum += cages[i];
            }
            return sum;
        }

        static BigInteger Product(int s, List<int> cages, int cycle)
        {
            BigInteger product = 1;
            for (int i = cycle; i < s+cycle; i++)
            {
                product *= cages[i];
            }
            return product;
        }


        static string ReturnUnusedCells(int cycle, List<int> cages, int s)
        {
            string str = "";
            for (int i = cycle+s; i < cages.Count; i++)
            {
                str += cages[i];
            }
            return str;
        }

        static void FillCages(List<int> cages, string newCagesStr)
        {
            for (int i = 0; i < newCagesStr.Length; i++)
            {
                cages.Add(int.Parse(newCagesStr[i].ToString()));
            }
        }

    }
}
