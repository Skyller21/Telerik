using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _06.ExtractAllSongsNameLinq
{
    class ExtractAllSongsNameLinq
    {
        static void Main(string[] args)
        {
            string path = "../../../input-files/catalogue.xml";
            ExtractSongsNameLinq(path);
        }

        private static void ExtractSongsNameLinq(string path)
        {
            var xml = XDocument.Load(path);

            var songs = xml.Descendants()
                .Where(x => x.Name == "song")
                .OrderBy(x => x.Attribute("title").ToString())
                .Select(x => x.Attribute("title").Value);

            foreach (var item in songs)
            {
                Console.WriteLine(item);
            }
        }
    }
}
