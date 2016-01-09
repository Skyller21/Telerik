namespace Exam.Services.Data.Contracts
{
    using Exam.Data.Models;
    using System.Linq;

    public interface IHighScoreService : IService
    {
        void UpdateRank(string userId, bool won);

        IQueryable<User> GetLatest();
    }
}
