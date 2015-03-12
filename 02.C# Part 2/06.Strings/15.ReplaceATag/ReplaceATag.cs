using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReplaceATag
{
    static void Main()
    {
        string paragraph = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
        paragraph = paragraph.Replace("<a href=","[URL=");
        paragraph = paragraph.Replace("</a>", "[/URL]");
        paragraph = paragraph.Replace(">", "]");
        Console.WriteLine(paragraph);
    }
}

