using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _03.ExtractArtistsXPath
{
    class ExtractArtistsXPath
    {
        static void Main(string[] args)
        {
            string path = "../../../input-files/catalogue.xml";
            GetAllArtistsAndAlbumsXPath(path);
        }

        private static void GetAllArtistsAndAlbumsXPath(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            Dictionary<string, int> artistsAndAlbums = new Dictionary<string, int>();

            string xPathArtist = "catalogue/album/artist";

            XmlNodeList artists = doc.SelectNodes(xPathArtist);

            foreach (XmlNode artist in artists)
            {
                if (!artistsAndAlbums.ContainsKey(artist.InnerText))
                {
                    artistsAndAlbums.Add(artist.InnerText, 1);
                    continue;
                }
                artistsAndAlbums[artist.InnerText] += 1;
            }
            Console.WriteLine("Artists with XPath:");
            Console.WriteLine(string.Join(Environment.NewLine, artistsAndAlbums.OrderBy(x => x.Value)));
        }
    }
}
