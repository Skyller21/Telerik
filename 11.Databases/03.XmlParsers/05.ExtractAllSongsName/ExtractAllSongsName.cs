using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _05.ExtractAllSongsName
{
    class ExtractAllSongsName
    {
        static void Main(string[] args)
        {
            string path = "../../../input-files/catalogue.xml";
            ExtractSongsName(path);
        }

        private static void ExtractSongsName(string path)
        {
            var songs = new List<string>();

            // Create an XmlReader
            using (XmlReader reader = XmlReader.Create(path))
            {
                // Parse the file and display each of the nodes.
                while (reader.Read())
                {
                    if (reader.Name == "song")
                    {
                        songs.Add(reader.GetAttribute("title"));
                    }
                }
            }
            songs = songs.OrderBy(x => x).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, songs));
        }
    }
}
