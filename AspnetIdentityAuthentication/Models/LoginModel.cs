using System.ComponentModel.DataAnnotations;

namespace AspnetIdentityAuthentication.Models
{
    public class LoginModel
    {
        [EmailAddress]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
