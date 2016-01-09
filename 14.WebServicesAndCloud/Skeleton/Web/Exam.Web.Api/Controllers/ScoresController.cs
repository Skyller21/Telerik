namespace Exam.Web.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Models.HighScore;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Http;

    public class ScoresController : ApiController
    {
        private readonly IHighScoreService highScore;

        public ScoresController(IHighScoreService highScore)
        {
            this.highScore = highScore;
        }

        public IHttpActionResult Get()
        {
            var highScoreResult = this.highScore
                .GetLatest()
                .ProjectTo<HighScoreResponseModel>()
                .ToList();

            return this.Ok(highScoreResult);
        }
    }
}
