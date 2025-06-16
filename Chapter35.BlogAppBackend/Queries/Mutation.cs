using Chapter35.BlogAppBackend.Models;

namespace Chapter35.BlogAppBackend.Queries
{
    public class Mutation
    {
        public async Task<BlogPostModel> AddBlogPost(string title,string content,string auther,[Service] BlogDbContext context)
        {
            var post = new BlogPostModel()
            {
                Author=auther,
                Content=content,
                Title=title,
                CreatedAt=DateTime.Now
            };

            context.BlogPosts.Add(post);
            await context.SaveChangesAsync();
            return post;
        }
    }
}
