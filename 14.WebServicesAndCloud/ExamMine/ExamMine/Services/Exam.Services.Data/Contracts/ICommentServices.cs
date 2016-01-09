using System.Linq;

namespace Exam.Services.Data.Contracts
{
    using Exam.Data.Models;
    using Web.Common.Constants;

    public interface ICommentServices : IService
    {
        IQueryable<Comment> GetAllByEstateId(int id, int skip = RealEstateConstants.SkipPage, int take = RealEstateConstants.PerPage);

        IQueryable<Comment> GetAllByUserName(string username, int skip = RealEstateConstants.SkipPage, int take = RealEstateConstants.PerPage);

        Comment Add(Comment model, string userId);
    }
}
