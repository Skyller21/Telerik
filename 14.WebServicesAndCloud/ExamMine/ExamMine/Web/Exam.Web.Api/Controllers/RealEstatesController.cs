using System.Web.Http;

namespace Exam.Web.Api.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using DtoModels.Queries;
    using DtoModels.RealEstates;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using System;
    using System.Linq;

    public class RealEstatesController : ApiController
    {
        private IRealEstateServices realEstates;

        public RealEstatesController(IRealEstateServices realEstates)
        {
            this.realEstates = realEstates;
        }

        public IHttpActionResult Get([FromUri]QueryRealEstates query)
        {
            if (query == null)
            {
                query = new QueryRealEstates()
                {
                    Skip = 0,
                    Take = 10
                };
            }

            if (query.Skip == null)
            {
                query.Skip = 0;
            }

            if (query.Take == null)
            {
                query.Take = 10;
            }


            var result = this.realEstates.Top10RealEstates(query.Skip.Value, query.Take.Value).ProjectTo<RealEstateResponseModel>().ToList(); ;

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var estate = this.realEstates.GetById(id);
            if (estate == null)
            {
                return this.NotFound();
            }

            if (!this.User.Identity.IsAuthenticated)
            {
                var resultEstate = Mapper.Map<RealEstateExtendedResponseModel>(estate);
                return this.Ok(resultEstate);
            }
            else
            {
                var resultEstate = Mapper.Map<RealEstateResponseModelAuthenticated>(estate);
                return this.Ok(resultEstate);
            }

        }

        [Authorize]
        public IHttpActionResult Post(RealEstateResponseModelAuthenticated model)
        {
            try
            {
                var userId = this.User.Identity.GetUserId();


                if (!this.ModelState.IsValid)
                {
                    return this.BadRequest();
                }

                var addedEstate = this.realEstates.Add(Mapper.Map<RealEstate>(model), userId);

                return this.CreatedAtRoute("DefaultApi", "", Mapper.Map<RealEstateResponseModel>(addedEstate));

            }
            catch (ArgumentNullException)
            {
                // Cathes if the user is not created yet but you try to send token ;)
                return this.Unauthorized();
            }
        }

    }
}
