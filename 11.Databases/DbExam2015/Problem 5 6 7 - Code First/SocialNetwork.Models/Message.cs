namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message
    {
        public int Id { get; set; }

        public int FriendshipId { get; set; }

        public virtual Friendship Friendship { get; set; }

        public int AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public string Content { get; set; }

        [Index]
        public DateTime SendDate { get; set; }

        public DateTime? SeenDate { get; set; }
    }
}
