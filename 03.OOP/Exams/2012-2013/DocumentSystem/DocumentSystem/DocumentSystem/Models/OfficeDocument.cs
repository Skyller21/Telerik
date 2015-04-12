using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentSystem.Interfaces;

namespace DocumentSystem.Models
{
    public abstract class OfficeDocument : EncryptableDocument
    {
        public OfficeDocument(string name, string content = null, int size = 0, string version = null)
            : base(name, content, size)
        {
            this.Version = version;
        }

        public string Version { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.ToLower() == "version")
            {
                this.Version = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }

        }
    }
}
