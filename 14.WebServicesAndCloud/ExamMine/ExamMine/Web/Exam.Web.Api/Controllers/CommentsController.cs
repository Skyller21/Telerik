using System.Web.Http;

namespace Exam.Web.Api.Controllers
{
    using AutoMapper;
    using Data.Models;
    using DtoModels;
    using DtoModels.Queries;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class CommentsController : ApiController
    {
        private readonly ICommentServices comments;

        public CommentsController(ICommentServices comments)
        {
            this.comments = comments;
        }

        [Authorize]
        public IHttpActionResult Get(int id, [FromUri]QueryRealEstates query)
        {
            if (query == null)
            {
                query = new QueryRealEstates()
                {
                    Skip = 0,
                    Take = 10
                };
            }
            if (query.Skip == null)
            {
                query.Skip = 0;
            }

            if (query.Take == null)
            {
                query.Take = 10;
            }

            var comments = this.comments.GetAllByEstateId(id, query.Skip.Value, query.Take.Value).ToList();

            return this.Ok(Mapper.Map<List<CommentResponseModel>>(comments));
        }

        [Authorize]
        [Route("api/Comments/ByUser/{id}")]
        public IHttpActionResult Get(string id, [FromUri]QueryRealEstates query)
        {
            if (query == null)
            {
                query = new QueryRealEstates()
                {
                    Skip = 0,
                    Take = 10
                };
            }
            if (query.Skip == null)
            {
                query.Skip = 0;
            }

            if (query.Take == null)
            {
                query.Take = 10;
            }

            var comments = this.comments.GetAllByUserName(id, query.Skip.Value, query.Take.Value).ToList();

            return this.Ok(Mapper.Map<List<CommentResponseModel>>(comments));
        }


        public IHttpActionResult Post(CommentsRequestModel model)
        {
            var userId = this.User.Identity.GetUserId();
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var addedComment = this.comments.Add(Mapper.Map<Comment>(model), userId);

            return this.Ok(Mapper.Map<CommentResponseModel>(addedComment));
        }
    }
}
