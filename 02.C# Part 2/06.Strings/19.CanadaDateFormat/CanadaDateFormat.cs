using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;


class CanadaDateFormat
{
    static void Main()
    {
        string text = "Client Services If you have complaints or suggestions regarding Telerik services, please contact us at client-service@telerik-ltd.co.uk until 02.03.2012. For Sitefinity, please e-mail: clientservice@sitefinity.com until 06.06.2012. After 12.21.2012 there will be blood";

        foreach (var date in Regex.Matches(text, @"\d{2}.[0-1]\d.\d{4}"))
        {
            DateTime dateCanada = DateTime.Parse(date.ToString());
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            Console.WriteLine("The date in canadian format is: {0}",dateCanada.ToShortDateString());
        }
    }
}

