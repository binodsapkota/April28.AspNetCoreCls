using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ShopSphere.Web.ViewModels
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Full name is required.")]
        public string Fullname { get; set; } = "";
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = "";
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = "";
        [Required(ErrorMessage = "Zip code is required.")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid zip code format.")]
        public string ZipCode { get; set; } = "";
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; } = "";
        [ValidateNever]
        public List<CartItemViewModel> CartItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
