namespace ConsoleWebServer.Application.Controllers
{
    using System;
    using Framework;

    public class HomeController : Controller
    {
        public HomeController(HttpRequest request)
            : base(request)
        {
        }

        public IActionResult Index(string param)
        {
            return this.Content("Home page :)");
        }

        public IActionResult LivePage(string param)
        {
            return new ContentActionResultWithoutCaching(this.Request, "Live page with no caching", this.Content(string.Empty));
        }

        public IActionResult LivePageForAjax(string param)
        {
            return new ContentActionResultWithCorsWithoutCaching(this.Request, "Live page with no caching and CORS", this.Content(string.Empty));
        }

        public IActionResult Forum(string param)
        {
            return new ContentActionResultWithLocation(this.Request, string.Empty, this.Content(string.Empty));
        }
    }
}