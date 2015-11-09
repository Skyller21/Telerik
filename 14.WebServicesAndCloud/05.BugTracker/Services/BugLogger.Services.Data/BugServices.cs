namespace BugLogger.Services.Data
{
    using BugLogger.Data.Repositories;
    using Models;
    using Server.DtoModels;
    using System;
    using System.Linq;

    public class BugServices : IBugServices
    {
        private readonly IRepository<Bug> bugs;

        public BugServices(IRepository<Bug> bugs)
        {
            this.bugs = bugs;
        }

        public IQueryable<Bug> All()
        {
            return this.bugs.All();
        }

        public IQueryable<Bug> AllAfterDate(DateTime date)
        {
            return this.bugs.All().Where(b => b.LogDate >= date);
        }

        public IQueryable<Bug> AllByStatus(Status status)
        {
            return this.bugs.All().Where(b => b.Status == status);
        }

        public IQueryable<Bug> AllByDateAndStatus(BugQuery query)
        {
            return this.bugs.All().Where(b => b.LogDate >= query.Date && b.Status == query.Status);
        }

        public int Update(int id, Bug bug)
        {
            var bugToUpdate = this.bugs.GetById(id);

            if (bugToUpdate == null)
            {
                throw new ArgumentNullException("The bug is not found");
            }
            bugToUpdate.Status = bug.Status;
            bugToUpdate.Text = bug.Text;

            this.bugs.Update(bugToUpdate);
            this.bugs.SaveChanges();

            return bugToUpdate.Id;
        }

        public void Add(Bug bug)
        {
            this.bugs.Add(bug);
            this.bugs.SaveChanges();
        }
    }
}
