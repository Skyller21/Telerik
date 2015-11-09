using System.Web.Http;

namespace MusicSystem.Server.Api
{
    using App_Start;
    using System.Reflection;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load("MusicSystem.Server.Common"));
            DatabaseConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
