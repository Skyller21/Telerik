namespace Exam.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Web.Common.Constants;

    public class Rating
    {
        public int Id { get; set; }

        [Range(RealEstateConstants.MinStars, RealEstateConstants.MaximumStars)]
        public int Stars { get; set; }

        public string RatedUserId { get; set; }

        public virtual User RatedUser { get; set; }

        public string UserGiveRateId { get; set; }

        public virtual User UserGiveRate { get; set; }
    }
}