namespace BugLogger.Server.Api.Controllers
{
    using BugLogger.Models;
    using DtoModels;
    using Service.Common;
    using Services.Data;
    using System;
    using System.Web.Http;


    [RoutePrefix("api/bugs")]
    public class BugsController : ApiController
    {
        private readonly IBugServices bugService;
        private readonly IMappingService mappingService;

        public BugsController(IBugServices bugServices, IMappingService mappingService)
        {
            this.bugService = bugServices;
            this.mappingService = mappingService;
        }


        public IHttpActionResult Get([FromUri]BugQuery query)
        {
            if (query.Status == null && query.Date != null)
            {
                var allBugs = this.bugService.AllAfterDate(query.Date.Value);
                return this.Ok(allBugs);
            }
            else if (query.Status != null && query.Date == null)
            {
                var allBugs = this.bugService.AllByStatus(query.Status.Value);
                return this.Ok(allBugs);
            }
            else if (query.Status != null & query.Date != null)
            {
                var allBugs = this.bugService.AllByDateAndStatus(query);
                return this.Ok(allBugs);
            }

            var all = this.bugService.All();
            return this.Ok(all);
        }

        public IHttpActionResult Post(Bug bug)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            this.bugService.Add(bug);

            return this.Ok();
        }

        public IHttpActionResult Put(int id, BugUpdateRequestModel bug)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            try
            {

                var idBug = this.bugService.Update(id, this.mappingService.Map<Bug>(bug));
                return this.Ok(idBug);
            }
            catch (ArgumentNullException)
            {

                return this.NotFound();
            }
        }

    }
}