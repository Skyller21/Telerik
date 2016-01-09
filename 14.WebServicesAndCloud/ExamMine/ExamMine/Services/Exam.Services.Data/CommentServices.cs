namespace Exam.Services.Data
{
    using Contracts;
    using Exam.Data.Models;
    using Exam.Data.Repositories;
    using System;
    using System.Linq;

    public class CommentServices : ICommentServices
    {
        private IRepository<Comment> comments;
        private IRepository<RealEstate> estates;
        private IRepository<User> users;

        public CommentServices(IRepository<Comment> comments, IRepository<RealEstate> estates, IRepository<User> users)
        {
            this.comments = comments;
            this.estates = estates;
            this.users = users;
        }

        public IQueryable<Comment> GetAllByEstateId(int id, int skip, int take)
        {
            var comments = this.comments.All()
                .Where(c => c.RealEstateId == id)
                .OrderBy(c => c.CreatedOn)
                .Skip(skip)
                .Take(take);

            return comments;
        }

        public IQueryable<Comment> GetAllByUserName(string username, int skip, int take)
        {
            var comments = this.comments.All()
                .Where(c => c.User.UserName == username)
                .OrderBy(c => c.CreatedOn)
                .Skip(skip)
                .Take(take);

            return comments;
        }

        public Comment Add(Comment model, string userId)
        {
            var user = this.users.GetById(userId);

            var realEstate = this.estates.GetById(model.RealEstateId);

            var newComment = new Comment()
            {
                RealEstate = realEstate,
                Content = model.Content,
                CreatedOn = DateTime.Now,
                User = user
            };

            this.comments.Add(newComment);
            this.comments.SaveChanges();

            return newComment;
        }
    }
}
