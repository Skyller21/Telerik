namespace SocialNetwork.ConsoleClient.Searcher
{
    using System.Collections;
    using System.Linq;
    using Data;

    public class SocialNetworkSearcher : ISocialNetworkService
    {
        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            var ctx = new SocialNetworkContext();

            var users = ctx.Users
            .Select(u => new
            {
                u.Username,
                u.FirstName,
                u.LastName,
                u.RegDate,
                ImagesCount = u.Images.Count
            })
            .Where(u => u.RegDate.Year >= year)
            .OrderBy(u => u.RegDate)
            .ToList();

            return users;
        }

        public IEnumerable GetPostsByUser(string username)
        {
            var ctx = new SocialNetworkContext();

            var posts = ctx.Posts
            .Select(p => new
            {
                p.PostDate,
                p.Content,
                TaggedUsers = p.TaggedUsers.Select(u => u.Username)
            })
            .OrderBy(p => p.PostDate)
            .ToList();

            return posts;
        }

        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            var ctx = new SocialNetworkContext();

            var friendships = ctx.Friendships
            .OrderBy(f => f.ApprovalDate)
            .Select(f => new
            {
                FirstUserUsername = f.FirstUser.Username,
                FirstUserImage = f.FirstUser.Images.FirstOrDefault().Url ?? "N/A",
                SecondUserUsername = f.SecondUser.Username,
                SecondUserImage = f.FirstUser.Images.FirstOrDefault().Url ?? "N/A",
            })
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

            return friendships;
        }

        public IEnumerable GetChatUsers(string username)
        {
            var ctx = new SocialNetworkContext();

            var user = ctx.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return null;
            }

            var uniqueUsersChattedWith =
                ctx.Friendships
                    .Where(f => f.FirstUser.FirstName == user.Username || f.SecondUser.Username == user.Username)
                    .Select(u => new
                    {
                        Username = u.FirstUser.Username == username ? u.SecondUser.Username : u.FirstUser.Username
                        
                        //// Uncomment it to see that the messages are more than 0 :)
                        //// CountMessages = u.Messages.Count
                    })
                    .GroupBy(u => u.Username)
                    .OrderBy(u => u.Key)
                    .ToList();

            return uniqueUsersChattedWith;
        }
    }
}
