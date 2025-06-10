using Microsoft.Build.Framework.Profiler;
using Microsoft.EntityFrameworkCore;
using ShopSphere.Web.Models;

namespace ShopSphere.Web.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Models.UserModel> Users { get; set; }
        public DbSet<ProductModel>  Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

        }

    }
}
