using System.Web.Http;

namespace BullsAndCows.Web.Api.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Validation;
    using DtoModels.Games;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using System.Linq;

    public class GamesController : ApiController
    {
        private readonly IGamesServices games;

        public GamesController(IGamesServices games)
        {
            this.games = games;
        }

        [HttpGet]
        public IHttpActionResult Get(int page = 1)
        {
            var userId = User.Identity.GetUserId();

            var games = this.games.GetPublicGames(page, userId).ProjectTo<ListedGameResponseModel>().ToList();
            return this.Ok(games);
        }

        [Authorize]
        [ValidateModel]
        public IHttpActionResult Post(CreateGameRequestModel model)
        {
            var userId = this.User.Identity.GetUserId();

            var newGame = this.games.CreateGame(model.Name, model.Number, userId);

            var gameResult = Mapper.Map<ListedGameResponseModel>(newGame);

            return this.CreatedAtRoute("DefaultApi", new { id = gameResult.Id }, gameResult);
        }

        [Authorize]
        [ValidateModel]
        public IHttpActionResult Put(int id, [FromBody] BaseGameRequestModel model)
        {
            var userId = this.User.Identity.GetUserId();
            if (!this.games.GameCanBeJoinedByUser(id, userId))
            {
                return this.BadRequest("Game is yours");
            }

            var joinedGame = this.games.JoinedGame(id, userId, model.Number);

            return this.Ok(new { result = string.Format("You joined game \"{0}\"", joinedGame) });
        }

    }
}
