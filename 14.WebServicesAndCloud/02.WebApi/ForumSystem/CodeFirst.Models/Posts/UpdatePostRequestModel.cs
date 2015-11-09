namespace CodeFirst.Models.Posts
{
    using AutoMapper;
    using CodeFirst.Models;
    using Common;

    public class UpdatePostRequestModel : IHaveCustomMappings, IMapFrom<Post>
    {
        public string Content { get; set; }

        public string Tags { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<UpdatePostRequestModel, Post>()
                .ForMember(m => m.Tags, opt => opt.Ignore());
        }
    }
}