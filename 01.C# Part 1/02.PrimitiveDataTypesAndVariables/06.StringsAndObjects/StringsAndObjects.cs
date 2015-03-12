using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StringsAndObjects
{
    static void Main(string[] args)
    {
        string salute = "Hello";
        string who = "World";
        object saluteWho = salute + " " + who;
        string saluteWhoString = (string)saluteWho;

        StringBuilder str = new StringBuilder();  //You could try the StringBuilder class. It is very powerful and way
                                                  //more effective and fast. Just play with it a little bit. :)
        str.Append(salute);
        str.Append(" ");
        str.Append(who);

        Console.WriteLine(saluteWhoString);
        Console.WriteLine(str);
    }
}

