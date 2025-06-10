using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ShopSphere.Web.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ValidateNever]
        public ICollection<ProductModel> Products { get; set; }

    }
}
