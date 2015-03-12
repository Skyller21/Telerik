using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class ExtractTextFromHtml
{
    static void Main()
    {
        string html = "<html><head><title>News</title></head><body> <p><a href=\"http://academy.telerik.com\">Telerik Academy</a> aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body> </html>";

        //html = Regex.Replace(html, @"<.*?>", "");

        foreach (Match m in Regex.Matches(html,"(<title>)(.*)(<\\/title>)|(<body>)(.*)(<\\/body>)"))
        {
            if (m.Groups[1].Value=="<title>")
            {
                string title = Regex.Replace(m.ToString(), "<.*?>", String.Empty);
                Console.WriteLine("Title: {0}",title);
            }
            else if(m.Groups[4].Value=="<body>")            //Groups[4] -> the 4 is because there are already 3 groups created to check for title!!!
            {
                string body = Regex.Replace(m.ToString(), "<.*?>", String.Empty);
                Console.WriteLine("Text: {0}", body);
            }
        }
    }
}

