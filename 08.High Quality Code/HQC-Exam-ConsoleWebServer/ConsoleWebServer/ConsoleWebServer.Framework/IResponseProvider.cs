namespace ConsoleWebServer.Framework
{
    /// <summary>
    /// IResponseProvider Interface.
    /// </summary>
    public interface IResponseProvider
    {
        /// <summary>
        /// Provide the response from the server.
        /// </summary>
        /// <param name="requestAsString">The request passed as string.</param>
        /// <returns>HttpResponse from the server.</returns>
        HttpResponse GetResponse(string requestAsString);
    }
}