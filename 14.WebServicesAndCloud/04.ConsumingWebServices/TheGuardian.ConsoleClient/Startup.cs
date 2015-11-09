using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGuardian.ConsoleClient
{
    using Newtonsoft.Json;
    using System.Net.Http;

    class Startup
    {
        static void Main(string[] args)
        {
            // The Guardian API as feedzilla is not working anymore
            // http://open-platform.theguardian.com/explore/
            var connection = new Uri("http://content.guardianapis.com/");

            var input = ProcessIO(new Input());


            Console.WriteLine("\n===============================");
            Console.WriteLine("Review the provided links :)\n");
            string queryString = GeneratQueryString(input.Search, input.Category, input.StartDate, input.EndDate, input.PageSize);

            SearchInGuardian(connection, queryString).Wait();
        }

        private static Input ProcessIO(Input input)
        {
            Console.WriteLine("Enter a string to search: (ex. Dimitrov)");
            input.Search = Console.ReadLine().ToLower();

            Console.WriteLine("\nEnter a category to search in (categories: sport,politics,environment,tech,world):");
            input.Category = Console.ReadLine().ToLower();

            Console.WriteLine("\nEnter a start date: (if not entered will not apply)");
            var dateAsString = Console.ReadLine();
            input.StartDate = null;
            if (!string.IsNullOrEmpty(dateAsString))
            {
                input.StartDate = DateTime.Parse(dateAsString);
            }

            Console.WriteLine("\nEnter an end date: (if not entered will not apply)");
            dateAsString = Console.ReadLine();
            input.EndDate = null;
            if (!string.IsNullOrEmpty(dateAsString))
            {
                input.EndDate = DateTime.Parse(dateAsString);
            }

            Console.WriteLine("\nEnter results count to show (if not entered will show all. Max is 200.):");
            input.PageSize = null;
            var pageAsString = Console.ReadLine();
            if (!string.IsNullOrEmpty(pageAsString))
            {
                input.PageSize = int.Parse(pageAsString);
            }
            return input;
        }

        private static async Task SearchInGuardian(Uri connection, string queryString)
        {
            var client = new HttpClient();

            using (client)
            {
                client.BaseAddress = connection;

                var response = await client.GetAsync("search?" + queryString);

                if (response.IsSuccessStatusCode)
                {
                    var artists = response.Content.ReadAsStringAsync().Result;

                    var responseResult = JsonConvert.DeserializeObject<ApiResponse>(artists);

                    if (!responseResult.Response.Results.Any())
                    {
                        Console.WriteLine("No result found!");
                        return;
                    }

                    var responseResultSorted = responseResult.Response.Results.OrderBy(r => r.DatePublished);

                    foreach (var result in responseResultSorted)
                    {
                        Console.WriteLine("{0}", result.Section);
                        Console.WriteLine("Title: {0} - Date: {1}", result.Title, result.DatePublished.ToShortDateString());
                        Console.WriteLine("Link: {0}\n", result.Url);
                    }
                }
                else
                {
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        private static string GeneratQueryString(string search, string category, DateTime? startDate, DateTime? endDate, int? pageSize)
        {
            var queryString = new StringBuilder();
            if (!string.IsNullOrEmpty(category))
            {
                queryString.Append("section=");
                queryString.Append(category + "&");
            }

            if (pageSize == null || pageSize > 200)
            {
                queryString.Append("page-size=");
                queryString.Append(200 + "&");
            }
            else
            {
                queryString.Append("page-size=");
                queryString.Append(pageSize + "&");
            }

            if (startDate != null)
            {
                queryString.Append("from-date=");
                queryString.Append(startDate.Value.Year + "-" + startDate.Value.Month + "-" + startDate.Value.Day + "&");
            }

            if (endDate != null)
            {
                queryString.Append("to-date=");
                queryString.Append(endDate.Value.Year + "-" + endDate.Value.Month + "-" + endDate.Value.Day + "&");
            }

            queryString.Append("q=");
            queryString.Append(search + "&");
            queryString.Append("api-key=test");

            return queryString.ToString();
        }
    }
}
