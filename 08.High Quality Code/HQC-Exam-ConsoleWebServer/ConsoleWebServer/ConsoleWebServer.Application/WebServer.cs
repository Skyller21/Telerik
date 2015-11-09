﻿namespace ConsoleWebServer.Application
{
    using System;
    using System.Text;
    using Framework;

    public class WebServer
    {
        private readonly IResponseProvider responseProvider;

        public WebServer(IResponseProvider responseProvider)
        {
            this.responseProvider = responseProvider;
        }

        public void Start()
        {
            var requestBuilder = new StringBuilder();
            string inputLine;
            while ((inputLine = Console.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    var response = this.responseProvider.GetResponse(requestBuilder.ToString());
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(response);
                    Console.ResetColor();
                    requestBuilder.Clear();
                    continue;
                }

                requestBuilder.AppendLine(inputLine);
            }
        }
    }
}