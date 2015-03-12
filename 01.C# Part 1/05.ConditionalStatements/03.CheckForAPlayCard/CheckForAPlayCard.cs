using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CheckForAPlayCard
{
    static void Main(string[] args)
    {
        List<string> playCards = new List<string>(){"2","3","4","5","6","7","8","9","10","J","Q","K","A"};
        Console.WriteLine("The play cards are\n---------------------");
        for (int i = 0; i < playCards.Count; i++)
        {
            Console.WriteLine(playCards[i]);
        }

        Console.WriteLine("Enter a play card");
        string card = Console.ReadLine();

        if (playCards.Contains(card))
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }


    }
}

