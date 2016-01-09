using System.Linq;

namespace BullsAndCows.Services.Data.Contracts
{
    using BullsAndCows.Data.Models;

    public interface IGamesServices : IService
    {
        IQueryable<Game> GetPublicGames(int page = 0, string userId = null);

        IQueryable<Game> GetPrivateGames();

        Game CreateGame(string name, string number, string userId);

        bool GameCanBeJoinedByUser(int id, string userId);

        string JoinedGame(int id, string userId, string number);
    }
}
