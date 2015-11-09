namespace ConsoleWebServer.Application
{
    using Framework;

    public static class Startup
    {
        // TODO: Describe patterns, SOLID, bugs and bottleneck in Documentation.txt
        public static void Main()
        {
            IResponseProvider responseProvider = new ResponseProvider();

            var webSever = new WebServer(responseProvider);

            webSever.Start();
        }
    }
}