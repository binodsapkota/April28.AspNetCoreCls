using ShopSphere.Web.Models;

namespace ShopSphere.Web.ViewModels
{
    public class ProductViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; }
        // Foreign Key to Category
        public int CategoryId { get; set; }

    }
}
