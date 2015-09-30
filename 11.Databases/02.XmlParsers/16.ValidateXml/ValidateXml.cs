using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace _16.ValidateXml
{
    class ValidateXml
    {
        private static void Main()
        {
            var xmlSchema = new XmlSchemaSet();
            xmlSchema.Add(string.Empty, "../../../input-files/catalogue.xsd");

            XDocument doc = XDocument.Load("../../../input-files/catalogue.xml");
            XDocument doc1 = XDocument.Load("../../../input-files/invalid-catalogue.xml");

            PrintValidationResult(doc, xmlSchema);
            Console.WriteLine(new string('-',20));
            PrintValidationResult(doc1, xmlSchema);
            
        }

        private static void PrintValidationResult(XDocument doc, XmlSchemaSet xmlSchema)
        {
            bool errors = false;
            doc.Validate(xmlSchema, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            }, true);

            Console.WriteLine("doc {0}\n", errors ? "did not validate" : "validated");
        }
    }
}
