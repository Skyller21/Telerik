using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _12.AlbumsBeforeAnYearLinq
{
    class AlbumsBeforeAnYearLinq
    {
        static void Main(string[] args)
        {
            string input = "../../../input-files/catalogue.xml";

            OldAlbumsLinq(5,input);
        }

        private static void OldAlbumsLinq(int years, string input)
        {
            Console.WriteLine("Old Albums Linq");
            var doc = XDocument.Load(input);

            var yearToCompare = DateTime.Now.AddYears(years * -1).Year;

            var albums1 = doc.Descendants("album")
                .Where(x => x.Element("year") != null && int.Parse(x.Element("year").Value) < yearToCompare)
                .Select(x => new
                {
                    Album = x.Element("name") != null ? x.Element("name").Value : "N/A",
                    Price = x.Element("price") != null ? x.Element("price").Value : "N/A",

                });

            Console.WriteLine(string.Join(Environment.NewLine, albums1));

        }
    }
}
