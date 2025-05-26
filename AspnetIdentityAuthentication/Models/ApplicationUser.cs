using Microsoft.AspNetCore.Identity;

namespace AspnetIdentityAuthentication.Models
{
    public class ApplicationUser:IdentityUser
    {
        public  string FullName { get; set; }
    }
}
