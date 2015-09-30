using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _02.ExtractArtists
{
    class ExtractArtists
    {
        static void Main(string[] args)
        {
            string path = "../../../input-files/catalogue.xml";
            GetAllArtistsAndAlbumsDom(path);
        }

        private static void GetAllArtistsAndAlbumsDom(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            Dictionary<string, int> artistsAndAlbums = new Dictionary<string, int>();

            var rootNode = doc.DocumentElement;

            foreach (XmlNode child in rootNode.ChildNodes)
            {
                var artist = child["artist"];

                if (artist != null)
                {
                    if (!artistsAndAlbums.ContainsKey(artist.InnerText))
                    {
                        artistsAndAlbums.Add(artist.InnerText, 1);
                        continue;
                    }
                    artistsAndAlbums[artist.InnerText] += 1;
                }
            }

            Console.WriteLine("Artists with DOM:");
            Console.WriteLine(string.Join(Environment.NewLine, artistsAndAlbums.OrderBy(x => x.Value)));
        }
    }
}
