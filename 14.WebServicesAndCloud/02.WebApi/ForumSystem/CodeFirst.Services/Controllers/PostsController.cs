using System.Linq;
using System.Web.Http;

namespace CodeFirst.Services.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CodeFirst.Models;
    using Data;
    using Microsoft.Ajax.Utilities;
    using Models.Posts;
    using System;

    public class PostsController : ApiController
    {
        private readonly IPostsServices posts;
        private readonly ITagsServices tags;

        public PostsController(IPostsServices postsServices, ITagsServices tagsServices)
        {
            this.posts = postsServices;
            this.tags = tagsServices;
        }

        public IHttpActionResult Get()
        {
            Mapper.CreateMap<Post, PostViewModel>()
                .ForMember(p => p.TotalAnswers, opts => opts.MapFrom(p => p.Answers.Count));

            var result = this.posts.All().ProjectTo<PostViewModel>().ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Get(string id)
        {
            Mapper.CreateMap<Post, PostViewModel>()
                .ForMember(p => p.TotalAnswers, opts => opts.MapFrom(p => p.Answers.Count))
                .ForMember(p => p.Username, opts => opts.MapFrom(p => p.User.UserName));

            if (id.IsNullOrWhiteSpace())
            {
                return this.BadRequest("Title cannot be null or empty!");
            }

            var result = this.posts.All().ProjectTo<PostViewModel>().FirstOrDefault(p => p.Title == id);

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }



        [Authorize]
        public IHttpActionResult Post(PostRequestModel post)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }


            var currentUser = this.User.Identity.Name;

            var tagsFromValue = this.tags.TagsFromCommaSeparatedValues(post.Tags);

            this.posts.Add(Mapper.Map<Post>(post), currentUser, tagsFromValue);
            return this.Ok();
        }


        [Authorize]
        public IHttpActionResult Put(UpdatePostRequestModel post, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }
            var currentUser = this.User.Identity.Name;

            var tagsFromValue = this.tags.TagsFromCommaSeparatedValues(post.Tags);
            try
            {
                this.posts.Update(id, Mapper.Map<Post>(post), currentUser, tagsFromValue);
                return this.Ok();
            }
            catch (ArgumentException)
            {

                return this.NotFound();
            }
            catch (InvalidOperationException)
            {
                return this.Unauthorized();
            }
        }
    }
}
