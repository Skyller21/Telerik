using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentSystem.Interfaces;

namespace DocumentSystem.Models
{
    class WordDocument : OfficeDocument, IEditable
    {
        public WordDocument(string name, string content = null, int size = 0,string version = null, int numberOfCharacters = 0)
            : base(name, content, size,version)
        {
            this.NumberOfCharacters = numberOfCharacters;
        }

        public int NumberOfCharacters { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.ToLower() == "")
            {

            }
            base.LoadProperty(key, value);
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

      
    }
}
