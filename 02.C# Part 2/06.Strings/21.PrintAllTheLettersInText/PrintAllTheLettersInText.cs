using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class PrintAllTheLettersInText
{
    static void Main()
    {
        string text = "Client Services If you have complaints or suggestions regarding Telerik services, please contact us at client-service@telerik-ltd.co.uk until 02.03.2012. For Sitefinity, please e-mail: clientservice@sitefinity.com until 06.06.2012. After 12.21.2012 there will be blood";

        Dictionary<char, int> letters = new Dictionary<char, int>();
        

        foreach (var symbol in text)
        {
            if (Char.IsLetter(symbol))
            {

                if (letters.ContainsKey(symbol))
                {
                    letters[symbol]++;
                }
                else
                {
                    letters.Add(symbol, 1);
                }
            }
        }
        var ordered = letters.OrderByDescending(x => x.Value);
        Console.WriteLine("{0}\t{1}","Letter","Counts");
        foreach (var letter in ordered)
        {
            Console.WriteLine("{0,4}{1,8}", letter.Key, letter.Value);
            Console.WriteLine(new string('-',15));
        }

        

    }
}

