using System;

namespace CodeFirst.Models.Posts
{
    public class PostViewModel
    {
        public string Title { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }

        public int TotalAnswers { get; set; }
    }
}