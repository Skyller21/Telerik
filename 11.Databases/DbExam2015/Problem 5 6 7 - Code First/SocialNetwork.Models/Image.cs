namespace SocialNetwork.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        [StringLength(4, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Extension")]
        public string Extension { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
