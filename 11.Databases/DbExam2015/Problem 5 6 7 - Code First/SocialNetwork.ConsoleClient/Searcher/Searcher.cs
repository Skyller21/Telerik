namespace SocialNetwork.ConsoleClient.Searcher
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    public class DataSearcher
    {
        public static void Search(ISocialNetworkService searcher)
        {
            var users = searcher.GetUsersAfterCertainDate(2013);
            var postsByUsers = searcher.GetPostsByUser("ZtlKYHVN7h8SwMmaJs");
            var friendships = searcher.GetFriendships(2, 10);
            var chatUsers = searcher.GetChatUsers("ZtlKYHVN7h8SwMmaJs");

            var jsons = new List<string>
            {
                 JsonConvert.SerializeObject(users, Formatting.Indented),
                 JsonConvert.SerializeObject(postsByUsers, Formatting.Indented),
                 JsonConvert.SerializeObject(friendships, Formatting.Indented),
                 JsonConvert.SerializeObject(chatUsers, Formatting.Indented)
                 };

            for (int i = 1; i <= jsons.Count; i++)
            {
                var dir = new DirectoryInfo("../../../JSONResults");
                dir.Create();

                using (var writer = new StreamWriter(string.Format("../../../JSONResults/Result{0}.json", i)))
                {
                    writer.WriteLine(jsons[i - 1]);
                }
            }
        }
    }
}
