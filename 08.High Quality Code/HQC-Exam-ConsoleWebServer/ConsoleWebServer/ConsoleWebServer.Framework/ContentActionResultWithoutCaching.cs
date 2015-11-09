namespace ConsoleWebServer.Framework
{
    public class ContentActionResultWithoutCaching : ContentActionResult
    {
        private const string HeaderCacheName = "Cache-Control";
        private const string HeaderCacheValue = "private, max-age=0, no-cache";

        public ContentActionResultWithoutCaching(HttpRequest request, object model, IActionResult actionResult)
            : base(request, model)
        {
            this.ActionResult = actionResult;
        }

        public override HttpResponse GetResponse()
        {
            var response = base.GetResponse();
            response.AddHeader(HeaderCacheName, HeaderCacheValue);
            return response;
        }
    }
}