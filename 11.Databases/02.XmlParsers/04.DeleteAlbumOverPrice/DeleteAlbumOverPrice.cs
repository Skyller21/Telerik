using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _04.DeleteAlbumOverPrice
{
    class DeleteAlbumOverPrice
    {
        static void Main(string[] args)
        {
            int price = 20;
            string path = "../../../input-files/catalogue.xml";
            DeleteAllOverAPriceDOM(path, price);
        }
        private static void DeleteAllOverAPriceDOM(string path, int maxPrice)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlDocument newDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = newDoc.CreateXmlDeclaration("1.0", "utf-8", null);

            // Create the root node
            var rootNode = doc.DocumentElement;
            XmlElement rootElement = newDoc.CreateElement(rootNode.Name);
            newDoc.AppendChild(rootElement);

            // Add the xml declaration
            newDoc.InsertBefore(xmlDeclaration, newDoc.DocumentElement);

            foreach (XmlNode child in rootNode.ChildNodes)
            {
                var price = child["price"];
                if (price != null && decimal.Parse(price.InnerText) < maxPrice)
                {
                    rootElement.AppendChild(newDoc.ImportNode(child, true));
                }
            }

            newDoc.Save("../../../results/cheap-albums.xml");
            Console.WriteLine("Document saved.");
        }
    }
}
