namespace Exam.Web.DtoModels
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class CommentsRequestModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int RealEstateId { get; set; }

        [Required]
        public string Content { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentsRequestModel>()
                .ForMember(c => c.Content, opts => opts.MapFrom(g => g.Content))
                .ForMember(c => c.RealEstateId, opts => opts.MapFrom(g => g.RealEstateId));
        }
    }
}
