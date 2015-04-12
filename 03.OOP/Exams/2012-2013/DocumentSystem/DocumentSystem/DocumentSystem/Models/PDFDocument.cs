using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem.Models
{
    public class PDFDocument : EncryptableDocument
    {
        public PDFDocument(string name, string content = null, int size = 0, int numberOfPages = 0)
            : base(name, content, size)
        {
            this.NumberOfPages = numberOfPages;
        }

        public int NumberOfPages { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.ToLower() == "pages")
            {
                this.NumberOfPages = int.Parse(value);
            }
            base.LoadProperty(key, value);
        }

        
    }
}
