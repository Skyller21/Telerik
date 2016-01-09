using System.Linq;

namespace Exam.Services.Data
{
    using Contracts;
    using Exam.Data.Models;
    using Exam.Data.Repositories;

    public class UserServices : IUserServices
    {
        private readonly IRepository<User> users;
        private readonly IRepository<Rating> ratings;

        public UserServices(IRepository<User> users, IRepository<Rating> ratings)
        {
            this.users = users;
            this.ratings = ratings;
        }

        public IQueryable<User> All()
        {
            return null;
        }

        public User GetUser(string id)
        {
            var user = this.users.All().FirstOrDefault(u => u.Id == id);

            return user;
        }

        public void RateUser(Rating model, string userId)
        {
            var ratedUser = this.users.All().FirstOrDefault(u => u.Id == model.RatedUserId);
            var userGivesRating = this.users.All().FirstOrDefault(u => u.Id == userId);
            var rating = new Rating()
            {
                Stars = model.Stars,
                RatedUser = ratedUser,
                UserGiveRate = userGivesRating

            };

            this.ratings.Add(rating);
            this.ratings.SaveChanges();
        }
    }
}
