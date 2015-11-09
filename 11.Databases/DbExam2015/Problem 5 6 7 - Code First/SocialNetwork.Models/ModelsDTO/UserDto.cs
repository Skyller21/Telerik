namespace SocialNetwork.Models.ModelsDTO
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class UserDto
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }

        [XmlArray]
        public List<ImageDto> Images { get; set; }
    }
}
