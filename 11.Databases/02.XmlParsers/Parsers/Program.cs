using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Parsers
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Problem 2.DOM Parser: Extract Album Names
            //GetAllAlbumsDOM();
            //Console.WriteLine();

            //// Problem 3.DOM Parser: Extract All Artists Alphabetically
            //GetAllArtistsAlphabeticallyDOM();
            //Console.WriteLine();

            //---------------------------------------------------------

        }

        private static void GetAllAlbumsDOM()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../results/catalog.xml");


            var rootNode = doc.DocumentElement;
            foreach (XmlNode child in rootNode.ChildNodes)
            {
                if (child["name"] != null)
                {
                    Console.WriteLine("Album name: {0}", child["name"].InnerText);
                }
            }
        }

        private static void GetAllArtistsAlphabeticallyDOM()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../results/catalog.xml");

            SortedSet<string> artists = new SortedSet<string>();

            var rootNode = doc.DocumentElement;

            foreach (XmlNode child in rootNode.ChildNodes)
            {
                if (child["artist"] != null)
                {
                    artists.Add(child["artist"].InnerText);
                }
            }

            Console.WriteLine("Artists:");
            Console.WriteLine(string.Join(Environment.NewLine, artists));
        }


        

        

        


        

        

        
    }
}
