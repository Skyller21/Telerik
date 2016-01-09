namespace BullsAndCows.Services.Data
{
    using BullsAndCows.Data.Models;
    using BullsAndCows.Data.Repositories;
    using Contracts;
    using System;
    using System.Linq;
    using Web.Common.Constants;
    using Web.Common.Providers;

    public class GamesServices : IGamesServices
    {
        private readonly IRepository<Game> games;
        private readonly IRepository<User> users;
        private readonly IRandomProvider randomProvider;

        public GamesServices(IRepository<Game> games, IRepository<User> users, IRandomProvider randomProvider)
        {
            this.games = games;
            this.users = users;
            this.randomProvider = randomProvider;
        }

        public IQueryable<Game> GetPublicGames(int page, string userId)
        {
            return this.games.All()
                .Where(g => g.GameState == GameState.WaitingForOpponent ||
                      (g.GameState != GameState.WaitingForOpponent && g.RedUser == null && g.BlueUser == null))
                .OrderBy(g => g.GameState)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedUser.Email)
                .Skip((page - 1) * GameConstants.GamePerPage)
                .Take(GameConstants.GamePerPage);
        }

        public IQueryable<Game> GetPrivateGames()
        {
            return null;
        }

        public Game CreateGame(string name, string number, string userId)
        {
            var red = this.users.GetById(userId);
            var game = new Game()
            {
                Name = name,
                GameState = GameState.WaitingForOpponent,
                RedUser = red,
                DateCreated = DateTime.UtcNow,
                RedUserNumber = number
            };

            this.games.Add(game);
            this.games.SaveChanges();

            return game;
        }

        public bool GameCanBeJoinedByUser(int id, string userId)
        {
            return !this.games
                .All()
                .Any(g => g.Id == id &&
                (g.RedUserId == userId ||
                g.GameState != GameState.WaitingForOpponent));
        }

        public string JoinedGame(int id, string userId, string number)
        {
            var gameToJoin = this.games.GetById(id);

            gameToJoin.BlueUserId = userId;

            var gameState = randomProvider.GetRandomNumber(1, 2);

            gameToJoin.GameState = (GameState)gameState;
            gameToJoin.BlueUserNumber = number;

            this.games.SaveChanges();

            return gameToJoin.Name;
        }
    }
}
