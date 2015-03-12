using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class PrintDeckOfCards
{
    static void Main()
    {
        List<string> cards = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" }; //List with cards
        List<char> suits = new List<char>() {'\u2663','\u2666','\u2665','\u2660'};  //List with suits with their Unicode values

        Console.WriteLine("The deck of 52 cards is\n-----------------------");

        for (int i = 0; i < cards.Count; i++)            //For loop in for loop. Combines cards with suits.
        {
            for (int j = 0; j < suits.Count; j++)       //If you are unable to understand the logic, debug the code with F10.
            {
                if (i != 8)
                {
                    Console.Write(cards[i].PadLeft(2) + suits[j] + " ");
                }
                else
                {
                    Console.Write(cards[i] + suits[j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}

