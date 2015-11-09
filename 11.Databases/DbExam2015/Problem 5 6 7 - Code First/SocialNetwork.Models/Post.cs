namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        private ICollection<User> taggedUsers;

        public Post()
        {
            this.taggedUsers = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(int.MaxValue, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Display(Name = "Username")]
        public string Content { get; set; }

        public DateTime PostDate { get; set; }

        public virtual ICollection<User> TaggedUsers
        {
            get { return this.taggedUsers; }
            set { this.taggedUsers = value; }
        }
    }
}
