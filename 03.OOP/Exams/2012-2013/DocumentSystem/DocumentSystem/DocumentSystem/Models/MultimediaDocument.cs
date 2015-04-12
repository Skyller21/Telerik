using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentSystem.Interfaces;

namespace DocumentSystem.Models
{
    public abstract class MultimediaDocument:BinaryDocument
    {
        public MultimediaDocument(string name, string content = null, int size = 0, int length = 0)
            : base(name, content, size)
        {
            this.Length = length;
        }

        public int Length { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.ToLower() == "length")
            {
                this.Length = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }

        }
    }
}
