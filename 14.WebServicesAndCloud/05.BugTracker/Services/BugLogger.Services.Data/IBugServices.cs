namespace BugLogger.Services.Data
{
    using Models;
    using Server.DtoModels;
    using System;
    using System.Linq;

    public interface IBugServices : IService
    {
        IQueryable<Bug> All();

        IQueryable<Bug> AllAfterDate(DateTime date);

        IQueryable<Bug> AllByStatus(Status type);

        IQueryable<Bug> AllByDateAndStatus(BugQuery query);

        int Update(int id, Bug bug);

        void Add(Bug bug);
    }
}
