using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst.Services.Data
{
    using CodeFirst.Data;
    using CodeFirst.Data.Repositories;
    using CodeFirst.Models;

    public class TagsServices : ITagsServices
    {
        private readonly IRepository<Tag> tags;

        public TagsServices(IRepository<Tag> tagsRepo)
        {
            var db = new ForumDbContext();
            this.tags = tagsRepo;

        }

        public IQueryable<Tag> All()
        {
            return this.tags.All().AsQueryable();
        }

        public IEnumerable<Tag> TagsFromCommaSeparatedValues(string tagsAsCommaSeparatedValues)
        {
            if (string.IsNullOrWhiteSpace(tagsAsCommaSeparatedValues))
            {
                return Enumerable.Empty<Tag>();
            }

            var existingTagIds = new HashSet<int>();
            var tagNames = new HashSet<string>();

            tagsAsCommaSeparatedValues.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList()
                        .ForEach(tag =>
                        {
                            int tagId;
                            if (int.TryParse(tag, out tagId))
                            {
                                existingTagIds.Add(tagId);
                            }
                            else
                            {
                                tagNames.Add(tag.ToLower());
                            }
                        });

            var resultTags = this.tags
                .All()
                .Where(t => existingTagIds.Contains(t.TagId) || tagNames.Contains(t.Text))
                .ToList();

            this.tags
                .All()
                .Where(t => tagNames.Contains(t.Text.ToLower()))
                .Select(t => t.Text.ToLower())
                .ToList()
                .ForEach(t => tagNames.Remove(t));

            resultTags.AddRange(tagNames.Select(tagName => new Tag { Text = tagName }));

            return resultTags;
        }
    }
}
