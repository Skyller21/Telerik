using StringClient.MyStringService;
using System;

namespace StringClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new StringSearchingServiceClient();

            using (client)
            {
                var text = "pepepepep pesho e pechen";
                var searched = "pe";
                var count = client.FindStringInString(text, searched, true);

                Console.WriteLine($"The string \"{searched}\" is found {count} times in \"{text}\"");
            }
        }
    }
}
