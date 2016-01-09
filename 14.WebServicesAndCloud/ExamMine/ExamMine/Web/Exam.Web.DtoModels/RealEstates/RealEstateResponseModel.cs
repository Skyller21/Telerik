namespace Exam.Web.DtoModels.RealEstates
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class RealEstateResponseModel : IMapFrom<RealEstate>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public virtual void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, RealEstateResponseModel>()
                .ForMember(r => r.CanBeRented,
                    opts => opts.MapFrom(a => (a.PublishType == PublishType.Rent || a.PublishType == PublishType.RentAndSale) ? true : false))
                .ForMember(r => r.CanBeSold,
                    opts => opts.MapFrom(a => (a.PublishType == PublishType.Sale || a.PublishType == PublishType.RentAndSale) ? true : false));
        }
    }
}
