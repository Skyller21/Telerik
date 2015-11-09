namespace SocialNetwork.Models.ModelsDTO
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Friendship")]
    public class FriendshipDto
    {
        [XmlAttribute("Approved")]
        public string IsApproved { get; set; }

        [XmlElement("FriendsSince")]
        public DateTime? FriendsDate { get; set; }

        public UserDto FirstUser { get; set; }

        public UserDto SecondUser { get; set; }

        [XmlArray]
        public List<MessageDto> Messages { get; set; }
    }
}
