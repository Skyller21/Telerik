using System;
class PrintSequence
{
    static void Main()
    {
        Console.Write("Print first ten numbers: ");
        for (int i = 2; i < 12; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(i + ", ");
            }
            else
                Console.Write(i * (-1) + ", ");
        }
        Console.WriteLine("\n");
    }
}