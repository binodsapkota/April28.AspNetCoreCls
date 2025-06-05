using Chapter30.ToDoApi.DTOs;
using Chapter30.ToDoApi.Models;
using Chapter30.ToDoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter30.ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly JwtService _jwtService;

        private readonly List<User> _users = new()
        {
            new User { Username = "admin", Password = "admin", Role = "Admin" },
            new User { Username = "user", Password = "123", Role = "User" }
        };

        public AuthApiController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = _users.FirstOrDefault(u => u.Username == loginDto.Username && u.Password == loginDto.Password);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }
            var token = _jwtService.GenerateToken(user.Username, user.Role);
            return Ok(new { Token = token });
        }
    }
}
