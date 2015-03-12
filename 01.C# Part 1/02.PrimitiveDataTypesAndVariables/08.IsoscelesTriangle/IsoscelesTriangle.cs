using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class IsoscelesTriangle
{
    static void Main(string[] args)
    {
        char copyRight = '\x00A9';

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (i == 0 && j == 3)
                {
                    Console.Write(copyRight);
                }
                else if(i == 1 && (j==2 || j==4))
                {
                    Console.Write(copyRight);
                }
                else if (i == 2 && (j == 1 || j == 5))
                {
                    Console.Write(copyRight);
                }
                else if (i == 3 && j % 2 == 0)
                {
                    Console.Write(copyRight);
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }
}

