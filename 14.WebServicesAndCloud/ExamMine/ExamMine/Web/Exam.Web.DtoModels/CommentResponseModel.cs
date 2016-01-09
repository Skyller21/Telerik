namespace Exam.Web.DtoModels
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System;

    public class CommentResponseModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            //"Content": "Wow, such a bargain! I want to see the place!",
            //"UserName": "ivaylokenov",
            //"CreatedOn": "2015-11-22T16:40:03.123"
            configuration.CreateMap<Comment, CommentResponseModel>()
                .ForMember(r => r.Username, opts => opts.MapFrom(p => p.User.UserName));


        }
    }

}




