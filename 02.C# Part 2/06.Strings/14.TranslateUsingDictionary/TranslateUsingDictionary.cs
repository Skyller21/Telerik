using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TranslateUsingDictionary
{
    static void Main(string[] args)
    {
        Dictionary<string, string> dict = new Dictionary<string, string>(){
                {".NET","platform for applications from Microsoft"},
                {"CLR","managed execution environment for .NET"},
                { "namespace","hierarchical organization of classes"}
            };

        Console.WriteLine("Enter a word from the dictionary to translate\n\rWords in the dictinary are: .NET, CLR, namespace");
        string wordToTranslate = Console.ReadLine();


        if (dict.ContainsKey(wordToTranslate))
        {
            Console.WriteLine("{0} - {1}", wordToTranslate, dict[wordToTranslate]);
        }
        else
        {
            Console.WriteLine("The word \"{0}\" is not in the dictionary", wordToTranslate);
        }
    }
}

