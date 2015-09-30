using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _07.XmlFromTxt
{
    class XmlFromTxt
    {
        static void Main(string[] args)
        {
            string input = "../../../input-files/people.txt";
            string output = "../../../results/people.xml";

            GenerateXmlFromTextFile(input, output);
        }

        private static void GenerateXmlFromTextFile(string input, string output)
        {
            StreamReader reader = new StreamReader(input);

            var xml = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            var root = new XElement("people");

            var line = reader.ReadLine();

            while (line != null)
            {
                var person = new XElement("person");
                person.Add(new XElement("name", line));
                line = reader.ReadLine();

                person.Add(new XElement("address", line));
                line = reader.ReadLine();

                person.Add(new XElement("phone", line));
                line = reader.ReadLine();

                root.Add(person);
            }

            xml.Add(root);

            Console.WriteLine(xml);

            xml.Save(output);
        }
    }
}
