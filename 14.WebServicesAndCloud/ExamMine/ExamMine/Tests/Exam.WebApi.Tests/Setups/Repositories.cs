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
            var userRepository = new Mock<IRepository<User>>();

            userRepository.Setup(r => r.All()).Returns(() => new List<User>()
            {
                new User() { UserName = "TestUser 1", Comments = new List<Comment>()
                {
                    new Comment() { Content = "Test1"},
                    new Comment() { Content = "Test2"},
                    new Comment() { Content = "Test3"}
                }
                },
                new User() { UserName = "TestUser 2", Comments = new List<Comment>()
                {
                    new Comment() { Content = "Test1"},
                    new Comment() { Content = "Test2"},
                    new Comment() { Content = "Test3"}
                }
            }
            }.AsQueryable());



            return userRepository.Object;
        }

        public static IRepository<Comment> GetCommentsRepository()
        {
            var commentRepository = new Mock<IRepository<Comment>>();

            commentRepository.Setup(r => r.All()).Returns(() => new List<Comment>()
            {
                new Comment() { Content = "Test1", User = new User() {UserName = "TestUser 1"}},
                new Comment() { Content = "Test2", User = new User() {UserName = "TestUser 1"}},
                new Comment() { Content = "Test3", User = new User() {UserName = "TestUser 2"}},
                new Comment() { Content = "Test4", User = new User() {UserName = "TestUser 1"}},
                new Comment() { Content = "Test5", User = new User() {UserName = "TestUser 2"}},



            }.AsQueryable());



            return commentRepository.Object;
        }
    }

}

