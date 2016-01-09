namespace Exam.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Web.Common.Constants;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MinLength(RealEstateConstants.CommentContentMinLength)]
        [MaxLength(RealEstateConstants.CommentContentMaximumLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}