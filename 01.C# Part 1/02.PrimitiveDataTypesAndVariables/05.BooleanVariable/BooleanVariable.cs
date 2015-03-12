using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BooleanVariable
{
    static void Main(string[] args)
    {
        bool isFemale = true; //All the embrions are females at first :)
        bool check = true;
        do
        {
            Console.WriteLine("You are male or female (insert 'm' for male or 'f' for female:" );
            string var = Console.ReadLine();
            if (var == "m" || var == "f")
            {
                check = true;
                if (var == "m")
                {
                    isFemale = false;
                }
                else
                {
                    isFemale = true;
                }
            }
            else
            {
                check = false;
            }
        } while (!check);

        Console.WriteLine("isFamale = {0}",isFemale);

    }
}

