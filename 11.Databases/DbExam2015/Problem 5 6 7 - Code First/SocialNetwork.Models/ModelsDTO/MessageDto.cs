namespace SocialNetwork.Models.ModelsDTO
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Message")]
    public class MessageDto
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public DateTime? SeenOn { get; set; }
    }
}
