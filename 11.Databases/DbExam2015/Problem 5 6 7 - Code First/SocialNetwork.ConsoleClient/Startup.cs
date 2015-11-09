namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Models;
    using Models.ModelsDTO;
    using Searcher;

    public class Startup
    {
        public static void Main()
        {
            CreateDb();
            //ImportAllData();

            //DataSearcher.Search(new SocialNetworkSearcher());
        }

        private static void ImportAllData()
        {
            // Deserialize friendships
            var friendships = DeserializeFrindships();

            // Desrialize posts
            var posts = DeserializePosts();

            // Import Friendships, Users, Messages, Images from the file
            ImportFriendshipsFromFile(friendships);

            // Import the posts and the tags of the user.
            ImportPostsFromFile(posts);
        }

        private static void ImportPostsFromFile(List<PostDto> posts)
        {
            Console.Write("Importing posts");
            var ctx = new SocialNetworkContext();
            var counter = 0;
            var users = ctx.Users.ToList();
            foreach (var postDto in posts)
            {
                var taggedUsers = postDto.Users.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var postToAdd = new Post()
                {
                    Content = postDto.Content,
                    PostDate = postDto.PostedOn,
                    TaggedUsers = new List<User>()
                };

                var usersToAddTagTo = new List<User>();

                var dict = new Dictionary<User, List<Post>>();

                foreach (var taggedUser in taggedUsers)
                {
                    var user = (User)users.FirstOrDefault(u => u.Username == taggedUser);

                    usersToAddTagTo.Add(user);
                    user.PostsTaggedIn.Add(postToAdd);

                    if (!dict.ContainsKey(user))
                    {
                        dict.Add(user, new List<Post>() { postToAdd });
                    }
                    else
                    {
                        dict[user].Add(postToAdd);
                    }
                }

                postToAdd.TaggedUsers.ToList().AddRange(usersToAddTagTo);
                counter++;

                if (counter % 10 == 0)
                {
                    Console.Write(".");
                }

                if (counter % 1000 == 0)
                {
                    foreach (var entry in dict)
                    {
                        ctx.Users.FirstOrDefault(u => u.Username == entry.Key.Username)
                            .PostsTaggedIn.ToList()
                            .AddRange(entry.Value);
                    }

                    ctx.SaveChanges();
                    ctx.Dispose();
                    ctx = new SocialNetworkContext();
                    users = ctx.Users.ToList();
                }
            }

            Console.WriteLine();
        }

        private static void ImportFriendshipsFromFile(List<FriendshipDto> friendships)
        {
            var ctx = new SocialNetworkContext();

            var users = ctx.Users.ToList();

            var counter = 0;
            Console.Write("Importing users, freindships");
            foreach (var friendship in friendships)
            {
                var firstUser = friendship.FirstUser;
                var secondUser = friendship.SecondUser;

                var check = CheckUserToAdd(users, firstUser, ctx);
                var check1 = CheckUserToAdd(users, secondUser, ctx);
                if (check || check1)
                {
                    ctx.SaveChanges();
                }
                else
                {
                    continue;
                }

                counter++;

                var firstUserFriendship = ctx.Users.Select(u => new
                {
                    u.Id,
                    u.Username
                }).FirstOrDefault(u => u.Username == firstUser.Username);

                var secondUserFriendship = ctx.Users.Select(u => new
                {
                    u.Id,
                    u.Username
                }).FirstOrDefault(u => u.Username == secondUser.Username);

                var friendshipToAdd = new Friendship()
                {
                    FirstUserId = firstUserFriendship.Id,
                    SecondUserId = secondUserFriendship.Id,
                    ApprovalDate = friendship.FriendsDate,
                    IsApproved = bool.Parse(friendship.IsApproved),
                    Messages = new List<Message>()
                };

                ctx.Friendships.Add(friendshipToAdd);

                var messages = friendship.Messages;

                foreach (var messageDto in messages)
                {
                    var author = ctx.Users.Select(u => new
                    {
                        u.Id,
                        u.Username
                    }).FirstOrDefault(a => a.Username == messageDto.Author);

                    var messageToAdd = new Message()
                    {
                        AuthorId = author.Id,
                        Content = messageDto.Content,
                        SendDate = messageDto.SentOn,
                        SeenDate = messageDto.SeenOn
                    };
                    ctx.Messages.Add(messageToAdd);
                }

                ctx.SaveChanges();

                if (counter % 10 == 0)
                {
                    Console.Write(".");
                }

                if (counter % 100 == 0)
                {
                    ctx.SaveChanges();
                    ctx.Dispose();
                    ctx = new SocialNetworkContext();
                }
            }

            Console.WriteLine();
        }

        private static bool CheckUserToAdd(List<User> users, UserDto user, SocialNetworkContext ctx)
        {
            if (!users.Any(u => u.Username == user.Username))
            {
                var images = user.Images;

                var userToAdd = new User()
                {
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RegDate = user.RegisteredOn,
                    Images = new List<Image>(),
                    PostsTaggedIn = new List<Post>()
                };

                foreach (var imageDto in images)
                {
                    var imageToAdd = new Image()
                    {
                        Url = imageDto.ImageUrl,
                        Extension = imageDto.FileExtension,
                        UserId = userToAdd.Id
                    };

                    ctx.Images.Add(imageToAdd);
                    userToAdd.Images.Add(imageToAdd);
                }

                ctx.Users.Add(userToAdd);
                users.Add(userToAdd);
                return true;
            }

            return false;
        }

        private static List<PostDto> DeserializePosts()
        {
            List<PostDto> posts;
            XmlSerializer mySerializerPosts = new XmlSerializer(typeof(List<PostDto>), new XmlRootAttribute("Posts"));

            using (FileStream myFileStream = new FileStream("XMLFiles/Posts.xml", FileMode.Open))
            {
                posts = (List<PostDto>)mySerializerPosts.Deserialize(myFileStream);
            }

            return posts;
        }

        private static List<FriendshipDto> DeserializeFrindships()
        {
            List<FriendshipDto> friendships;
            XmlSerializer mySerializerFriendships = new XmlSerializer(typeof(List<FriendshipDto>), new XmlRootAttribute("Friendships"));

            using (FileStream myFileStream = new FileStream("XMLFiles/Friendships.xml", FileMode.Open))
            {
                friendships = (List<FriendshipDto>)mySerializerFriendships.Deserialize(myFileStream);
            }

            return friendships;
        }

        private static void CreateDb()
        {
            var ctx = new SocialNetworkContext();

            var users = ctx.Users.ToList();

            ctx.SaveChanges();
        }
    }
}
