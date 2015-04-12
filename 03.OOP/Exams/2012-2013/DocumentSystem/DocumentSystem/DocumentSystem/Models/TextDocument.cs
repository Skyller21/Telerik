using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentSystem.Interfaces;

namespace DocumentSystem
{
    class TextDocument:Document,IDocument, IEditable
    {
        public TextDocument(string name, string charset = null) : base(name)
        {
            this.Charset = charset;
        }

        public string Charset { get; private set; }
        public override void LoadProperty(string key, string value)
        {
            if (key.ToLower() == "charset")
            {
                this.Charset = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
            
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

       
    }
}
