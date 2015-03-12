using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class ExtractEmail
{
    static void Main(string[] args)
    {

        string text = "Client Services If you have complaints or suggestions regarding Telerik services, please contact us at client-service@telerik-ltd.co.uk. For Sitefinity, please e-mail: clientservice@sitefinity.com.";

        foreach (var mail in Regex.Matches(text,@"[\w\.\-_]{1,}@[A-z0-9\.\-]+\.[A-z\-_]+"))
        {
            Console.WriteLine(mail);
        }
    }
}

