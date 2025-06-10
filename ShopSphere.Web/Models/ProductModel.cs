namespace ShopSphere.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        // Foreign Key to Category
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; } = null!;
    }
}
