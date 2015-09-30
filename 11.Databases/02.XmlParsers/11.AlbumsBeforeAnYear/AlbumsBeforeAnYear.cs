using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace _11.AlbumsBeforeAnYear
{
    class AlbumsBeforeAnYear
    {
        static void Main(string[] args)
        {
            string input = "../../../input-files/catalogue.xml";

            OldAlbumsXPath(5,input);

        }

        private static void OldAlbumsXPath(int years, string path)
        {
            Console.WriteLine("Old Albums XPath");
            var doc = XDocument.Load(path);

            string xPathAlbums = "catalogue/album";

            var albums = doc.XPathSelectElements(xPathAlbums);


            foreach (var album in albums)
            {
                var name = album.Element("name");

                if (name != null)
                {
                    var year = album.Element("year");
                    if (year != null)
                    {
                        if (int.Parse(year.Value) < DateTime.Now.AddYears(years * -1).Year)
                        {
                            var price = album.Element("price");
                            if (price != null)
                            {
                                Console.WriteLine("Album: {0}, Price: {1}", name.Value, price.Value);
                            }
                        }
                    }
                }
            }
        }
    }
}
