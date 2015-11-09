using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Services.Data
{
    using CodeFirst.Models;
    using Models.Posts;

    public interface IPostsServices
    {
        IQueryable<Post> All();

        void Add(Post post, string creator, IEnumerable<Tag> tags);

        void Update(int id, Post post, string creator, IEnumerable<Tag> tags);
    }
}
