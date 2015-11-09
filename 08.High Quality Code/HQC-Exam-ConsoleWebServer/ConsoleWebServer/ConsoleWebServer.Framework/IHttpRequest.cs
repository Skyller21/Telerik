namespace ConsoleWebServer.Framework
{
    public interface IHttpRequest
    {
        void AddHeader(string name, string value);
    }
}
