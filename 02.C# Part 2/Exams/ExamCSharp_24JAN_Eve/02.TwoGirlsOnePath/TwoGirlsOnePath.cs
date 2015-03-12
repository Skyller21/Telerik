using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.TwoGirlsOnePath
{
    class TwoGirlsOnePath
    {
        static void Main(string[] args)
        {
            string[] pathString = Console.ReadLine().Split(' ');
            BigInteger[] path = new BigInteger[pathString.Length];

            BigInteger mollyFlowers = 0;
            BigInteger dollyFlowers = 0;

            for (int i = 0; i < pathString.Length; i++)
            {
                path[i] = BigInteger.Parse(pathString[i]);
            }
            string girl = "";

            int m = 0;
            int d = path.Length - 1;


            while (true)
            
            {
                BigInteger fM = 0;
                BigInteger fD = 0;
                BigInteger jumpM = 0;
                BigInteger jumpD = 0;
                //if (d == m)
                //{
                //    jumpM = path[m];
                //    jumpD = path[d];
                //    fM = path[m] / 2;
                //    fD = path[d] / 2;
                //    if (path[m] % 2 == 0)
                //    {
                //        path[m] = 0;

                //    }
                //    else
                //    {
                //        path[m] = 1;
                //    }
                //}
                //else
                //{

                    jumpM = path[m];
                    jumpD = path[d];

                    fM = path[m];
                    fD = path[d];

                    path[m] = 0;
                    path[d] = 0;
                //}



                    mollyFlowers += fM;
                    dollyFlowers += fD;
                

                d = (int)(d - jumpD) % path.Length;

                m = (int)(jumpM + m)%path.Length;

                if (d < 0)
                {
                    d = path.Length + d;
                }

                

                

                if (path[m] == 0 || path[d] == 0)
                {
                    if (path[m] == 0 && path[d] == 0)
                    {
                        girl = "Draw";
                        
                    }
                    
                    else if (path[m] == 0)
                    {
                        girl = "Dolly";

                    }
                    else if(path[d]==0)
                    {
                        girl = "Molly";

                    }
                    dollyFlowers += path[d];
                    mollyFlowers += path[m];
                    break;
                }
            } 

            Console.WriteLine(girl);
            Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);

        }
    }
}
