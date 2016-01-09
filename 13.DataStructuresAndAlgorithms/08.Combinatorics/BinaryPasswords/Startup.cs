namespace BinaryPasswords
{
    using System;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();

            var count = str.Count(s => s == '*');

            if (count != 0)
            {

                var dec = Convert.ToInt64(new string('1', count), 2);
                Console.WriteLine(dec + 1);
            }
            else
            {
                Console.WriteLine(1);
            }
        }
    }
}
