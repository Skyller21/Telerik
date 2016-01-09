using System.Linq;

namespace Exam.Services.Data.Contracts
{
    using Exam.Data.Models;
    using Web.Common.Constants;

    public interface IRealEstateServices : IService
    {
        IQueryable<RealEstate> Top10RealEstates(int skip = RealEstateConstants.SkipPage, int take = RealEstateConstants.PerPage);

        RealEstate GetById(int id);

        RealEstate Add(RealEstate model, string userId);
    }
}
