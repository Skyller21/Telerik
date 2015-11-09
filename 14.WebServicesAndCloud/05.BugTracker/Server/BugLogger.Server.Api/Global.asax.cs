using System.Web.Http;

namespace BugLogger.Server.Api
{
    using App_Start;
    using System.Reflection;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            AutomapperConfig.RegisterMappings(Assembly.Load("BugLogger.Server.DtoModels"));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
