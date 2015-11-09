namespace TheGuardian.ConsoleClient
{
    using System;
    using Newtonsoft.Json;

    public class Result
    {
        [JsonProperty("type")]
        public string ResultType { get; set; }

        [JsonProperty("sectionName")]
        public string Section { get; set; }

        [JsonProperty("webTitle")]
        public string Title { get; set; }

        [JsonProperty("webPublicationDate")]
        public DateTime DatePublished { get; set; }
        
        [JsonProperty("webUrl")]
        public string Url { get; set; }
    }
}
