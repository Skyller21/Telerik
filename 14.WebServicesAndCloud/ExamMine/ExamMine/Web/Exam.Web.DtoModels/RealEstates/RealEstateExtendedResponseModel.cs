using System;

namespace Exam.Web.DtoModels.RealEstates
{
    using AutoMapper;
    using Data.Models;

    public class RealEstateExtendedResponseModel : RealEstateResponseModel
    {

        public DateTime CreatedOn { get; set; }

        public int ConstructionYear { get; set; }

        public string Address { get; set; }

        public string RealEstateType { get; set; }

        public string Description { get; set; }


        public override void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, RealEstateExtendedResponseModel>()
                .ForMember(r => r.CreatedOn,
                    opts => opts.MapFrom(a => a.CreationDate))
                    .ForMember(r => r.CanBeRented,
                    opts => opts.MapFrom(a => (a.PublishType == PublishType.Rent || a.PublishType == PublishType.RentAndSale) ? true : false))
                .ForMember(r => r.CanBeSold,
                    opts => opts.MapFrom(a => (a.PublishType == PublishType.Sale || a.PublishType == PublishType.RentAndSale) ? true : false));

        }
    }
}
