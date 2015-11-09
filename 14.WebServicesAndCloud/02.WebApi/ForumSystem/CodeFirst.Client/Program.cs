namespace CodeFirst.Client
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    internal class Program
    {
        internal static void Main()
        {
            var client = new HttpClient();

            // Run the project Services and then change this address.
            // You can test the other endpoint with Postman :)
            var connection = new Uri("http://localhost:55935/");

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.GetAsync("api/posts").Result;
                Console.WriteLine(Environment.NewLine + "Posts: " + JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result));
            }
        }
    }
}