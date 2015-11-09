using System.Linq;

namespace CodeFirst.Services.Data
{
    using CodeFirst.Data;
    using CodeFirst.Data.Repositories;
    using CodeFirst.Models;
    using CodeFirst.Models.ServiceModels;
    using System;
    using System.Collections.Generic;

    public class PostsServices : IPostsServices
    {
        private readonly IRepository<Post> posts;
        private readonly IRepository<User> users;
        private readonly IRepository<Category> categories;

        public PostsServices(IRepository<Post> postsRepo, IRepository<User> usersRepo, IRepository<Category> categoriesRepo)
        {
            var db = new ForumDbContext();
            this.posts = postsRepo;
            this.users = usersRepo;
            this.categories = categoriesRepo;
        }

        public IQueryable<Post> All()
        {
            return this.posts.All();
        }

        public void Add(Post post, string creator, IEnumerable<Tag> tags)
        {
            var currentUser = this.users.All().FirstOrDefault(u => u.UserName == creator);

            var postToAdd = new Post()
            {
                Title = post.Title,
                Tags = new List<Tag>(),

                Content = post.Content,
                CreatedOn = DateTime.Now,
            };

            var cat = this.categories.All().FirstOrDefault(c => c.Name == post.Category.Name);
            if (cat != null)
            {
                postToAdd.Category = cat;
            }
            else
            {
                var newCategory = new Category()
                {
                    Name = post.Category.Name
                };

                this.categories.Add(newCategory);
                this.categories.SaveChanges();

                postToAdd.Category = newCategory;
            }



            postToAdd.User = currentUser;

            foreach (var tag in tags)
            {
                postToAdd.Tags.Add(tag);
            }

            this.posts.Add(postToAdd);

            this.posts.SaveChanges();

        }

        public void Update(int id, Post post, string creator, IEnumerable<Tag> tags)
        {

            var postFound = this.posts.All().FirstOrDefault(p => p.PostId == id);

            if (postFound == null)
            {
                throw new ArgumentException();
            }

            if (postFound.User.UserName != creator)
            {
                throw new InvalidOperationException();
            }

            postFound.Content = post.Content;

            foreach (var tag in tags)
            {
                if (postFound.Tags.All(t => t.Text != tag.Text))
                {
                    postFound.Tags.Add(tag);
                }
            }

            this.posts.SaveChanges();
        }
    }
}