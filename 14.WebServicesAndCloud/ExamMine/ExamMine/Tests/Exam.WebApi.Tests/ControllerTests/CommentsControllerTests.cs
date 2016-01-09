namespace Exam.WebApi.Tests.ControllerTests
{
    using Exam.WebApi.Tests.Setups;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using System.Collections.Generic;
    using Web.Api.Controllers;
    using Web.DtoModels;
    using Web.DtoModels.Queries;

    [TestClass]
    public class CommentsControllerTests
    {

        [TestMethod]

        public void GetWithSkipShouldReturnFiltered()
        {
            MyWebApi
                .Controller<CommentsController>()
                .WithResolvedDependencies(Services.GetCommentServices())
                .Calling(c => c.Get("TestUser 1", new QueryRealEstates() { Skip = 1 }))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(2, model.Count);
                });
        }

        [TestMethod]
        public void GetWithoutQueryShouldReturnFiltered()
        {
            MyWebApi
                .Controller<CommentsController>()
                .WithResolvedDependencies(Services.GetCommentServices())
                .Calling(c => c.Get("TestUser 1", null))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(3, model.Count);
                });
        }

        [TestMethod]
        public void GetWithTakeShouldReturnFiltered()
        {
            MyWebApi
                .Controller<CommentsController>()
                .WithResolvedDependencies(Services.GetCommentServices())
                .Calling(c => c.Get("TestUser 1", new QueryRealEstates() { Take = 1 }))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(1, model.Count);
                });
        }

        [TestMethod]
        public void GetWithBothShouldReturnFiltered()
        {
            MyWebApi
                .Controller<CommentsController>()
                .WithResolvedDependencies(Services.GetCommentServices())
                .Calling(c => c.Get("TestUser 1", new QueryRealEstates() { Skip = 1, Take = 2 }))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(2, model.Count);
                });
        }

        [TestMethod]
        public void GetWithBothBiggerShouldReturnFiltered()
        {
            MyWebApi
                .Controller<CommentsController>()
                .WithResolvedDependencies(Services.GetCommentServices())
                .Calling(c => c.Get("TestUser 1", new QueryRealEstates() { Skip = 3, Take = 3 }))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(0, model.Count);
                });
        }

        [TestMethod]
        public void GetWithBothZeroShouldReturnFiltered()
        {
            MyWebApi
                .Controller<CommentsController>()
                .WithResolvedDependencies(Services.GetCommentServices())
                .Calling(c => c.Get("TestUser 1", new QueryRealEstates() { Skip = 0, Take = 0 }))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(0, model.Count);
                });
        }

        [TestMethod]
        public void GetWithInvalidUserShouldReturnEmpty()
        {
            MyWebApi
                .Controller<CommentsController>()
                .WithResolvedDependencies(Services.GetCommentServices())
                .Calling(c => c.Get("Invalid User", new QueryRealEstates() { Skip = 3, Take = 3 }))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(0, model.Count);
                });
        }
    }
}

