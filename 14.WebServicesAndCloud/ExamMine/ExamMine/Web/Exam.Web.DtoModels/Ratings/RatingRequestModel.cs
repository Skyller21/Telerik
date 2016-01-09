namespace Exam.Web.DtoModels.Ratings
{
    using AutoMapper;
    using Common.Constants;
    using Common.Mapping;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class RatingRequestModel : IMapFrom<Rating>, IHaveCustomMappings
    {
        public string UserId { get; set; }

        [Range(RealEstateConstants.MinStars, RealEstateConstants.MaximumStars)]
        public int Value { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RatingRequestModel, Rating>()
                .ForMember(r => r.RatedUserId, opts => opts.MapFrom(g => g.UserId))
                .ForMember(r => r.Stars, opts => opts.MapFrom(g => g.Value));
        }
    }
}
