using Microsoft.AspNetCore.Authorization;

namespace AspnetIdentityAuthentication
{
    public class MinimumAgeRequirement:IAuthorizationRequirement
    {
        public int MinimumAge { get; }
        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }
}
