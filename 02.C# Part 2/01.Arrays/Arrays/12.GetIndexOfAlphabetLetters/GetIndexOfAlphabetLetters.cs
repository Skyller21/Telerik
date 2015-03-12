using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GetIndexOfAlphabetLetters
{
    static void Main(string[] args)
    {
        List<char> alphabet = new List<char>();
        alphabet.Add('\u0020');
        for (int i = 65; i < 91; i++)
        {
            alphabet.Add((char)i);
        }

        Console.WriteLine("Enter a string");

        string str = Console.ReadLine();

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] > 64 & str[i] < 91 | str[i] > 96 & str[i] < 123)
            {
                for (int j = 1; j < alphabet.Count; j++)
                {
                    if (str[i].ToString().ToUpper()==alphabet[j].ToString().ToUpper())
                    {
                        Console.WriteLine("Character {0} = index[{1}]",str[i],j);
                    }
                }
            }
        }
    }
}

