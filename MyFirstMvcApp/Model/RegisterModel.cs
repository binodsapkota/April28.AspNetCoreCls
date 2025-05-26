using MyFirstMvcApp.Filters;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MyFirstMvcApp.Model
{
    public class RegisterModel
    {
        public int Id { get; set; }

        [StringLength(150), Required(ErrorMessage = "Please Input Your full name")]
        [MinLength(10)]
        [RegularExpression(@"^[^\s]+( [^\s]+)+$", ErrorMessage = "Full name must not start or end with a space, must contain at least one space, and must not have multiple consecutive spaces.")]
        public string FullName { get; set; }


        [EmailAddress(ErrorMessage = "Please Input Valid Email Address"), Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //[Url]
        //public string WebUrl { get; set; }

        //[DataType(DataType.Date)]
        //[AgeValidation(MinimumAge = 18, MaximumAge = 60, ErrorMessage = "You must be at least 18 years old to register.")]
        //public DateTime DOB { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }

        [Compare("Password"),DataType(DataType.Password)]
        public string ComparePassword { get; set; }

    }
}
