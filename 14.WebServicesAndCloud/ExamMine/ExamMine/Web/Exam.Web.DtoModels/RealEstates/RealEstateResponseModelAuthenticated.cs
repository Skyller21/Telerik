using System.Collections.Generic;

namespace Exam.Web.DtoModels.RealEstates
{
    using AutoMapper;
    using Data.Models;

    public class RealEstateResponseModelAuthenticated : RealEstateExtendedResponseModel
    {
        public string Contact { get; set; }

        public ICollection<CommentResponseModel> Comments { get; set; }

        public override void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, RealEstateResponseModelAuthenticated>()
                .ForMember(r => r.CreatedOn,
                    opts => opts.MapFrom(a => a.CreationDate))
                    .ForMember(r => r.CanBeRented,
                    opts => opts.MapFrom(a => (a.PublishType == PublishType.Rent || a.PublishType == PublishType.RentAndSale) ? true : false))
                .ForMember(r => r.CanBeSold,
                    opts => opts.MapFrom(a => (a.PublishType == PublishType.Sale || a.PublishType == PublishType.RentAndSale) ? true : false))
                    .ForMember(r => r.Contact, opts => opts.MapFrom(p => p.Contact))
                    .ForMember(r => r.Comments, opts => opts.MapFrom(g => g.Comments));

        }
    }
}
