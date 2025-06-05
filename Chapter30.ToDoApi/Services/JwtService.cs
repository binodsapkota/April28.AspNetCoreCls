using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Chapter30.ToDoApi.Services
{
    public class JwtService
    {
        private readonly string _key;
        public JwtService(string key)
        {
            _key = key;
        }

        public string GenerateToken(string username,string role)
        {
            var claims=new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
                new Claim("full name","Binod Sapkota")
            };
            var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_key));
            var creds = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );
            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenStr;
        }
    }
}
