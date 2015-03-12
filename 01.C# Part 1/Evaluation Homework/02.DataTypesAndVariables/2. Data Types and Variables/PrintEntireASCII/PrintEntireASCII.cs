using System;

class PrintEntireASCII
{
    static void Main()
    {
        Console.Write("Decimal".PadRight(10));
        Console.Write("ASCII".PadRight(10));
        Console.Write("Hex".PadRight(10));
        Console.WriteLine();

        int min = 0;
        int max = 256;
        for (int i = min; i < max; i++)
        {
            // Get ascii character.
            char c = (char)i;

            // Get display string.
            string display = string.Empty;
            if (char.IsWhiteSpace(c))
            {
                display = c.ToString();
                switch (c)
                {
                    case '\t':
                        display = "\\t";
                        break;
                    case ' ':
                        display = "space";
                        break;
                    case '\n':
                        display = "\\n";
                        break;
                    case '\r':
                        display = "\\r";
                        break;
                    case '\v':
                        display = "\\v";
                        break;
                    case '\f':
                        display = "\\f";
                        break;
                }
            }
            else if (char.IsControl(c))
            {
                display = "control";
            }
            else
            {
                display = c.ToString();
            }
            // Write table row.
            Console.Write(i.ToString().PadRight(10));
            Console.Write(display.PadRight(10));
            Console.Write(i.ToString("X2"));
            Console.WriteLine();
        }
    }
}
