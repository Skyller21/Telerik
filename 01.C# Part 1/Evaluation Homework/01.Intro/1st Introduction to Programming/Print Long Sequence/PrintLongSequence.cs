using System;

class PrintLongSequence
{
    static void Main()
    {
        for (int i = 2; i < 1002; i += 2)
        {
            Console.Write("{0}, ", i);
            Console.Write("{0}, ", -i - 1);
        }
    }
}
