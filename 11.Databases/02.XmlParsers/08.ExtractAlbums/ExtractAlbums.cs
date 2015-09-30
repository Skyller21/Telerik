using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _08.ExtractAlbums
{
    class ExtractAlbums
    {
        static void Main(string[] args)
        {
            string input = "../../../input-files/catalogue.xml";
            string output = "../../../results/albums.xml";
            GenerateAlbumsAndAuthors(input, output);
        }

        private static void GenerateAlbumsAndAuthors(string input, string output)
        {
            XmlWriterSettings objSetting = new XmlWriterSettings();
            objSetting.Indent = true;
            objSetting.NewLineOnAttributes = true;

            var reader = XmlReader.Create(input);
            using (reader)
            {
                var writer = XmlWriter.Create(output, objSetting);
                using (writer)
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");

                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            if (reader.Name == "album")
                            {
                                writer.WriteStartElement("album");
                            }
                            else if (reader.Name == "name")
                            {
                                reader.Read();
                                writer.WriteElementString("name", reader.Value);
                            }
                            else if (reader.Name == "artist")
                            {
                                reader.Read();
                                writer.WriteElementString("artist", reader.Value);
                            }
                        }

                        if (!reader.IsStartElement())
                        {
                            if (reader.Name == "album")
                            {
                                writer.WriteEndElement();
                            }
                        }
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }
    }
}
