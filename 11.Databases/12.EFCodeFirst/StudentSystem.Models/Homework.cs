namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Content")]
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        public virtual int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual int StudentId { get; set; }

        public virtual Student Student { get; set; }

    }
}
