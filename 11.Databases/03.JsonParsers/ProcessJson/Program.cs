using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace ProcessJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileLocation = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            string downloadLocation = "../../../telerik-rss.xml";

            // Download the file
            DownloadFile(fileLocation, downloadLocation);

            // Parse the xml to json
            var doc = XDocument.Load(downloadLocation);
            var json = JsonConvert.SerializeXNode(doc, Formatting.Indented);

            // Convert to POCOs
            var jsonObject = JObject.Parse(json);
            var videos = jsonObject["feed"]["entry"].Select(e => JsonConvert.DeserializeObject<Video>(e.ToString()));


            // HTML
            var str = GenerateHtml(videos);

            // Save File
            File.WriteAllText("../../../index.html", str, Encoding.UTF8);

            Console.WriteLine("File generated");

        }

        private static string GenerateHtml(IEnumerable<Video> videos)
        {
            var str = new StringBuilder();

            str.Append("<!DOCTYPE html>");
            str.Append("<html><head><title>Telerik Latest Videos</title></head><body>");

            foreach (var video in videos)
            {
                str.AppendFormat(
                    "<div style=\"background:grey; color:white; width:450px; padding:10px; margin:10px;\"><h3><a style=\"text-decoration:none; color:white;\" href=\"{0}\">{1}</a></h3><iframe width=\"420\" height=\"315\" src=\"http://www.youtube.com/embed/{2}?autoplay=0\"></iframe><h3>{3}</h3></div>",
                    video.Link.Href,
                    video.Title,
                    video.Id,
                    video.Published.ToShortDateString());
            }

            str.Append("</body></html>");
            return str.ToString();
        }

        private static void DownloadFile(string fileLocation, string downloadLocation)
        {
            var client = new WebClient();
            try
            {
                using (client)
                {
                    client.DownloadFile(fileLocation, downloadLocation);
                }
            }

            catch (WebException)
            {
                Console.WriteLine("Wrong file name or no internet connection!");
            }
        }
    }
}
