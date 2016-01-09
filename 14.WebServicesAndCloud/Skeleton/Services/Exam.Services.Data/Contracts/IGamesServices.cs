using System.Linq;

namespace Exam.Services.Data.Contracts
{
    using Exam.Data.Models;

    public interface IGamesServices : IService
    {
        IQueryable<Game> GetPublicGames(int page = 0, string userId = null);

        IQueryable<Game> GetPrivateGames();

        Game CreateGame(string name, string number, string userId);

        IQueryable<Game> GetGameDetails(int id);

        bool GameCanBeJoinedByUser(int id, string userId);

        string JoinedGame(int id, string userId, string number);

        bool CanMakeGuess(int id, string userId);

        bool UserIsPartOfGame(int id, string userId);

        void ChangeGameState(int id, bool finished);
    }
}
