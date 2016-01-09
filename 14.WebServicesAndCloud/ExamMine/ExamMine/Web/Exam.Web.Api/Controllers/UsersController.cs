using System.Web.Http;

namespace Exam.Web.Api.Controllers
{
    using AutoMapper;
    using Data.Models;
    using DtoModels.Ratings;
    using DtoModels.Users;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;

    public class UsersController : ApiController
    {
        private IUserServices users;

        public UsersController(IUserServices users)
        {
            this.users = users;
        }

        public IHttpActionResult Get(string id)
        {
            var user = this.users.GetUser(id);

            return this.Ok(Mapper.Map<UserResponseModel>(user));
        }

        [Authorize]
        [Route("api/Users/Rate")]
        public IHttpActionResult Put(RatingRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();

            if (model.UserId == userId)
            {
                return this.BadRequest("You cannot rate yourself!");
            }

            var rate = Mapper.Map<Rating>(model);
            this.users.RateUser(rate, userId);

            return this.Ok();
        }
    }
}
