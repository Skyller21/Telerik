namespace Exam.Services.Data
{
    using Contracts;
    using Exam.Data.Models;
    using Exam.Data.Repositories;
    using System;
    using System.Linq;

    public class RealEstateServices : IRealEstateServices
    {
        private readonly IRepository<RealEstate> realEstates;
        private readonly IRepository<User> users;

        public RealEstateServices(IRepository<RealEstate> realEstates, IRepository<User> users)
        {
            this.realEstates = realEstates;
            this.users = users;
        }

        public IQueryable<RealEstate> Top10RealEstates(int skip, int take)
        {

            var result = this.realEstates
                .All()
                .OrderByDescending(re => re.CreationDate)
                .Skip(skip)
                .Take(take);

            return result;
        }

        public RealEstate GetById(int id)
        {
            var estate = this.realEstates.GetById(id);

            return estate;
        }

        public RealEstate Add(RealEstate model, string userId)
        {
            var user = this.users.GetById(userId);

            if (user == null)
            {
                throw new ArgumentNullException("The user is not registered!");
            }

            var estateToAdd = new RealEstate()
            {
                User = user,
                Title = model.Title,
                Description = model.Description,
                Contact = model.Contact,
                Address = model.Address,
                ConstructionYear = model.ConstructionYear,
                SellingPrice = model.SellingPrice,
                RentingPrice = model.RentingPrice,
                CreationDate = DateTime.Now,
                RealEstateType = model.RealEstateType

            };


            if (model.RentingPrice != 0 && model.SellingPrice != 0)
            {
                estateToAdd.PublishType = PublishType.RentAndSale;
            }
            else if (model.RentingPrice != 0 && model.SellingPrice == 0)
            {
                estateToAdd.PublishType = PublishType.Rent;
            }
            else if (model.RentingPrice == 0 && model.SellingPrice != 0)
            {
                estateToAdd.PublishType = PublishType.Sale;
            }




            this.realEstates.Add(estateToAdd);

            this.realEstates.SaveChanges();

            return estateToAdd;

        }
    }
}
