using System.Linq;

namespace Exam.Services.Data.Contracts
{
    using Exam.Data.Models;

    public interface IUserServices : IService
    {
        IQueryable<User> All();

        User GetUser(string id);

        void RateUser(Rating rating, string userId);
    }
}
