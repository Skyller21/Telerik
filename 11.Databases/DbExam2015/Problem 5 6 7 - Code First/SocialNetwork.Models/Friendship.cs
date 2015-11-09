namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Friendship
    {
        private ICollection<Message> messages;

        public Friendship()
        {
            this.messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        [Index]
        public DateTime? ApprovalDate { get; set; }

        public bool IsApproved { get; set; }

        public int FirstUserId { get; set; }

        public virtual User FirstUser { get; set; }

        public int SecondUserId { get; set; }

        public virtual User SecondUser { get; set; }

        public ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }
    }
}
