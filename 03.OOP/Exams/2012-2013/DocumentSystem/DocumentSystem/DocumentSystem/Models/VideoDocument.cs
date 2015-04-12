using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem.Models
{
    class VideoDocument : MultimediaDocument
    {
        public VideoDocument(string name, string content = null, int size = 0, int length = 0, int frameRate=0)
            : base(name, content, size, length)
        {
            this.FrameRate = frameRate;
        }

        public int FrameRate { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.ToLower() == "framerate")
            {
                this.FrameRate =int.Parse( value);
            }
            else
            {
                base.LoadProperty(key, value);
            }

        }
    }
}
