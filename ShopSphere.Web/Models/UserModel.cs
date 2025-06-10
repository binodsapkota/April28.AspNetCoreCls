using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace ShopSphere.Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Role { get; set; } = "User";
    }
}
