namespace Exam.WebApi.Tests.ControllerTests
{
    using Exam.WebApi.Tests.Setups;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using System.Collections.Generic;
    using System.Linq;
    using Web.Api.Controllers;
    using Web.Api.Models.HighScore;

    [TestClass]
    public class ScoresControllerTests
    {

        [TestMethod]

        public void GetShouldReturnCorrectHighScore()
        {
            MyWebApi
                .Controller<ScoresController>()
                .WithResolvedDependencies(Services.GetHighScoreService())
                .Calling(c => c.Get())
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<HighScoreResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(10, model.Count);

                    var first = model.First().Rank;
                    for (int i = 1; i < model.Count(); i++)
                    {
                        Assert.IsTrue(model[i].Rank <= first);
                        first = model[i].Rank;
                    }
                });
        }
    }
}
