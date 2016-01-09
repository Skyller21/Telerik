namespace Exam.Web.DtoModels.Users
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.Linq;

    public class UserResponseModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Username { get; set; }

        public int RealEstates { get; set; }

        public int Comments { get; set; }

        public double Rating { get; set; }


        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserResponseModel>()
                .ForMember(u => u.Username, opts => opts.MapFrom(g => g.UserName))
                .ForMember(u => u.RealEstates, opts => opts.MapFrom(g => g.RealEstates.Count))
                .ForMember(u => u.Comments, opts => opts.MapFrom(g => g.Comments.Count))
                .ForMember(u => u.Rating,
                    opts => opts.MapFrom(g => g.ReceivedRatings.Count > 0 ? (g.ReceivedRatings.Sum(x => x.Stars) / (double)g.ReceivedRatings.Count) : 0));
        }
    }
}
