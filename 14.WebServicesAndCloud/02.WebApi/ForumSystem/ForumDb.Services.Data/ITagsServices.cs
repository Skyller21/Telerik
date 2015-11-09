namespace CodeFirst.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CodeFirst.Models;

    public interface ITagsServices
    {
        IQueryable<Tag> All();


        IEnumerable<Tag> TagsFromCommaSeparatedValues(string tagsAsCommaSeparatedValues);
        
    }
}