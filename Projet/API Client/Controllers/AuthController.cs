using API_Client.Model;
using API_Client.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace API_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IUserService userService;
        public AuthController(IConfiguration _confi, IUserService _userService)
        {
            configuration = _confi;
            userService = _userService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLogin user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
                {
                    var loggedInUser = await userService.LoginUser(user);
                    if (loggedInUser is null) return NotFound("User Not Found");
                    ///user found
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, loggedInUser.Id.ToString()),
                        new Claim(ClaimTypes.Name, loggedInUser.username),
                        new Claim(ClaimTypes.Email, loggedInUser.email),
                        new Claim(ClaimTypes.HomePhone, loggedInUser.phone),
                        new Claim(ClaimTypes.PostalCode, loggedInUser.postalCode),
                        new Claim(ClaimTypes.Role, loggedInUser.Role.nameRole),
                    };
                    var token = new JwtSecurityToken
                    (
                        issuer: configuration["Jwt:Issuer"],
                        audience: configuration["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                            SecurityAlgorithms.HmacSha256)
                    );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                        
                    });
                }
                return BadRequest("Invalid User Credentials");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

