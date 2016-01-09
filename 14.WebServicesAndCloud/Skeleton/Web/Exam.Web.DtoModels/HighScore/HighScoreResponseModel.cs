namespace Exam.Web.Api.Models.HighScore
{
    using AutoMapper;
    using Exam.Data.Models;
    using Exam.Web.Common.Mapping;

    public class HighScoreResponseModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Username { get; set; }

        public int Rank { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, HighScoreResponseModel>()
                .ForMember(u => u.Username, opts => opts.MapFrom(u => u.Email));
        }
    }
}
