using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace _14.ApplyStyleToXml
{
    class ApplyStyleToXml
    {
        static void Main(string[] args)
        {
            XDocument xDoc = XDocument.Load("../../../input-files/catalogue.xml");

            XDocument transformedDoc = new XDocument();
            using (XmlWriter writer = transformedDoc.CreateWriter())
            {
                XslCompiledTransform transform = new XslCompiledTransform();
                transform.Load(XmlReader.Create(new StreamReader("../../../13.Style/catalogue-style.xslt")));
                transform.Transform(xDoc.CreateReader(), writer);
            }

            transformedDoc.Save("../../../results/transformed-catalogue.html");
        }
    }
}
