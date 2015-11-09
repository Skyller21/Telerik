namespace SocialNetwork.Models.ModelsDTO
{
    using System.Xml.Serialization;

    [XmlType("Image")]
    public class ImageDto
    {
        public string ImageUrl { get; set; }

        public string FileExtension { get; set; }
    }
}
