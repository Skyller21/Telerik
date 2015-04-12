using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentSystem.Interfaces;

namespace DocumentSystem.Models
{

    public abstract class EncryptableDocument : BinaryDocument, IDocument, IEncryptable
    {
        public EncryptableDocument(string name, string content = null, int size = 0, string version = null)
            : base(name, content, size)
        {
            this.IsEncrypted = false;
        }
        public bool IsEncrypted { get; private set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }

        
    }
}
