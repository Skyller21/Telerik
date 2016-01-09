namespace Exam.WebApi.Tests.Setups
{
    using Data.Models;
    using Data.Repositories;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;

    public static class Repositories
    {
        public static IRepository<User> GetUsersRepository()
        {
            var repository = new Mock<IRepository<User>>();

            repository.Setup(r => r.All()).Returns(() => new List<User>()
            {
                new User()
                {
                    Email = "TestUser1", Rank = 100,

                },
                new User()
                {
                    Email = "TestUser2", Rank = 50,

                },new User()
                {
                    Email = "TestUser3", Rank = 3500,

                },new User()
                {
                    Email = "TestUser4", Rank = 200,

                },new User()
                {
                    Email = "TestUser5", Rank = 100,

                },
                 new User()
                {
                    Email = "TestUser6", Rank = 100,

                },
                new User()
                {
                    Email = "TestUser7", Rank = 50,

                },new User()
                {
                    Email = "TestUser8", Rank = 3500,

                },new User()
                {
                    Email = "TestUser9", Rank = 200,

                },new User()
                {
                    Email = "TestUser10", Rank = 100,

                },
                new User()
                {
                    Email = "TestUser11", Rank = 100,

                }
            }.AsQueryable());

            return repository.Object;
        }
    }

}
