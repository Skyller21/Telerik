namespace SocialNetwork.Models.ModelsDTO
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Post")]
    public class PostDto
    {
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public string Users { get; set; }
    }
}
