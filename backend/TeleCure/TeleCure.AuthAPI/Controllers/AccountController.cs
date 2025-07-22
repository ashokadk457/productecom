using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleCure.Shared;

namespace TeleCure.AuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Username == "admin" && request.Password == "admin")
            {
                var token = Guid.NewGuid().ToString(); // simple token
                StaticUserStore.LoggedInUsers[token] = request.Username;

                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }
    }
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
