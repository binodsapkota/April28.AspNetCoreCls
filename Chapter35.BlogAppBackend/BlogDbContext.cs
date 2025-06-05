using Chapter35.BlogAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter35.BlogAppBackend
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<BlogPostModel> BlogPosts { get; set; }


    }
}
