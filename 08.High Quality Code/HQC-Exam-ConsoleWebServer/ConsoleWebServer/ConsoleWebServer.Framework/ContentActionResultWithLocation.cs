namespace ConsoleWebServer.Framework
{
    public class ContentActionResultWithLocation : ContentActionResult
    {
        private const string HeaderName = "Location";
        private const string HeaderValue = "https://telerikacademy.com/Forum/Home";

        public ContentActionResultWithLocation(HttpRequest request, object model, IActionResult actionResult)
            : base(request, model)
        {
            this.ActionResult = actionResult;
        }

        public override HttpResponse GetResponse()
        {
            var response = base.GetResponse();
            response.AddHeader(HeaderName, HeaderValue);
            return response;
        }
    }
}
