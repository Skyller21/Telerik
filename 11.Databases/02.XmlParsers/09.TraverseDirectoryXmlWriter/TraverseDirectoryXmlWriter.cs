using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _09.TraverseDirectoryXmlWriter
{
    class TraverseDirectoryXmlWriter
    {
        static void Main(string[] args)
        {
            var writer = XmlWriter.Create("../../../results/directories.xml", new XmlWriterSettings() { Indent = true, NewLineChars = Environment.NewLine });
            string path = @"D:\Marto\Google Drive\Telerik Experience\11.Databases\02.XmlParsers";

            using (writer)
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("dirs");
                writer.WriteAttributeString("name", path);
                GetAllFilesAndFoldersRecursively(
                    new DirectoryInfo(path), writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void GetAllFilesAndFoldersRecursively(DirectoryInfo path, XmlWriter writer)
        {
            writer.WriteStartElement("dir");
            writer.WriteAttributeString("name", path.Name);

            try
            {
                writer.WriteStartElement("files");
                foreach (FileInfo file in path.GetFiles())
                {
                    writer.WriteStartElement("file");
                    writer.WriteElementString("name", file.Name);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            catch (IOException)
            {
                Console.WriteLine("Directory {0}  \n could not be accessed!", path.FullName);
                return;
            }

            // process each directory
            foreach (DirectoryInfo dir in path.GetDirectories())
            {
                path = dir;
                GetAllFilesAndFoldersRecursively(dir, writer);
            }

            writer.WriteEndElement();
        }
    }
}
