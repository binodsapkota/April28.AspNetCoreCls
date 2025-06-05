using System.ComponentModel.DataAnnotations;

namespace Chapter35.BlogAppBackend.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "User";

    }
}
