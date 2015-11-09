using System;

namespace MusicSystem.Clients.ConsoleClient
{
    using Data.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main(string[] args)
        {
            // Change it with yours
            var connection = new Uri(string.Format("http://localhost:53815/"));

            // The other endpoints are on the way :)

            AddArtist(connection).Wait();

            GetArtists(connection).Wait();
        }

        private static async Task GetArtists(Uri connection)
        {
            HttpClient client = new HttpClient();

            using (client)
            {
                client.BaseAddress = connection;

                var response = await client.GetAsync("api/artists");

                if (response.IsSuccessStatusCode)
                {
                    var artists = await response.Content.ReadAsAsync<List<Artist>>();

                    artists.ToList().ForEach(a => Console.WriteLine(JsonConvert.SerializeObject(a, Formatting.Indented)));
                }
            }
        }

        private static async Task AddArtist(Uri connection)
        {
            HttpClient client = new HttpClient();
            using (client)
            {
                client.BaseAddress = connection;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var artistToAdd = new Artist()
                {
                    Name = "Disturbed",
                    Country = "USA",
                    Albums = new List<Album>(),
                    BirthDate = new DateTime(1998, 01, 02)
                };

                var json = JsonConvert.SerializeObject(artistToAdd);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsJsonAsync("api/artists", artistToAdd);

            }

        }
    }
}
