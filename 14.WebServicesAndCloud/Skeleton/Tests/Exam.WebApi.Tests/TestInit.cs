namespace Exam.WebApi.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Web.Api;
    using Web.Common.Constants;

    [TestClass]
    public class TestInit
    {
        [AssemblyInitialize]
        public static void Init(TestContext testContext)
        {
            AutoMapperConfig.RegisterMappings(Assemblies.DtoModels);

        }
    }
}
