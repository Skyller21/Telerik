using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class QuotesInStrings
{
    static void Main(string[] args)
    {
        string stringOne = "The \"use\" of quotations causes difficulties.";
        string stringTwo = @"The ""use"" of quotations causes difficulties.";

        Console.WriteLine("Quotes escaped with \"\\\": {0}", stringOne);
        Console.WriteLine("Quotes escaped with \"@\": {0}", stringTwo);
    }
}

