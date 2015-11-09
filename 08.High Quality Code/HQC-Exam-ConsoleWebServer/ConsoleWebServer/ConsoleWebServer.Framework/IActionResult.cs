namespace ConsoleWebServer.Framework
{
    using System.Collections.Generic;

    /// <summary>
    /// IActionResult Interface.
    /// </summary>
    public interface IActionResult
    {
        HttpRequest Request { get; set; }

        /// <summary>
        /// Gets the response of the server.
        /// </summary>
        /// <returns>HttpResponse from the server.</returns>
        HttpResponse GetResponse();
    }
}