using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ProcessJson
{
    public class Link
    {
        [JsonProperty("@href")]
        public string Href { get; set; }
    }
}
