using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentSystem.Interfaces;

namespace DocumentSystem.Models
{
    class AudioDocument : MultimediaDocument
    {
        public AudioDocument(string name, string content = null, int size = 0, int length = 0,double sampleRate = 0)
            : base(name, content, size, length)
        {
            this.SampleRate = sampleRate;
        }

        public double SampleRate { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.ToLower() == "samplerate")
            {
                this.SampleRate = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }

        }
    }
}
