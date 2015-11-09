using System;

namespace CodeFirst.Models.Posts
{
    using AutoMapper;
    using CodeFirst.Models;
    using Common;

    public class PostRequestModel : IHaveCustomMappings, IMapFrom<Post>
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        
        public string Tags { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<PostRequestModel, Post>()
                .ForMember(m => m.Tags, opt => opt.Ignore());
        }


    }
}