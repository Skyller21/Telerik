namespace Exam.Web.DtoModels.RealEstates
{
    using AutoMapper;
    using Common.Constants;
    using Common.Mapping;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class RealEstateRequestModel : IMapFrom<RealEstate>, IHaveCustomMappings
    {
        [Required]
        [MinLength(RealEstateConstants.TitleMinLength)]
        [MaxLength(RealEstateConstants.TitleMaximumLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(RealEstateConstants.DescriptionMinLength)]
        [MaxLength(RealEstateConstants.DescriptionMaximumLength)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        [Range(1800, int.MaxValue)]
        public int ConstructionYear { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal RentingPrice { get; set; }

        public int Type { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, RealEstateRequestModel>()
                .ForMember(r => r.Type, opts => opts.MapFrom(g => g.RealEstateType));
            //.ForMember(r => r.RentingPrice, opts => opts.MapFrom(g =>
            //(this.RentingPrice != null && this.SellingPrice != null) ?
            //2 : (this.RentingPrice != null && this.SellingPrice == null) ?
            //0 : 1));

        }
    }
}
