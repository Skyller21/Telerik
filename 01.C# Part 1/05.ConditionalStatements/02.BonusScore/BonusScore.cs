using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BonusScore
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input a score:");
        double score = double.Parse(Console.ReadLine());
        double bonusScore = 0;

        if (1 <= score & score <= 3)
        {
            bonusScore = score*10;
            Console.WriteLine("The score is: {0}\nThe bonus score is: {1}", score, bonusScore);
        }
        else if (4 <= score & score <= 6)
        {
            bonusScore = score*100;
            Console.WriteLine("The score is: {0}\nThe bonus score is: {1}", score, bonusScore);
        }
        else if (7 <= score & score <= 9)
        {
            bonusScore = score*1000;
            Console.WriteLine("The score is: {0}\nThe bonus score is: {1}", score, bonusScore);
        }
        else
        {
            Console.WriteLine("invalid score");
        }

        
    }
}

