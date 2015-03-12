using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.TextToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int module = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            text = text.ToLower();
            char symbol = text[0];
            int index = 0;
            long sum = 0;

            while (symbol!='@')
            {
                if (symbol>=97 && symbol<=122){
                    sum+=symbol-97;
                }
		        else if(symbol>=48 && symbol<=57){
                    sum *=symbol-48;
                }
                else{
                    sum = sum%module;
                }
                index++;
                symbol = text[index];
	
            }

            Console.WriteLine(sum);
        }
    }
}
