using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ParseUrl
{
    static void Main()
    {
        Uri url = new Uri("http://www.devbg.org/forum/index.php");
        
        Console.WriteLine("The protocol is: {0}",url.Scheme);
        Console.WriteLine("The server is: {0}",url.Authority);
        Console.WriteLine("The resourse is: {0}",url.AbsolutePath);
    }
}

