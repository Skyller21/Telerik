namespace ConsoleWebServer.Framework
{
    public class ContentActionResultWithCors : ContentActionResult
    {
        private const string HeaderName = "Access-Control-Allow-Origin";
        private const string HeaderValue = "*";

        public ContentActionResultWithCors(HttpRequest request, object model, IActionResult actionResult)
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