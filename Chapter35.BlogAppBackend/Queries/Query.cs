using Chapter35.BlogAppBackend.Models;
using HotChocolate.Authorization;
using HotChocolate.Data;
namespace Chapter35.BlogAppBackend.Queries
{
    public class Query
    {
        [Authorize] // This attribute is part of HotChocolate.AspNetCore.Authorization
        [UseProjection] // This attribute is part of HotChocolate.Data
        [UseFiltering] // This attribute is part of HotChocolate.Data
        [UseSorting] // This attribute is part of HotChocolate.Data
        public IQueryable<BlogPostModel> GetBlogPosts([Service] BlogDbContext context)
        {
            return context.BlogPosts;
        }
    }
}
