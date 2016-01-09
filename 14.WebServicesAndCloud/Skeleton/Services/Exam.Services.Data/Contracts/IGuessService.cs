namespace Exam.Services.Data.Contracts
{
    using System.Linq;
    using Exam.Data.Models;

    public interface IGuessService : IService
    {
        Guess MakeGuess(int gameId, string number, string userId);

        IQueryable<Guess> GetGuessDetails(int id);
    }
}
