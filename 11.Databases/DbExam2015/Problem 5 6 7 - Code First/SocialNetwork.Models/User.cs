namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        private ICollection<Image> images;
        private ICollection<Post> postsTaggedIn;
        private ICollection<Message> messages;

        public User()
        {
            this.images = new HashSet<Image>();
            this.postsTaggedIn = new List<Post>();
            this.messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        [Required]
        [Index("Username", IsUnique = true)]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public DateTime RegDate { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Post> PostsTaggedIn
        {
            get { return this.postsTaggedIn; }
            set { this.postsTaggedIn = value; }
        }

        public ICollection<Message> Messages
        {
            get { return messages; }
            set { messages = value; }
        }
    }
}
