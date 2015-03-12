using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CalculateSumOfNumbersInString
{
    static void Main()
    {
        string sequence = "43 68 9 23 318";
        string[] arraySequence = sequence.Split();
        List<int> listSum = new List<int>();
        for (int i = 0; i < arraySequence.Length; i++)
        {
            listSum.Add(int.Parse(arraySequence[i]));
        }
        Console.WriteLine("The array sequence is: {0}",sequence);
        Console.WriteLine("The sum of the sequence is: {0}", listSum.Sum());
    }
}

