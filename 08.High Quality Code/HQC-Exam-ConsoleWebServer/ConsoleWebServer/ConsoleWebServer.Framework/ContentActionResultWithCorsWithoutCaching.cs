namespace ConsoleWebServer.Framework
{
    public class ContentActionResultWithCorsWithoutCaching : ContentActionResult
    {
        private const string HeaderAccessName = "Access-Control-Allow-Origin";
        private const string HeaderAccessValue = "*";
        private const string HeaderCacheName = "Cache-Control";
        private const string HeaderCacheValue = "private, max-age=0, no-cache";

        public ContentActionResultWithCorsWithoutCaching(HttpRequest request, object model, IActionResult actionResult)
            : base(request, model)
        {
            this.ActionResult = actionResult;
        }

        public override HttpResponse GetResponse()
        {
            var response = base.GetResponse();

            response.AddHeader(HeaderAccessName, HeaderAccessValue);
            response.AddHeader(HeaderCacheName, HeaderCacheValue);

            return response;
        }
    }
}