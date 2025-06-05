

using Chapter35.BlogAppBackend.Dtos;
using Chapter35.BlogAppBackend.Models;
using Chapter35.BlogAppBackend.Services;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chapter35.BlogAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthApiController : ControllerBase
    {

        private readonly BlogDbContext _context;
        
        private readonly JwtSettings _jwtSettings;
        public AuthApiController(BlogDbContext blogDbContext, JwtSettings jwt)
        {
            _context = blogDbContext;
            _jwtSettings = jwt;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserModel loginDto)
        {

            var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == loginDto.Username && u.Password == loginDto.Password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Username == dto.UserName))
            {
                return BadRequest("User already exists.");
            }

            var user = new UserModel
            {
                Username = dto.UserName,
                Password = dto.Password, // You should hash this in production!
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }
    }
}
