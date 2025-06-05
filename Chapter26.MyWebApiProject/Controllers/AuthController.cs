

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chapter26.MyWebApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly string _key = "ThisIsASecretKeyForJwtToken123!#";
       

        [HttpPost]
        public IActionResult Login([FromBody] Dtos.LoginDto loginDto)
        {

            if (loginDto.Username == "admin" && loginDto.Password == "password")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_key);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, loginDto.Username),
                    new Claim(ClaimTypes.Email,loginDto.Username),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new { token = tokenHandler.WriteToken(token) });

               
            }
            return Unauthorized("Invalid credentials"); 
        }
    }
}
